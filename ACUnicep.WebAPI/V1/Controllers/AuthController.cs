using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces.Repository;
using ACUnicep.Domain.Interfaces.Services;
using ACUnicep.Domain.ViewModels;
using ACUnicep.WebAPI.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ACUnicep.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]

    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly TokenSettings _tokenSettings;

        public AuthController(IUsuarioService usuarioService,
                              IAlunoRepository alunoRepository,
                              IProfessorRepository professorRepository,
                              IAuthenticationService authenticationService,
                              IMapper mapper,
                              IOptions<TokenSettings> options)
        {
            _usuarioService = usuarioService;
            _authenticationService = authenticationService;
            _tokenSettings = options.Value;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Realiza o cadastro de um usuário no sistema
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros no cadastro!");

            await _usuarioService.RegistrarUsuario(_mapper.Map<Usuario>(register));

            return Created(nameof(Register), register);
        }

        /// <summary>
        /// Método para realizar login no sistema, mediante a um cadastro prévio
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest("Preencha todos os campos para efetuar o login!");

            Usuario usuario = await _usuarioService.RetornaUsuarioFiltrado(_mapper.Map<LoginModel>(login));

            if (usuario != null)
            {
                string jwt = await _authenticationService.GerarJWT(usuario.Email, _tokenSettings);
                return Ok(new { Success = true, Data = jwt });
            }

            return NotFound(new { Success = false, Data = "Usuário não existente e/ou não encontrado!" });
        }
    }
}
