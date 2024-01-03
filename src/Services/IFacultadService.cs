using Api.Entities;
using System.Collections.Generic;

namespace Api.Services
{
    public interface IFacultadService
    {
        List<FacultadResult> Listar();
        List<FacultadResult> Buscar( string texto );
        SimpleResult ActualizarNombre(string nombre, string codigo);
        SimpleResult Crear(string nombre, string codigo);
        SimpleResult Eliminar(string codigo, string nuevocodigo);
        SimpleResult Recuperar(string codigo);
    }

}
