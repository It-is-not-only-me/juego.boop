using Boop.Inventario;

namespace Boop.Core
{
    public interface IPieza : IElemento
    {
        /// <summary>
        ///     Determinar si se puede mover dependiendo de la pieza que quiera moverlo
        /// </summary>
        /// <param name="pieza"></param>
        /// <returns>Devuelve true si la pieza lo puede mover</returns>
        public bool PermiteMoverse(IPieza pieza);

        /// <summary>
        ///     Determina si puede mover una pieza de tipo Gatito
        /// </summary>
        /// <param name="gatito"></param>
        /// <returns>Devuelve true si esta pieza puede moverla</returns>
        public bool PuedeMover(Gatito gatito);

        /// <summary>
        ///     Determina si puede mover una pieza de tipo Gato
        /// </summary>
        /// <param name="gato"></param>
        /// <returns>Devuelve true si esta pieza puede moverla</returns>
        public bool PuedeMover(Gato gato);

        /// <summary>
        ///     En caso de caer afuera del tablero, sera eliminado y debera volver a su correspondiente balde.
        /// </summary>
        public void Eliminado();

        /// <summary>
        ///     Es igual a un gato de clase Gatito
        /// </summary>
        /// <param name="gatito"></param>
        /// <returns>Devuelve true si lo es</returns>
        public bool EsIgual(Gatito gatito);

        /// <summary>
        ///     Es igual a un gato de clase Gato
        /// </summary>
        /// <param name="gato"></param>
        /// <returns>Devuelve true si lo es</returns>
        public bool EsIgual(Gato gato);
    }
}
