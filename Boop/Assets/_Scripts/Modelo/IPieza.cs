namespace Boop
{
    public interface IPieza
    {
        public void EstablecerTablero(ITablero tablero, int x, int y);

        public void SalirDelTablero();

        public bool PerteneceA(IJugador jugador);

        public bool EsUpgradeable();

        public bool EsIgual(IPieza pieza);

        public bool EsIgual(PiezaGatoGrande pieza);

        public bool EsIgual(PiezaGatoChico pieza);

        /// <summary>
        ///     Empujar la pieza pasada por parametro.
        /// </summary>
        /// <param name="pieza"></param>
        public void Boop(IPieza pieza);

        /// <summary>
        ///     Establecer que hacer al ser empujada por la pieza posicionada en x, y.
        /// </summary>
        /// <param name="pieza"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Boop(PiezaGatoGrande pieza, int x, int y);

        /// <summary>
        ///     Establecer que hacer al ser empujada por la pieza posicionada en x, y.
        /// </summary>
        /// <param name="pieza"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Boop(PiezaGatoChico pieza, int x, int y);
    }
}