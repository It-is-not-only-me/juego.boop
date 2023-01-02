namespace Boop
{
    public abstract class PiezaGeneral : IPieza
    {
        protected ITablero _tablero;
        protected int _posicionX, _posicionY;

        public void EstablecerTablero(ITablero tablero, int x, int y)
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

        protected void Mover(int x, int y)
        {
            if (_tablero == null)
                return;

            int diferenciaX = _posicionX - x, diferenciaY = _posicionY - y;
            int nuevaX = _posicionX + diferenciaX, nuevaY = _posicionY + diferenciaY;

            if (!_tablero.EnRango(nuevaX, nuevaY))
                _tablero.EliminarPieza(_posicionX, _posicionY);
            else
                _tablero.MoverPieza(_posicionX, _posicionY, nuevaX, nuevaY);
        }

    }
}