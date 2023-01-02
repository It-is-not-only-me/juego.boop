namespace Boop
{
    public interface ITablero
    {
        public IPieza this[int x, int y] { get; }

        public bool AgregarPieza(IPieza pieza, int x, int y);
        public bool EliminarPieza(int x, int y);
        public bool MoverPieza(int xOriginal, int yOriginal, int xFinal, int yFinal);
        public bool HayPiezaEn(int x, int y);
        public bool EnRango(int x, int y);
    }
}