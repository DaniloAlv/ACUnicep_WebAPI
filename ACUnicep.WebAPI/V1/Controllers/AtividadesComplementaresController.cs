using ACUnicep.Domain.Entities;
using ACUnicep.Domain.Interfaces.Services;
using ACUnicep.Domain.ViewModels;
using ACUnicep.WebAPI.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ACUnicep.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AtividadesComplementaresController : ControllerBase
    {
        private readonly IAtividadesComplementaresService _atividadesComplementaresService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AtividadesComplementaresController(IAtividadesComplementaresService atividadesComplementaresService,
                                                  IMapper mapper, 
                                                  IConfiguration configuration)
        {
            _atividadesComplementaresService = atividadesComplementaresService;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Retorna lista de atividades que o aluno já submeteu
        /// </summary>
        /// <param name="cdUsuario"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<AtividadeComplementar>), 200)]
        [HttpGet("{cdUsuario}")]
        public async Task<ActionResult<List<AtividadeComplementar>>> GetAtividadesComplementares(string cdUsuario)
        {
            IEnumerable<AtividadeComplementar> atividadesComplementares = await _atividadesComplementaresService.GetByAluno(cdUsuario);
            return Ok(new BaseResponse().Ok(true, "", atividadesComplementares));
        }

        /// <summary>
        /// Retorna atividade especificada pelo ID da atividade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AtividadeComplementar), 200)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AtividadeComplementar>> GetAtividadeComplementar(Guid id)
        {
            AtividadeComplementar atividadeComplementar = await _atividadesComplementaresService.GetById(id);
            return Ok(new BaseResponse().Ok(true, "", atividadeComplementar));
        }

        /// <summary>
        /// Cadastra uma nova atividade complementar para o aluno
        /// </summary>
        /// <param name="atividadeComplementar"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(BaseResponse), 201)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        [HttpPost]
        public async Task<ActionResult<AtividadeComplementar>> CadastrarAtividadeComplementar([FromForm] AtividadeComplementarRequest atividadeComplementar)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponse().BadRequest(false, "Não foi possível cadastrar a atividade. Revise os dados antes de submeter novamente."));

            await _atividadesComplementaresService.Adicionar(_mapper.Map<AtividadeComplementar>(atividadeComplementar));
            return Created(nameof(CadastrarAtividadeComplementar), new BaseResponse().Ok(true, "Atividade Complementar cadastrada com sucesso!", atividadeComplementar));
        }

        /// <summary>
        /// Atualiza informações de uma atividade já existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atividadeComplementar"></param>
        /// <returns></returns>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(BaseResponse), 400)]
        [ProducesResponseType(typeof(BaseResponse), 404)]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> AtualizarAtividadeComplementar([FromRoute] Guid id, AtividadeComplementarRequest atividadeComplementar)
        {
            if (!ModelState.IsValid)
                return BadRequest(new BaseResponse().BadRequest(false, "Não foi possível atualizar a atividade."));

            AtividadeComplementar atividadeParaAtualizar = await _atividadesComplementaresService.GetById(id);

            if (atividadeParaAtualizar == null)
                return NotFound(new BaseResponse().BadRequest(false, "A atividade não foi encontrada e/ou não está mais disponível."));

            await _atividadesComplementaresService.Atualizar(_mapper.Map<AtividadeComplementar>(atividadeComplementar), id);
            return NoContent();
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo)
        {
            if (arquivo.Length <= 0)
                throw new Exception("Não foi enviado nenhum arquivo e/ou seu conteúdo é vazio.");

            string filePath = Path.Combine(_configuration.GetValue<string>("FileShare"), "acunicep\\imgs\\");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            filePath = string.Concat(filePath, arquivo.FileName);

            if (!System.IO.File.Exists(filePath))
                throw new Exception("Já há um arquivo com o mesmo nome.");

            using(FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await arquivo.CopyToAsync(fs);
                return true;
            }
        }
    }
}
