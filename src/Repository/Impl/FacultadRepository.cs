
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Dapper;
using System.Linq;

namespace Api.Repository.Impl
{
    [Service(Scope="Transient")]
    public class FacultadRepository : IFacultadRepository
    {

        private readonly IConfiguration config;
        private readonly ILogger<FacultadRepository> logger;
        private readonly DatabaseManager databaseManager;

        public FacultadRepository(
            IConfiguration configuration, 
            ILogger<FacultadRepository> logger, 
            DatabaseManager databaseManager)
        {
            this.config = configuration;
            this.logger = logger;
            this.databaseManager = databaseManager;
        }

        public List<FacultadResult> Listar()
        {
            try
            {                
                return databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId)
                    .Query<FacultadResult>("dbo.usp_facultad_listar");
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to fetch facultades.", e);
            }
        }

        public List<FacultadResult> Buscar( string texto )
        {
            var parameters = new DynamicParameters();
            parameters.Add("@texto", texto);

            try
            {
                return databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<FacultadResult>("dbo.usp_facultad_buscar", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to fetch facultades.", e);
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
            parameters.Add("@nombre_facultad", nombre);
            parameters.Add("@codigo_facultad", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_actualizar_nombre", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to update facultad.", e);
            }
            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }

        public SimpleResult Crear(string nombre, string codigo )
        {
            List<SimpleResult> m;
            SimpleResult mensaje = new()
            {
                result = 0
            };

            var parameters = new DynamicParameters();
            parameters.Add("@nombre_facultad", nombre);
            parameters.Add("@codigo_facultad", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_crear", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to create facultad.", e);
            }

            if( m.Count >= 1 ) return m.FirstOrDefault();
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
            parameters.Add("@codigo_facultad_new", nuevocodigo);
            parameters.Add("@codigo_facultad", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_eliminar", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to delete facultad.", e);
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
            parameters.Add("@codigo_facultad", codigo);

            try
            {
                m = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_recuperar", parameters);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e.Message);
                throw new Exception("Failed to recover facultad.", e);
            }

            if (m.Count >= 1) return m.FirstOrDefault();
            return mensaje;
        }
    }

}
