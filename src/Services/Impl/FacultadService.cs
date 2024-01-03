using Api.Entities;
using Api.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Common.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Services.Impl
{
    [Service(Scope="Transient")]
    public class FacultadService : IFacultadService
    {
        private readonly IConfiguration config;
        private readonly IFacultadRepository facultadRepository;
        private readonly ILogger<FacultadService> logger;

        public FacultadService(IConfiguration config, IFacultadRepository employeeRepository,
            ILogger<FacultadService> logger)
        {
            this.config = config;
            this.facultadRepository = employeeRepository;
            this.logger = logger;
        }

        public List<FacultadResult> Listar()
        {
            List<FacultadResult> lst;

            try
            {
                lst = this.facultadRepository.Listar();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error en el metodo Facultad.Listar ");
                lst = new List<FacultadResult>();
            }

            return lst;
        }

        public List<FacultadResult> Buscar( string texto )
        {
            List<FacultadResult> lst;

            try
            {
                lst = this.facultadRepository.Buscar( texto );
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.Buscar", ex);
            }

            return lst;
        }

        public SimpleResult ActualizarNombre(string nombre, string codigo)
        {
            SimpleResult mensaje;
            try
            {
                mensaje = this.facultadRepository.ActualizarNombre(nombre, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.ActualizarNombre", ex);
            }
            return mensaje;
        }

        public SimpleResult Crear(string nombre, string codigo) 
        {
            SimpleResult mensaje;
            try
            {
                mensaje = this.facultadRepository.Crear(nombre, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.Crear", ex);
            }
            return mensaje;
        }

        public SimpleResult Eliminar(string codigo, string nuevocodigo) 
        {
            SimpleResult mensaje;
            try
            {
                mensaje = this.facultadRepository.Eliminar(codigo, nuevocodigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.Eliminar", ex);
            }
            return mensaje;
        }

        public SimpleResult Recuperar(string codigo) 
        {
            SimpleResult mensaje;
            try
            {
                mensaje = this.facultadRepository.Recuperar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.Recuperar", ex);
            }
            return mensaje;
        }
    }
}
