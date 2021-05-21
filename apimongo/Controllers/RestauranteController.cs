using apimongo.Controllers.Inputs;
using apimongo.Data.Repositories;
using apimongo.Domain.Entities;
using apimongo.Domain.Enums;
using apimongo.Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apimongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteRepository _restauranteRepository;

        public RestauranteController(RestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        [HttpPost("restaurante")]
        public ActionResult IncluirRestaurante([FromBody] RestauranteInclusao restauranteInclusao) {

            var cozinha = ECozinhaHelper.ConverterDeInteiro(restauranteInclusao.Cozinha);
            var restaurante = new Restaurante(restauranteInclusao.Nome, cozinha);
            var endereco = new Endereco(
                restauranteInclusao.Logradouro,
                restauranteInclusao.Numero,
                restauranteInclusao.Cidade,
                restauranteInclusao.UF,
                restauranteInclusao.Cep
            );
            restaurante.AtribuirEndereco(endereco);
            if (!restaurante.Validar())
            {
                return BadRequest(new{errors = restaurante.ValidationResult.Errors.Select(a => a.ErrorMessage)});
            }

            _restauranteRepository.Inserir(restaurante);

            return Ok(new {data = "restaurante inserido com sucesso!!" });
        }
    }
}
