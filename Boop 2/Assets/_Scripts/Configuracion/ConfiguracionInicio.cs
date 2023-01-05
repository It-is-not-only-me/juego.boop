using Boop.Bahaviour;
using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inicio", menuName = "Boop/Configuracion/Inicio")]
    public class ConfiguracionInicio : ScriptableObject
    {
        public int CantidadDeGatitosJugador1, CantidadDeGatosJugador1;
        public int CantidadDeGatitosJugador2, CantidadDeGatosJugador2;

        public GameBehaviour.EstadoJuego PrimerJugador;
    }
}