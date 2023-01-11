using Boop.Configuracion;
using Boop.Evento;
using Boop.Modelo;
using System.Collections.Generic;
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

        [SerializeField] private JuegoBehaviour _juego;
        [SerializeField] private TableroBehaviour _tablero;
        [SerializeField] private JugadorBehaviour _jugador1, _jugador2;

        [Space]

        [SerializeField] private ConfiguracionInicio _configuracion;
        [SerializeField] private ConfiguracionInventario _configuracionInventario;

        [Space]

        [SerializeField] private EventoVoid _eventoHabilitarJugador1;
        [SerializeField] private EventoVoid _eventoDeshabilitarJugador1;
        [SerializeField] private EventoVoid _eventoHabilitarJugador2;
        [SerializeField] private EventoVoid _eventoDeshabilitarJugador2;
        [SerializeField] private EventoVoid _eventTerminarJugada;

        private List<IRegla> _reglas;
        private EstadoJuego _estadoActual;

        private void Start() => Empezar();

        private void OnEnable()
        {
            if (_eventTerminarJugada != null)
                _eventTerminarJugada.Evento += AvanzarJuego;
        }

        private void OnDisable()
        {
            if (_eventTerminarJugada != null)
                _eventTerminarJugada.Evento -= AvanzarJuego;
        }

        private void Empezar()
        {
            _reglas = new List<IRegla>
            {
                new ReglaUpgradeGatitos(_tablero, _jugador1, _jugador2),
                new ReglaGanar(_juego, _tablero, _jugador1, _configuracionInventario.CantidadMaximaGatos),
                new ReglaGanar(_juego, _tablero, _jugador2, _configuracionInventario.CantidadMaximaGatos)
            };
            

            _estadoActual = _configuracion.PrimerJugador;

            AgregarGatitosAJugador(_jugador1, _configuracion.CantidadDeGatitosJugador1);
            AgregarGatitosAJugador(_jugador2, _configuracion.CantidadDeGatitosJugador2);
            AgregarGatosAJugador(_jugador1, _configuracion.CantidadDeGatosJugador1);
            AgregarGatosAJugador(_jugador2, _configuracion.CantidadDeGatosJugador2);

            switch (_estadoActual)
            {
                case EstadoJuego.TurnoJugador1:
                    _eventoHabilitarJugador1?.Invoke();
                    _eventoDeshabilitarJugador2?.Invoke();
                    break;
                case EstadoJuego.TurnoJugador2:
                    _eventoDeshabilitarJugador1?.Invoke();
                    _eventoHabilitarJugador2?.Invoke();
                    break;
            }
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
            _reglas.ForEach(regla => regla.Aplicar());
        }
    }
}
