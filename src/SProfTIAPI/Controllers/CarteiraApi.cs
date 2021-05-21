/*
 * SProfTI API
 *
 * Seletor de Profissinais de TI API
 *
 * OpenAPI spec version: 1.0.0
 * Contact: rubensagnelo@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using SProfTIAPI.Attributes;

using Microsoft.AspNetCore.Authorization;
using SProfTIAPI.Models;

namespace SProfTIAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CarteiraApiController : ControllerBase
    { 
        /// <summary>
        /// Inclui uma nova carteira de selecao de profissionais
        /// </summary>
        /// <remarks>Inclui uma nova carteira de selecao de profissionais na lista de carteiras</remarks>
        /// <param name="body">Item Carteira de profissional(CarteiraItem) para inclusao</param>
        /// <response code="201">carteira incluida</response>
        /// <response code="400">parametro ou estrutura de entrada inálida</response>
        /// <response code="409">carteira já existente (nome da carteira ja existe)</response>
        [HttpPost]
        [Authorize]
        [Route("/rubensagnelo/sprotiapi/1.0.0/carteira")]
        [ValidateModelState]
        [SwaggerOperation("AddCarteira")]
        [SwaggerResponse(statusCode: 201, type: typeof(CarteiraItemresponse), description: "carteira incluida")]
        public virtual IActionResult AddCarteira([FromBody]CarteiraItem body)
        { 
            var rspStc = Services.CarteiraService.Add(body);
            CarteiraItemresponse objResp = new CarteiraItemresponse(){Idcarteira=body.Idcarteira};
            return StatusCode(rspStc, objResp);
        }

        /// <summary>
        /// Buscar todas as carteiras de selecao de profissionais
        /// </summary>
        /// <remarks>Buscar todas as Carteira de profissionais</remarks>
        /// <param name="nome">nome ou parte do nome da carteira para consultar as carteiras</param>
        /// <param name="registros">quantidades de registros</param>
        /// <response code="200">resultados da consulta</response>
        /// <response code="400">valor do parametro inválido</response>
        //[Authorize]
        [HttpGet]
        [Route("/rubensagnelo/sprotiapi/1.0.0/carteira")]
        [ValidateModelState]
        [SwaggerOperation("BuscarTodasAsCarteiraDeProfissionais")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<CarteiraItem>), description: "resultados da consulta")]
        public virtual IActionResult BuscarTodasAsCarteiraDeProfissionais([FromQuery]string nome, [FromQuery]int? registros)
        { 
            int rspStc = 0;
            List<CarteiraItem> objResp = Services.CarteiraService.Get(out rspStc,nome);
            return StatusCode(rspStc, objResp);
        }

        /// <summary>
        /// Exclui uma carteira pelo Identificador da carteira
        /// </summary>
        /// <remarks>Exclui uma carteira pelo Identificador da carteira</remarks>
        /// <param name="idcarteira"></param>
        /// <response code="202">carteira excluída</response>
        /// <response code="400">id da carteira inálida</response>
        /// <response code="404">carteira nao encontrada</response>
        [HttpDelete]
        [Authorize]
        [Route("/rubensagnelo/sprotiapi/1.0.0/carteira/{idcarteira}")]
        [ValidateModelState]
        [SwaggerOperation("CarteiraIdcarteiraDelete")]
        public virtual IActionResult CarteiraIdcarteiraDelete([FromRoute][Required]int? idcarteira)
        { 
            int rspStc = 0;
            Services.CarteiraService.Del(out rspStc, idcarteira);
            return StatusCode(rspStc);
       }

        /// <summary>
        /// Consulta uma carteira de selecao de profissionais pelo identificador da carteira
        /// </summary>
        /// <remarks>Consulta uma carteira de selecao de profissionais pelo identificador da carteira</remarks>
        /// <param name="idcarteira"></param>
        /// <response code="200">resultados da consulta</response>
        /// <response code="400">valor do parametro inválido</response>
        [HttpGet]
        [Route("/rubensagnelo/sprotiapi/1.0.0/carteira/{idcarteira}")]
        [ValidateModelState]
        [SwaggerOperation("CarteiraIdcarteiraGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(CarteiraItem), description: "resultados da consulta")]
        public virtual IActionResult CarteiraIdcarteiraGet([FromRoute][Required]int? idcarteira)
        { 

            int rspStc = 0;
            CarteiraItem objResp = Services.CarteiraService.GetById(out rspStc, idcarteira);
            return StatusCode(rspStc, objResp);
        }

        /// <summary>
        /// Atualiza os dados de uma carteira
        /// </summary>
        /// <param name="idcarteira"></param>
        /// <param name="body">Item Carteira de profissional(CarteiraItem) para atualizacao (obs:idcarteira no body será ignorado)</param>
        /// <response code="400">Identificador da carteira fornecido é inválido</response>
        /// <response code="404">carteira nao encontrada</response>
        /// <response code="405">Exceção na autalização dos dados da carteira</response>
        [HttpPut]
        [Authorize]
        [Route("/rubensagnelo/sprotiapi/1.0.0/carteira/{idcarteira}")]
        [ValidateModelState]
        [SwaggerOperation("CarteiraIdcarteiraPut")]
        public virtual IActionResult CarteiraIdcarteiraPut([FromRoute][Required]int? idcarteira, [FromBody]CarteiraItem body)
        { 
            var rspStc = Services.CarteiraService.Update(idcarteira ,body);
            CarteiraItemresponse objResp = new CarteiraItemresponse(){Idcarteira=body.Idcarteira};
            return StatusCode(rspStc, objResp);
        }
    }
}
