namespace Boop
{
    public class Tablero
    {
        private int _ancho, _alto;

        private IPieza[,] _tablero;

        public Tablero(int ancho, int alto)
        {
            _ancho = ancho;
            _alto = alto;

            _tablero = new IPieza[ancho, alto];
            for (int i = 0; i < ancho; i++)
                for (int j = 0; j < alto; j++)
                    _tablero[i, j] = null;
        }

        public IPieza this[int x, int y] { get => _tablero[x, y]; private set => _tablero[x, y] = value; }

        public bool AgregarPieza(IPieza pieza, int x, int y)
        {
            if (!EnRango(x, y) || !HayPiezaEn(x, y))
                return false;

            this[x, y] = pieza;
            pieza.EstablecerTablero(this, x, y);

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    int nuevoX = x + i, nuevoY = y + j;

                    if (!EnRango(nuevoX, nuevoY) || this[nuevoX, nuevoY] == null)
                        continue;

                    pieza.Boop(this[nuevoX, nuevoY]);
                }

            return true;
        }

        public bool EliminarPieza(int x, int y)
        {
            if (!EnRango(x, y) || !HayPiezaEn(x,y))
                return false;

            this[x, y].SalirDelTablero();
            this[x, y] = null;
            return true;
        }

        public bool MoverPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
        {
            if (!EnRango(xOriginal, yOriginal) || !EnRango(xFinal, yFinal) || !HayPiezaEn(xOriginal, yOriginal) || HayPiezaEn(xFinal, yFinal))
                return false;

            IPieza pieza = this[xOriginal, yOriginal];
            this[xOriginal, yOriginal] = null;
            this[xFinal, yFinal] = pieza;

            return true;
        }

        private bool EnRango(int x, int y) => 0 <= x && x < _ancho && 0 <= y && y < _alto;
        private bool HayPiezaEn(int x, int y) => this[x, y] != null;
    }
}