namespace Boop.Inventario
{
    public class OperacionEliminarElemento : ItIsNotOnlyMe.Inventario.IOperacionEspacios
    {
        public bool SeLogroEliminar { get; private set; }

        private IElemento _elementoAEliminar;

        public OperacionEliminarElemento(IElemento elementoAEliminar)
        {
            _elementoAEliminar = elementoAEliminar;
            SeLogroEliminar = false;
        }

        public void Aplicar(ItIsNotOnlyMe.Inventario.IEspacio espacios) => Aplicar(espacios as IEspacio);

        private void Aplicar(IEspacio espacio)
        {
            if (SeLogroEliminar)
                return;

            SeLogroEliminar = espacio.Eliminar(_elementoAEliminar);
        }
    }
}
