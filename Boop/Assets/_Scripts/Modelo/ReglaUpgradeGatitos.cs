using System.Numerics;
using UnityEngine;

namespace Boop
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

        public void Aplicar()
        {
            for (int i = 1; i < _ancho - 1; i++)
                for (int j = 1; j < _alto - 1; j++)
                {
                    IPieza piezaActual = _tablero[i, j];
                    if (!piezaActual.EsUpgradeable())
                        continue;

                    foreach (Vector2Int delta in _diagonales)
                    {
                        int diagonalX = i + delta.x, diagonalY = j + delta.y;
                        int opuestoX = i - delta.x, opuestoY = j - delta.y;
                        if (!_tablero.HayPiezaEn(diagonalX, diagonalY) || !_tablero.HayPiezaEn(opuestoX, opuestoY))
                            continue;

                        IPieza piezaDiagonal = _tablero[diagonalX, diagonalY], piezaOpuesta = _tablero[opuestoX, opuestoY];
                        if (!piezaActual.EsIgual(piezaDiagonal) || !piezaActual.EsIgual(piezaOpuesta))
                            continue;

                        _tablero.EliminarPieza(i, j);
                        _tablero.EliminarPieza(diagonalX, diagonalY);
                        _tablero.EliminarPieza(opuestoX, opuestoY);

                        IJugador jugador = piezaActual.PerteneceA(_jugador1) ? _jugador1 : _jugador2;
                        jugador.AgregarGatoChico((PiezaGatoChico)piezaActual);
                        jugador.AgregarGatoChico((PiezaGatoChico)piezaDiagonal);
                        jugador.AgregarGatoChico((PiezaGatoChico)piezaOpuesta);

                        jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador));
                        jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador));
                        jugador.AgregarGatoGrande(new PiezaGatoGrande(jugador));
                    }
                }
        }
    }
}
