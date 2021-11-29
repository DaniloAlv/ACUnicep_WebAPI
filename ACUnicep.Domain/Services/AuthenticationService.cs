using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces;
using ACUnicep.Domain.Interfaces.Repository;
using ACUnicep.Domain.Interfaces.Services;
using ACUnicep.Domain.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public AuthenticationService(IUsuarioRepository usuarioRepository,
                                     IAlunoRepository alunoRepository, 
                                     IProfessorRepository professorRepository)
        {
            _usuarioRepository = usuarioRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        public string CriptografarSenha(string senha)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create();

            byte[] senhaEncoded = Encoding.UTF8.GetBytes(senha);
            byte[] encryptedSenha = hashAlgorithm.ComputeHash(senhaEncoded);

            StringBuilder sb = new StringBuilder();

            foreach (var charSenha in encryptedSenha)
            {
                sb.Append(charSenha.ToString("X2"));
            }

            return sb.ToString();
        }

        public async Task<string> GerarJWT(string email, TokenSettings tokenSettings)
        {
            Usuario user = await _usuarioRepository.RetornaUsuarioFiltrado(u => u.Email.Equals(email));

            List<Claim> claims = new List<Claim>
            {
                new Claim("userId", user.CodigoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("nivelAcesso", user.NivelAcesso.ToString())
            };

            if (user.NivelAcesso == (int)NivelAcesso.Aluno)
            {
                Aluno aluno = await _alunoRepository.RetornaAlunoFiltrado(a => a.UsuarioId.Equals(user.CodigoUsuario));
                claims.Add(new Claim("cursoId", aluno.CursoId.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, aluno.Nome));
            }
            else
            {
                Professor prof = await _professorRepository.RetornaProfessorFiltrado(prof => prof.UsuarioId.Equals(user.CodigoUsuario));
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, prof.Nome));
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(claims);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(tokenSettings.SecretKey);
            SecurityToken token = tokenHandler.CreateToken(new SecurityTokenDescriptor 
            { 
                Subject = claimsIdentity,
                Audience = tokenSettings.Audience,
                Issuer = tokenSettings.Issuer,
                Expires = DateTime.UtcNow.AddHours(tokenSettings.ExpireIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            });

            string encodedtoken = tokenHandler.WriteToken(token);
            return encodedtoken;
        }
    }
}
