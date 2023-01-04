using System.Numerics;
using UnityEngine;

namespace Boop.Modelo
{
    public class ReglaUpgradeGatitos : IRegla
    {
        private ITablero _tablero;
        private IJugador _jugador1, _jugador2;

        private int _ancho, _alto;
        private Vector2Int[] _diagonales;

        public ReglaUpgradeGatitos(ITablero tablero, IJugador jugador1, IJugador jugador2)
        {
            _tablero = tablero;
            _jugador1 = jugador1;
            _jugador2 = jugador2;

            _ancho = tablero.Ancho;
            _alto = tablero.Alto;

            _diagonales = new Vector2Int[4]
            {
                new Vector2Int(-1,  0),
                new Vector2Int(-1, -1),
                new Vector2Int( 0, -1),
                new Vector2Int( 1, -1)
            };
        }

        public void Aplicar(IPieza pieza, int x, int y)
        {
            if (pieza == null || !pieza.EsUpgradeable())
                return;

            foreach (Vector2Int delta in _diagonales)
            {
                int diagonalX = x + delta.x, diagonalY = y + delta.y;
                int opuestoX = x - delta.x, opuestoY = y - delta.y;

                if (!_tablero.EnRango(diagonalX, diagonalY) || !_tablero.EnRango(opuestoX, opuestoY))
                    continue;

                if (!_tablero.HayPiezaEn(diagonalX, diagonalY) || !_tablero.HayPiezaEn(opuestoX, opuestoY))
                    continue;

                IPieza piezaDiagonal = _tablero[diagonalX, diagonalY], piezaOpuesta = _tablero[opuestoX, opuestoY];
                if (!pieza.EsIgual(piezaDiagonal) || !pieza.EsIgual(piezaOpuesta))
                    continue;

                _tablero.EliminarPieza(x, y);
                _tablero.EliminarPieza(diagonalX, diagonalY);
                _tablero.EliminarPieza(opuestoX, opuestoY);

                IJugador jugador = pieza.PerteneceA(_jugador1) ? _jugador1 : _jugador2;
                jugador.AgregarGatoChico((PiezaGatoChico)pieza);
                jugador.AgregarGatoChico((PiezaGatoChico)piezaDiagonal);
                jugador.AgregarGatoChico((PiezaGatoChico)piezaOpuesta);

                jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador, _tablero));
                jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador, _tablero));
                jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador, _tablero));
            }
        }
    }
}
