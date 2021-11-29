using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces;
using ACUnicep.Domain.Interfaces.Repository;
using ACUnicep.Domain.Interfaces.Services;
using ACUnicep.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace ACUnicep.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAuthenticationService _authenticationService;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IAuthenticationService authenticationService, 
                              IAlunoRepository alunoRepository, 
                              IProfessorRepository professorRepository)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
        }

        public async Task RegistrarUsuario(Usuario usuario)
        {
            usuario.Senha = _authenticationService.CriptografarSenha(usuario.Senha);
            await _usuarioRepository.RegistrarUsuario(usuario);
        }

        public async Task<Usuario> RetornaUsuario(Guid id)
        {
            return await _usuarioRepository.RetornaUsuario(id);
        }

        public async Task<Usuario> RetornaUsuarioFiltrado(LoginModel login)
        {
            Usuario user;
            string encryptedSenha = _authenticationService.CriptografarSenha(login.Senha);

            if (login.NivelAcesso == (int)NivelAcesso.Aluno)
            {
                Aluno aluno = await _alunoRepository.RetornaAluno(login.CodigoUsuario);
                user = await _usuarioRepository.RetornaUsuarioFiltrado(u => u.Email.Equals(aluno.Usuario.Email) &&
                        u.Senha.Equals(encryptedSenha) && u.Valido);
            }
            else
            {
                Professor prof = await _professorRepository.RetornaProfessor(login.CodigoUsuario);
                user = await _usuarioRepository.RetornaUsuarioFiltrado(u => u.Email.Equals(prof.Usuario.Email) &&
                        u.Senha.Equals(encryptedSenha) && u.Valido);
            }

            return user;
        }
    }
}
