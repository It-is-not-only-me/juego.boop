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
        [SerializeField] private ConfiguracionGanador _configuracionGanador;

        [Space]

        [SerializeField] private EventoVoid _eventoSeEligeJugador1;
        [SerializeField] private EventoVoid _eventoSeEligeJugador2;
        [SerializeField] private EventoNumero _eventoCantidadGatitos;
        [SerializeField] private EventoNumero _eventoCantidadGatos;
        [SerializeField] private EventoString _eventoNombreJugador1;
        [SerializeField] private EventoString _eventoNombreJugador2;

        [Space]

        [SerializeField] private EventoVoid _eventoJugador1Actual;
        [SerializeField] private EventoVoid _eventoJugador2Actual;
        [SerializeField] private EventoNumero _eventoCantidadGatitosActual;
        [SerializeField] private EventoNumero _eventoCantidadGatosActual;
        [SerializeField] private EventoString _eventoNombreJugador1Actual;
        [SerializeField] private EventoString _eventoNombreJugador2Actual;

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
            _eventoNombreJugador1Actual?.Invoke(_configuracionGanador.NombreGanador1);
            _eventoNombreJugador2Actual?.Invoke(_configuracionGanador.NombreGanador2);
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

            if (_eventoNombreJugador1 != null)
                _eventoNombreJugador1.Evento += NombreJugador1;

            if (_eventoNombreJugador2 != null)
                _eventoNombreJugador2.Evento += NombreJugador2;
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

            if (_eventoNombreJugador1 != null)
                _eventoNombreJugador1.Evento -= NombreJugador1;

            if (_eventoNombreJugador2 != null)
                _eventoNombreJugador2.Evento -= NombreJugador2;
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

        private void NombreJugador1(string nombre)
        {
            _configuracionGanador.NombreGanador1 = nombre;
            _eventoNombreJugador1Actual?.Invoke(nombre);
        }

        private void NombreJugador2(string nombre)
        {
            _configuracionGanador.NombreGanador2 = nombre;
            _eventoNombreJugador2Actual?.Invoke(nombre);
        }
    }
}
