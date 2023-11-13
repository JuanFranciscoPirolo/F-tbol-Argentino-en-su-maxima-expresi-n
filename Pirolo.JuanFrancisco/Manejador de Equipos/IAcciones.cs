using FutbolArgentino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejador_de_Equipos
{
    public interface IAcciones
    {
        void ActualizarEquipos(MiColeccion<NuevoEquipoFutbol> miColeccion);

        int OrdenarPorTopico(string ascendenteODescendente, string topico);

        string QuitarTildesYConvertirAMinusculas(string input);

        MiColeccion<NuevoEquipoFutbol> ObtenerEquipos();

    }
}
