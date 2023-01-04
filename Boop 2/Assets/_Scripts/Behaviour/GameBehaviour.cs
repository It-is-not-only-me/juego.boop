using Boop.Configuracion;
using Boop.Evento;
using Boop.Modelo;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class GameBehaviour : MonoBehaviour
    {
        public enum EstadoJuego
        {
            TurnoJugador1,
            TurnoJugador2
        }

        [SerializeField] private TableroBehaviour _tablero;
        [SerializeField] private JugadorBehaviour _jugador1, _jugador2;

        [Space]

        [SerializeField] private EventoVoid _eventoEmpezarJuego;
        [SerializeField] private ConfiguracionInicio _configuracion;

        [Space]

        [SerializeField] private EventoVoid _eventoHabilitarJugador1;
        [SerializeField] private EventoVoid _eventoDeshabilitarJugador1;
        [SerializeField] private EventoVoid _eventoHabilitarJugador2;
        [SerializeField] private EventoVoid _eventoDeshabilitarJugador2;
        [SerializeField] private EventoVoid _eventTerminarJugada;

        private IRegla _regla;
        private EstadoJuego _estadoActual;
        

        private void OnEnable()
        {
            if (_eventTerminarJugada != null)
                _eventTerminarJugada.Evento += AvanzarJuego;

            if (_eventoEmpezarJuego != null)
                _eventoEmpezarJuego.Evento += Empezar;
        }

        private void OnDisable()
        {
            if (_eventTerminarJugada != null)
                _eventTerminarJugada.Evento -= AvanzarJuego;

            if (_eventoEmpezarJuego != null)
                _eventoEmpezarJuego.Evento -= Empezar;
        }

        private void Empezar()
        {
            _regla = new ReglaUpgradeGatitos(_tablero, _jugador1, _jugador2);

            _estadoActual = _configuracion.PrimerJugador;

            _eventoHabilitarJugador1?.Invoke();
            _eventoHabilitarJugador2?.Invoke();
            switch (_estadoActual)
            {
                case EstadoJuego.TurnoJugador1:
                    _eventoDeshabilitarJugador2?.Invoke();
                    break;
                case EstadoJuego.TurnoJugador2:
                    _eventoDeshabilitarJugador1?.Invoke();
                    break;
            }

            AgregarGatitosAJugador(_jugador1, _configuracion.CantidadDeGatitosJugador1);
            AgregarGatitosAJugador(_jugador2, _configuracion.CantidadDeGatitosJugador2);
            AgregarGatosAJugador(_jugador1, _configuracion.CantidadDeGatosJugador1);
            AgregarGatosAJugador(_jugador2, _configuracion.CantidadDeGatosJugador2);
        }

        private void AgregarGatitosAJugador(IJugador jugador, int cantidadPiezas)
        {
            for (int i = 0; i < cantidadPiezas; i++)
                jugador.AgregarGatoChico(new PiezaGatoChico(jugador, _tablero));
        }

        private void AgregarGatosAJugador(IJugador jugador, int cantidadPiezas)
        {
            for (int i = 0; i < cantidadPiezas; i++)
                jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador, _tablero));
        }

        private void AvanzarJuego()
        {
            _eventoHabilitarJugador1?.Invoke();
            _eventoHabilitarJugador2?.Invoke();

            AplicarReglas();

            switch (_estadoActual)
            {
                case EstadoJuego.TurnoJugador1:

                    _eventoDeshabilitarJugador1?.Invoke();
                    _estadoActual = EstadoJuego.TurnoJugador2;

                    break;
                case EstadoJuego.TurnoJugador2:

                    _eventoDeshabilitarJugador2?.Invoke();
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
