using Api.Entities;
using System.Collections.Generic;

namespace Api.Repository
{
    public interface ICarreraRepository
    {
        List<CarreraResult> Listar();
        List<CarreraResult> Buscar(string texto);
        SimpleResult ActualizarNombre(string nombre, string codigo);
        SimpleResult Crear(string nombre, string codigo, string codigo_facultad );
        SimpleResult Eliminar(string codigo);
        SimpleResult Recuperar(string codigo);
    }

}
