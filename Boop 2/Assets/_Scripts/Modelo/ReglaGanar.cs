using UnityEngine;

namespace Boop.Modelo
{
    public class ReglaGanar : IRegla
    {
        private IJuego _juego;
        private ITablero _tablero;
        private IJugador _jugador;
        private int _cantidadGatos;

        private int _ancho, _alto;
        private Vector2Int[] _diagonales;

        public ReglaGanar(IJuego juego, ITablero tablero, IJugador jugador, int cantidadGatos)
        {
            _juego = juego;
            _tablero = tablero;
            _jugador = jugador;
            _cantidadGatos = cantidadGatos;

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
            bool seGano = false;
            for (int i = 0; i < _ancho && !seGano; i++)
                for (int j = 0; j < _alto && !seGano; j++)
                {
                    seGano = TresEnLinea(_tablero[i, j], i, j);
                }

            int cantidadDeGatos = 0;
            for (int i = 0; i < _ancho && !seGano; i++)
                for (int j = 0; j < _alto && !seGano; j++)
                {
                    bool hayGato = TieneGato(_tablero[i, j]);
                    if (hayGato)
                        cantidadDeGatos++;

                    seGano = cantidadDeGatos >= _cantidadGatos;
                }

            if (!seGano)
                return;

            _juego.SeGano(_jugador);
        }

        private bool TresEnLinea(IPieza pieza, int x, int y)
        {
            if (pieza == null || pieza.EsUpgradeable() || !pieza.PerteneceA(_jugador))
                return false;

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
                
                return true;
            }

            return false;
        }

        private bool TieneGato(IPieza pieza) => pieza != null && !pieza.EsUpgradeable() && pieza.PerteneceA(_jugador);
    }
}
