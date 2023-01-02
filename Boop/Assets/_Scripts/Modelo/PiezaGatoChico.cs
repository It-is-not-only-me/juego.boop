namespace Boop
{
    public class PiezaGatoChico : PiezaGeneral
    {
        public override void Boop(IPieza pieza)
        {
            if (_tablero == null)
                return;

            pieza.Boop(this, _posicionX, _posicionY);
        }

        public override void Boop(PiezaGatoGrande pieza, int x, int y) => Mover(x, y);

        public override void Boop(PiezaGatoChico pieza, int x, int y) => Mover(x, y);

        
    }
}