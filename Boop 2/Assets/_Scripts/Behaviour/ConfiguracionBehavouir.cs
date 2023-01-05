using Boop.Configuracion;
using Boop.Evento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class ConfiguracionBehavouir : MonoBehaviour
    {
        [SerializeField] private ConfiguracionInicio _configuracionInicio;
        [SerializeField] private ConfiguracionInventario _configuracionInventario;

        [Space]

        [SerializeField] private EventoVoid _eventoSeEligeJugador1;
        [SerializeField] private EventoVoid _eventoSeEligeJugador2;
        [SerializeField] private EventoNumero _eventoCantidadGatitos;
        [SerializeField] private EventoNumero _eventoCantidadGatos;

        [Space]

        [SerializeField] private EventoVoid _eventoJugador1Actual;
        [SerializeField] private EventoVoid _eventoJugador2Actual;
        [SerializeField] private EventoNumero _eventoCantidadGatitosActual;
        [SerializeField] private EventoNumero _eventoCantidadGatosActual;

        private void Start()
        {
            switch (_configuracionInicio.PrimerJugador)
            {
                case GameBehaviour.EstadoJuego.TurnoJugador1: _eventoJugador1Actual?.Invoke();
                    break;
                case GameBehaviour.EstadoJuego.TurnoJugador2: _eventoJugador2Actual?.Invoke();
                    break;
            }

            _eventoCantidadGatitosActual?.Invoke(_configuracionInventario.CantidadMaximaGatitos);
            _eventoCantidadGatosActual?.Invoke(_configuracionInventario.CantidadMaximaGatos);
        }

        private void OnEnable()
        {
            if (_eventoSeEligeJugador1 != null)
                _eventoSeEligeJugador1.Evento += SeEligeJugador1;

            if (_eventoSeEligeJugador2 != null)
                _eventoSeEligeJugador2.Evento += SeEligeJugador2;

            if (_eventoCantidadGatitos != null)
                _eventoCantidadGatitos.Evento += CantidadGatitos;

            if (_eventoCantidadGatos != null)
                _eventoCantidadGatos.Evento += CantidadGatos;
        }

        private void OnDisable()
        {
            if (_eventoSeEligeJugador1 != null)
                _eventoSeEligeJugador1.Evento -= SeEligeJugador1;

            if (_eventoSeEligeJugador2 != null)
                _eventoSeEligeJugador2.Evento -= SeEligeJugador2;

            if (_eventoCantidadGatitos != null)
                _eventoCantidadGatitos.Evento -= CantidadGatitos;

            if (_eventoCantidadGatos != null)
                _eventoCantidadGatos.Evento -= CantidadGatos;
        }

        private void SeEligeJugador1()
        {
            _configuracionInicio.PrimerJugador = GameBehaviour.EstadoJuego.TurnoJugador1;
        }

        private void SeEligeJugador2()
        {
            _configuracionInicio.PrimerJugador = GameBehaviour.EstadoJuego.TurnoJugador2;
        }

        private void CantidadGatitos(int cantidad)
        {
            _configuracionInicio.CantidadDeGatitosJugador1 = cantidad;
            _configuracionInicio.CantidadDeGatitosJugador2 = cantidad;
            _configuracionInventario.CantidadMaximaGatitos = cantidad;
            _eventoCantidadGatitosActual?.Invoke(cantidad);
        }

        private void CantidadGatos(int cantidad)
        {
            _configuracionInventario.CantidadMaximaGatos = cantidad;
            _eventoCantidadGatosActual?.Invoke(cantidad);
        }
    }
}
