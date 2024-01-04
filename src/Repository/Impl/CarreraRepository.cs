
using Api.Entities;
using Common.Database.Conexion;
using Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Common.Attributes;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace Api.Repository.Impl
{
    [Service(Scope="Transient")]
    public class CarreraRepository : ICarreraRepository
    {
        private readonly IConfiguration config;
        private readonly ILogger<CarreraRepository> logger;
        private readonly DatabaseManager databaseManager;

        public CarreraRepository(
            IConfiguration configuration, 
            ILogger<CarreraRepository> logger, 
            DatabaseManager databaseManager)
        {
            this.config = configuration;
            this.logger = logger;
            this.databaseManager = databaseManager;
        }

        public List<CarreraResult> Listar()
        {
            try
            {                
                return databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId)
                    .Query<CarreraResult>("dbo.usp_carrera_listar");
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch carreras.", e);
            }
        }

        public List<CarreraResult> Buscar( string texto )
        {
            var parameters = new DynamicParameters();
            parameters.Add("@texto", texto);

            try
            {
                return databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<CarreraResult>("dbo.usp_carrera_buscar", parameters);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch carreras.", e);
            }
        }

        public SimpleResult ActualizarNombre(string nombre, string codigo)
        {
            List<SimpleResult> m;
            SimpleResult mensaje = new()
            {
                result = 0
            };

            var parameters = new DynamicParameters();
            parameters.Add("@nombre_carrera", nombre);
            parameters.Add("@codigo_carrera", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_actualizar_nombre", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to update carrera.", e);
            }
            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }

        public SimpleResult Crear(string nombre, string codigo, string codigo_facultad)
        {
            List<SimpleResult> m;
            SimpleResult mensaje = new()
            {
                result = 0
            };

            var parameters = new DynamicParameters();
            parameters.Add("@nombre_carrera", nombre);
            parameters.Add("@codigo_carrera", codigo);
            parameters.Add("@codigo_facultad", codigo_facultad);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_crear", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to create carrera.", e);
            }
            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }

        public SimpleResult Eliminar(string codigo, string nuevocodigo)
        {
            List<SimpleResult> m;
            SimpleResult mensaje = new()
            {
                result = 0
            };

            var parameters = new DynamicParameters();
            parameters.Add("@codigo_carrera", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_eliminar", parameters);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to delete carrera.", e);
            }

            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }

        public SimpleResult Recuperar(string codigo)
        {
            List<SimpleResult> m;
            SimpleResult mensaje = new()
            {
                result = 0
            };

            var parameters = new DynamicParameters();
            parameters.Add("@codigo_carrera", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_recuperar", parameters);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to recover carrera.", e);
            }

            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }
    }

}
