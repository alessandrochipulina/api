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
    public class CarreraService : ICarreraService
    {
        private readonly IConfiguration config;
        private readonly ICarreraRepository carreraRepository;
        private readonly ILogger<CarreraService> logger;

        public CarreraService(
            IConfiguration config, 
            ICarreraRepository carreraRepository,
            ILogger<CarreraService> logger)
        {
            this.config = config;
            this.carreraRepository = carreraRepository;
            this.logger = logger;
        }

        public List<CarreraResult> Listar()
        {
            List<CarreraResult> lst;

            try
            {
                lst = this.carreraRepository.Listar();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error en el metodo Facultad.Listar ");
                lst = new List<CarreraResult>();
            }

            return lst;
        }

        public List<CarreraResult> Buscar( string texto )
        {
            List<CarreraResult> lst;

            try
            {
                lst = this.carreraRepository.Buscar( texto );
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
                mensaje = this.carreraRepository.ActualizarNombre(nombre, codigo);
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
                mensaje = this.carreraRepository.Crear(nombre, codigo);
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
                mensaje = this.carreraRepository.Eliminar(codigo, nuevocodigo);
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
                mensaje = this.carreraRepository.Recuperar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el metodo Facultad.Recuperar", ex);
            }
            return mensaje;
        }
    }
}
