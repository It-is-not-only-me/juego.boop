using UnityEngine;
using Boop.Evento;
using Boop.Modelo;
using Boop.Configuracion;
using Boop.UI;

namespace Boop.Bahaviour
{
    public class TableroBehaviour : MonoBehaviour, ITablero
    {
        [SerializeField] private ConfiguracionGrilla _configuracion;

        [SerializeField] private EventoAgregarPieza _eventoAgregarPieza;

        [Space]

        [SerializeField] private EventoCoordenada _eventoSacarPieza;
        [SerializeField] private EventoTransladar _eventoTransladarPieza;

        private ITablero _tablero;

        private void Awake()
        {
            _tablero = new Tablero(_configuracion.Columnas, _configuracion.Filas);
        }

        private void OnEnable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento += AgregarUnaPieza;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento -= AgregarUnaPieza;
        }

        public IPieza this[int x, int y] => _tablero[x, y];

        public int Ancho => _tablero.Ancho;

        public int Alto => _tablero.Alto;

        public void AgregarUnaPieza(IPieza pieza, int x, int y) => AgregarPieza(pieza, x, y);

        public bool AgregarPieza(IPieza pieza, int x, int y) => _tablero.AgregarPieza(pieza, x, y);

        public bool EliminarPieza(int x, int y)
        {
            bool sePudoEliminar = _tablero.EliminarPieza(x, y);
            if (sePudoEliminar)
                _eventoSacarPieza?.Invoke(x, y);
            return sePudoEliminar;
        }

        public bool MoverPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
        {
            bool sePudoMover = _tablero.MoverPieza(xOriginal, yOriginal, xFinal, yFinal);
            if (sePudoMover)
                _eventoTransladarPieza?.Invoke(xOriginal, yOriginal, xFinal, yFinal);
            return sePudoMover;
        }

        public void AplicarRegla(IRegla regla) => _tablero.AplicarRegla(regla);

        public bool EnRango(int x, int y) => _tablero.EnRango(x, y);

        public bool HayPiezaEn(int x, int y) => _tablero.HayPiezaEn(x, y);
    }
}
