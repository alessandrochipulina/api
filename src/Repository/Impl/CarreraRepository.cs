
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
            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("texto", texto);
            parameters.Add(p1);

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
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("nombre_carrera", nombre);
            parameters.Add(p1);
            var p2 = new SqlParameter("codigo_carrera", codigo);
            parameters.Add(p2);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_actualizar_nombre", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to update carrera.", e);
            }

            return mensaje;
        }

        public SimpleResult Crear(string nombre, string codigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("nombre_carrera", nombre);
            parameters.Add(p1);
            var p2 = new SqlParameter("codigo_carrera", codigo);
            parameters.Add(p2);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_crear", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create carrera.", e);
            }

            return mensaje;
        }

        public SimpleResult Eliminar(string codigo, string nuevocodigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("codigo_carrera", codigo);
            parameters.Add(p1);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_eliminar", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to delete carrera.", e);
            }

            return mensaje;
        }

        public SimpleResult Recuperar(string codigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("codigo_carrera", codigo);
            parameters.Add(p1);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_carrera_recuperar", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to recover carrera.", e);
            }

            return mensaje;
        }
    }

}
