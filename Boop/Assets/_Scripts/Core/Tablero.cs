
namespace Boop.Core
{
    public class Tablero : ITablero
    {
        private IPieza[,] _piezas;
        private uint _cantidadColumnas, _cantidadFilas;

        public Tablero(uint cantidadColumnas, uint cantidadFilas)
        {
            _piezas = new IPieza[cantidadColumnas, cantidadFilas];
            _cantidadColumnas = cantidadColumnas;
            _cantidadFilas = cantidadFilas;
        }

        private IPieza this[Posicion posicion]
        {
            get => _piezas[posicion.Columna, posicion.Fila];
            set => _piezas[posicion.Columna, posicion.Fila] = value;
        }

        public bool AgregarPiza(IPieza pieza, Posicion posicion)
        {
            if (!PosicionLibre(posicion))
                return false;

            this[posicion] = pieza;
            return true;
        }

        public void BoopPiezas(Posicion posicion)
        {
            if (!PosicionEnRango(posicion) || PosicionLibre(posicion))
                return;

            IPieza piezaBoopeadora = this[posicion];

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    Posicion posicionAfectada = posicion.Transladar(i, j);
                    if (!PosicionEnRango(posicionAfectada) || PosicionLibre(posicion))
                        continue;

                    IPieza piezaAfectada = this[posicionAfectada];
                    Posicion nuevaPosicion = posicion.Transladar(i * 2, j * 2);
                    if (!piezaAfectada.PermiteMoverse(piezaBoopeadora) || !PosicionLibre(nuevaPosicion))
                        continue;

                    bool permaneceEnElTablero = Mover(posicionAfectada, nuevaPosicion);
                    if (permaneceEnElTablero)
                        continue;

                    piezaAfectada.Eliminado();
                    this[posicionAfectada] = null;
                }
        }

        /// <summary>
        ///     Mueve una pieza desde la posicion inicial al final, si esta existe
        /// </summary>
        /// <param name="inicial">Hay una pieza en la posicion</param>
        /// <param name="final">No hay una pieza en la posicion</param>
        /// <returns>Devuelve true si puede moverlo y false cuando la posicion final no existe</returns>
        private bool Mover(Posicion inicial, Posicion final)
        {
            if (!PosicionEnRango(final))
                return false;

            IPieza pieza = this[inicial];
            this[inicial] = null;
            this[final] = pieza;
            return true;
        }

        private bool PosicionLibre(Posicion posicion) => this[posicion] == null;

        private bool PosicionEnRango(Posicion posicion) 
        { 
            return 0 <= posicion.Columna && posicion.Columna < _cantidadColumnas &&
                   0 <= posicion.Fila && posicion.Fila < _cantidadFilas; 
        }
    }
}
