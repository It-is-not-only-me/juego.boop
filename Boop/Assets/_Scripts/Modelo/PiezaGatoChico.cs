namespace Boop
{
    public class PiezaGatoChico : PiezaGeneral
    {
        public override void Boop(IPieza pieza)
        {
            if (_tablero == null)
                return;
            Boop(this, _posicionX, _posicionY);
        }

        public override void Boop(PiezaGatoGrande pieza, int x, int y) => Mover(x, y);

        public override void Boop(PiezaGatoChico pieza, int x, int y) => Mover(x, y);

        private void Mover(int x, int y)
        {
            if (_tablero == null)
                return;

            int diferenciaX = _posicionX - x, diferenciaY = _posicionY - y;

            bool pudoMoverse = _tablero.MoverPieza(_posicionX, _posicionY, _posicionX + diferenciaX, _posicionY + diferenciaY);

            if (!pudoMoverse)
                _tablero.EliminarPieza(_posicionX, _posicionY);
        }
    }
}