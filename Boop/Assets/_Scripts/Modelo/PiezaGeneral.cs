namespace Boop.Modelo
{
    public abstract class PiezaGeneral : IPieza
    {
        protected ITablero _tablero;
        protected int _posicionX, _posicionY;
        protected IJugador _jugador;

        protected PiezaGeneral(IJugador jugador)
        {
            _jugador = jugador;
        }

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

        public abstract bool EsIgual(IPieza pieza);
        public abstract bool EsIgual(PiezaGatoGrande pieza);
        public abstract bool EsIgual(PiezaGatoChico pieza);


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

        public bool PerteneceA(IJugador jugador) => _jugador == jugador;

        public abstract bool EsUpgradeable();
    }
}