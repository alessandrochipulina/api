
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
                throw new Exception("Failed to fetch facultades.", e);
            }
        }

        public List<FacultadResult> Buscar( string texto )
        {
            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("texto", texto);
            parameters.Add(p1);

            try
            {
                return databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<FacultadResult>("dbo.usp_facultad_buscar", parameters);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to fetch facultades.", e);
            }
        }

        public SimpleResult ActualizarNombre(string nombre, string codigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("nombre_facultad", nombre);
            parameters.Add(p1);
            var p2 = new SqlParameter("codigo_facultad", codigo);
            parameters.Add(p2);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_actualizar_nombre", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to update facultad.", e);
            }

            return mensaje;
        }

        public SimpleResult Crear(string nombre, string codigo )
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("nombre_facultad", nombre);
            parameters.Add(p1);
            var p2 = new SqlParameter("codigo_facultad", codigo);
            parameters.Add(p2);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_crear", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create facultad.", e);
            }

            return mensaje;
        }

        public SimpleResult Eliminar(string codigo, string nuevocodigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("codigo_facultad", codigo);
            parameters.Add(p1);
            var p2 = new SqlParameter("codigo_nueva_facultad", nuevocodigo);
            parameters.Add(p2);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_eliminar", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to delete facultad.", e);
            }

            return mensaje;
        }

        public SimpleResult Recuperar(string codigo)
        {
            SimpleResult mensaje;

            var parameters = new List<SqlParameter>();
            var p1 = new SqlParameter("codigo_facultad", codigo);
            parameters.Add(p1);

            try
            {
                mensaje = databaseManager.LookupDatabaseConnectorById(ApiConstants.DatabaseId).
                    Query<SimpleResult>("dbo.usp_facultad_recuperar", parameters)[0];
            }
            catch (Exception e)
            {
                throw new Exception("Failed to recover facultad.", e);
            }

            return mensaje;
        }
    }

}
