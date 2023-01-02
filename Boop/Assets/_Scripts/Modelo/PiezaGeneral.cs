namespace Boop
{
    public abstract class PiezaGeneral : IPieza
    {
        protected Tablero _tablero;
        protected int _posicionX, _posicionY;

        public void EstablecerTablero(Tablero tablero, int x, int y)
        {
            _tablero = tablero;
            _posicionX = x;
            _posicionY = y;
        }

        public void SalirDelTablero()
        {
            _tablero = null;
        }

        public abstract void Boop(IPieza pieza);
        public abstract void Boop(PiezaGatoGrande pieza, int x, int y);
        public abstract void Boop(PiezaGatoChico pieza, int x, int y);

    }
}