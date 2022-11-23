namespace Boop.Inventario
{
    public interface IBalde : ItIsNotOnlyMe.Inventario.IInventario
    {
        /// <summary>
        ///     Agrega un elemento al balde.
        /// </summary>
        /// <param name="elemento"></param>
        public void Agregar(IElemento elemento);

        /// <summary>
        ///     Elimina un elemento del balde, en el espacio en el que se encuentre primero
        /// </summary>
        /// <param name="elemento"></param>
        public void Eliminar(IElemento elemento);

        /// <summary>
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve la cantidad de elementos que sean iguales</returns>
        public uint CantidadElementosDelTipo(IElemento elemento);
    }
}
