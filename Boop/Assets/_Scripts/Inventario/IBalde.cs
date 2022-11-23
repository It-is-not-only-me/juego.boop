
namespace Boop.Inventario
{
    public interface IBalde
    {
        /// <summary>
        ///     Agrega un elemento al balde.
        /// </summary>
        /// <param name="elemento"></param>
        public void Agregar(IElemento elemento);
    }
}
