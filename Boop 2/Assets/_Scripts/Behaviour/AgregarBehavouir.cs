using Boop.Evento;
using Boop.Modelo;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class AgregarBehavouir : MonoBehaviour
    {
        [SerializeField] private TableroBehaviour _tablero;
        [SerializeField] private JugadorBehaviour _jugador1, _jugador2;

        [Space]

        [SerializeField] private EventoCoordenada _agregarGatitoJugador1;
        [SerializeField] private EventoCoordenada _agregarGatitoJugador2;
        [SerializeField] private EventoCoordenada _agregarGatoJugador1;
        [SerializeField] private EventoCoordenada _agregarGatoJugador2;

        private void OnEnable()
        {
            if (_agregarGatitoJugador1 != null)
                _agregarGatitoJugador1.Evento += AgregarGatitoJugador1;

            if (_agregarGatitoJugador2 != null)
                _agregarGatitoJugador2.Evento += AgregarGatitoJugador2;

            if (_agregarGatoJugador1 != null)
                _agregarGatoJugador1.Evento += AgregarGatoJugador1;

            if (_agregarGatoJugador2 != null)
                _agregarGatoJugador2.Evento += AgregarGatoJugador2;
        }

        private void AgregarGatitoJugador1(int x, int y) => AgregarGatito(_jugador1, x, y);

        private void AgregarGatitoJugador2(int x, int y) => AgregarGatito(_jugador2, x, y);

        private void AgregarGatito(IJugador jugador, int x, int y) => _tablero.AgregarPieza(new PiezaGatoChico(jugador, _tablero), x, y);

        private void AgregarGatoJugador1(int x, int y) => AgregarGato(_jugador1, x, y);

        private void AgregarGatoJugador2(int x, int y) => AgregarGato(_jugador2, x, y);

        private void AgregarGato(IJugador jugador, int x, int y) => _tablero.AgregarPieza(new PiezaGatoGrande(jugador, _tablero), x, y);

    }
}
