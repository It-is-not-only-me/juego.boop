namespace Boop.Modelo
{
    public class PiezaGatoGrande : PiezaGeneral
    {
        public PiezaGatoGrande(IJugador jugador, ITablero tablero) : base(jugador, tablero)
        {
        }

        public override void Boop(IPieza pieza)
        {
            if (_tablero == null)
                return;
            pieza.Boop(this, _posicionX, _posicionY);
        }

        public override void Boop(PiezaGatoGrande pieza, int x, int y) => Mover(x, y);

        public override void Boop(PiezaGatoChico pieza, int x, int y)
        {
        }

        public override bool EsIgual(IPieza pieza) => pieza.EsIgual(this);

        public override bool EsIgual(PiezaGatoGrande pieza) => pieza.PerteneceA(_jugador);

        public override bool EsIgual(PiezaGatoChico pieza) => false;

        public override bool EsUpgradeable() => true;
    }
}