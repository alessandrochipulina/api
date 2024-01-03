
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
    [Route("/v1/facultad")]
    public class FacultadController : ControllerBase
    {
        private readonly HttpUtil httpUtil = new HttpUtil();
        private readonly IConfiguration config;
        private readonly ILogger<FacultadController> logger;
        private IFacultadService facultadService;

        public FacultadController(
            IConfiguration config,
            ILogger<FacultadController> logger,
            IFacultadService facultadService)
        {
            this.config = config;
            this.logger = logger;
            this.facultadService = facultadService;
        }
        
        [HttpGet]
        [Route("/v1/facultad/listar")]
        public ActionResult<List<FacultadResult>> Listar()
        {
            var list = this.facultadService.Listar();
            return Ok(list);

        }

        [HttpGet]
        [Route("/v1/facultad/buscar")]
        public ActionResult<List<FacultadResult>> Buscar( string texto)
        {   
            var list = this.facultadService.Buscar( texto );
            return Ok(list);
        }

        [HttpPatch]
        [Route("/v1/facultad/actualizar")]
        public ActionResult<SimpleResult> ActualizarNombre(string nombre, string codigo)
        {
            try
            {
                var result = this.facultadService.ActualizarNombre(nombre, codigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        [Route("/v1/facultad/crear")]
        public ActionResult<SimpleResult> Crear(string nombre, string codigo)
        {
            try
            {
                var result = this.facultadService.Crear(nombre, codigo);
                return Ok(result);
            }
            catch (Exception e) { 
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("/v1/facultad/eliminar")]
        public ActionResult<SimpleResult> Eliminar(string codigo, string nuevocodigo)
        {
            try
            {
                var result = this.facultadService.Eliminar(codigo, nuevocodigo);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Route("/v1/facultad/recuperar")]
        public ActionResult<SimpleResult> Recuperar(string codigo)
        {
            try
            {
                var result = this.facultadService.Recuperar(codigo);
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
