using Api.Entities;
using System.Collections.Generic;

namespace Api.Repository
{
    public interface IFacultadRepository
    {
        List<FacultadResult> Listar();
        List<FacultadResult> Buscar( string texto);
        SimpleResult ActualizarNombre(string nombre, string codigo);
        SimpleResult Crear( string nombre, string codigo);
        SimpleResult Eliminar(string codigo, string nuevocodigo );
        SimpleResult Recuperar(string codigo);
    }

}
