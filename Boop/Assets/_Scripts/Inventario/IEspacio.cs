namespace Boop.Inventario
{
    public interface IEspacio : ItIsNotOnlyMe.Inventario.IEspacio
    {
        /// <summary>
        ///     Agrega un elemento al espacio
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve true si pudo agregar el elemento</returns>
        public bool Agregar(IElemento elemento);

        /// <summary>
        ///     Elimina un elemento del espacio
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve true si pudo eliminar el elemento</returns>
        public bool Eliminar(IElemento elemento);
    }
}
