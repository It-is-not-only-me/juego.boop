namespace Boop.Inventario
{
    public class OperacionCantidadElementos : ItIsNotOnlyMe.Inventario.IOperacionElementos
    {
        public uint Cantidad { get; private set; }

        private IElemento _elementoAComparar;

        public OperacionCantidadElementos(IElemento elementoAComparar)
        {
            Cantidad = 0;
            _elementoAComparar = elementoAComparar;
        }

        public void Aplicar(ItIsNotOnlyMe.Inventario.IElemento elemento) => Aplicar(elemento as IElemento);

        private void Aplicar(IElemento elemento)
        {
            if (!_elementoAComparar.EsIgual(elemento))
                return;
            Cantidad++;
        }
    }
}
