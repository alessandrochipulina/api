
using Api.Entities;
using Api.Services;
using Common.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Controllers
{
    [ApiController]
    [Route("/v1/carrera")]
    public class CarreraController : ControllerBase
    {
        private readonly HttpUtil httpUtil = new HttpUtil();
        private readonly IConfiguration config;
        private readonly ILogger<CarreraController> logger;
        private ICarreraService carreraService;

        public CarreraController(
            IConfiguration config,
            ILogger<CarreraController> logger,
            ICarreraService carreraService)
        {
            this.config = config;
            this.logger = logger;
            this.carreraService = carreraService;
        }

        [HttpGet]
        [Route("/v1/carrera/listar")]
        public ActionResult<List<CarreraResult>> Listar()
        {
            var list = this.carreraService.Listar();
            return Ok(list);

        }

        [HttpGet]
        [Route("/v1/carrera/buscar")]
        public ActionResult<List<CarreraResult>> Buscar(string texto)
        {
            var list = this.carreraService.Buscar(texto);
            return Ok(list);
        }

        [HttpPatch]
        [Route("/v1/carrera/actualizar")]
        public ActionResult<SimpleResult> ActualizarNombre(string nombre, string codigo)
        {
            try
            {
                var result = this.carreraService.ActualizarNombre(nombre, codigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        [Route("/v1/carrera/crear")]
        public ActionResult<SimpleResult> Crear(string nombre, string codigo)
        {
            try
            {
                var result = this.carreraService.Crear(nombre, codigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpDelete]
        [Route("/v1/carrera/eliminar")]
        public ActionResult<SimpleResult> Eliminar(string codigo, string nuevocodigo)
        {
            try
            {
                var result = this.carreraService.Eliminar(codigo, nuevocodigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Route("/v1/carrera/recuperar")]
        public ActionResult<SimpleResult> Recuperar(string codigo)
        {
            try
            {
                var result = this.carreraService.Recuperar(codigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }           
        }

        // return Ok(httpUtil.createHttpResponse(200000, "success", null));
        // throw new ApiException((ApiResponseCodes.StringEmpyError).AsString(EnumFormat.Description), Enums.ToInt32(ApiResponseCodes.StringEmpyError));        
    }
}
