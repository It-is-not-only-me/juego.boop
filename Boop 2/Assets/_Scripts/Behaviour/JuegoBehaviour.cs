using Boop.Configuracion;
using Boop.Evento;
using Boop.Modelo;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class JuegoBehaviour : MonoBehaviour, IJuego
    {
        [SerializeField] private ConfiguracionGanador _configuracion;

        [Space]

        [SerializeField] private EventoVoid _eventoGanar;

        [Space]

        [SerializeField] private JugadorBehaviour _jugador1;
        [SerializeField] private JugadorBehaviour _jugador2;

        public void SeGano(IJugador jugador)
        {
            if ((IJugador)_jugador1 == jugador)
                _configuracion.GanoJugador1();

            if ((IJugador)_jugador2 == jugador)
                _configuracion.GanoJugador2();

            _eventoGanar?.Invoke();
        }
    }
}
