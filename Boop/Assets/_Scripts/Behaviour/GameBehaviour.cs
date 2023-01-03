using Boop.Evento;
using Boop.Modelo;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class GameBehaviour : MonoBehaviour
    {
        private enum EstadoJuego
        {
            TurnoJugador1,
            TurnoJugador2
        }

        [SerializeField] private TableroBehaviour _tablero;
        [SerializeField] private JugadorBehaviour _jugador1, _jugador2;

        [Space]

        [SerializeField] private EventoVoid _terminarJugada;

        [Space]

        [SerializeField] private EventoVoid _habilitarJugador1;
        [SerializeField] private EventoVoid _habilitarJugador2;

        private IRegla _regla;
        private EstadoJuego _estadoActual;
        

        private void Awake()
        {
            _regla = new ReglaUpgradeGatitos(_tablero, _jugador1, _jugador2);
            _estadoActual = EstadoJuego.TurnoJugador1;
        }

        private void OnEnable()
        {
            if (_terminarJugada != null)
                _terminarJugada.Evento += AvanzarJuego;
        }

        private void OnDisable()
        {
            if (_terminarJugada != null)
                _terminarJugada.Evento -= AvanzarJuego;
        }

        private void AvanzarJuego()
        {
            AplicarReglas();

            switch (_estadoActual)
            {
                case EstadoJuego.TurnoJugador1:

                    _habilitarJugador1?.Invoke();
                    _estadoActual = EstadoJuego.TurnoJugador2;

                    break;
                case EstadoJuego.TurnoJugador2:

                    _habilitarJugador2?.Invoke();
                    _estadoActual = EstadoJuego.TurnoJugador1;

                    break;
            }
        }

        private void AplicarReglas()
        {
            _tablero.AplicarRegla(_regla);
        }
    }
}
