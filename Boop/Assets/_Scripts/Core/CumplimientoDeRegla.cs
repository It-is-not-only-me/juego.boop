using Boop.Configuracion;
using UnityEngine;

namespace Boop.Core
{
    public struct CumplimientoDeRegla
    {
        public Vector2Int PosicionCentral;
        public ConfiguracionReglaSO ReglaCumplida;

        public CumplimientoDeRegla(Vector2Int posicionCentral, ConfiguracionReglaSO reglaCumplida)
        {
            PosicionCentral = posicionCentral;
            ReglaCumplida = reglaCumplida;
        }
    }
}
