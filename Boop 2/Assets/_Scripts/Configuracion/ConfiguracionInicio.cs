using Boop.Bahaviour;
using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inicio", menuName = "Boop/Configuracion/Inicio")]
    public class ConfiguracionInicio : ScriptableObject
    {
        [SerializeField] private int _cantidadDeGatitosJugador1, _cantidadDeGatosJugador1;

        [Space]

        [SerializeField] private int _cantidadDeGatitosJugador2, _cantidadDeGatosJugador2;

        [Space]

        [SerializeField] private GameBehaviour.EstadoJuego _primerJugador;

        public int CantidadDeGatitosJugador1 => _cantidadDeGatitosJugador1; 
        public int CantidadDeGatosJugador1 => _cantidadDeGatosJugador1; 

        public int CantidadDeGatitosJugador2 => _cantidadDeGatitosJugador2; 
        public int CantidadDeGatosJugador2 => _cantidadDeGatosJugador2; 

        public GameBehaviour.EstadoJuego PrimerJugador => _primerJugador;
    }
}