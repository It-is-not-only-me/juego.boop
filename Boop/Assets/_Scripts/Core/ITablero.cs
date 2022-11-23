namespace Boop.Core
{
    public interface ITablero
    {
        /// <summary>
        ///     Agrega una piza en la posición indicada
        /// </summary>
        /// <param name="pieza"></param>
        /// <param name="posicion"></param>
        /// <returns>Devuelve true si pudo agregarlo, o false si ya hay una piza en esa posición</returns>
        public bool AgregarPiza(IPieza pieza, Posicion posicion);

        /// <summary>
        ///     Mueve todas las piezas alrededor de la posicion dada. 
        /// </summary>
        /// <param name="posicion">Es la posicion centro del movimiento</param>
        public void BoopPiezas(Posicion posicion);
    }
}
