namespace Boop.Inventario
{
    public class OperacionAgregarElemento : ItIsNotOnlyMe.Inventario.IOperacionEspacios
    {
        public bool SeLogroAgregar { get; private set; }

        private IElemento _elementoAAgregar;

        public OperacionAgregarElemento(IElemento elementoAAgregar)
        {
            _elementoAAgregar = elementoAAgregar;
            SeLogroAgregar = false;
        }

        public void Aplicar(ItIsNotOnlyMe.Inventario.IEspacio espacios) => Aplicar(espacios as IEspacio);

        private void Aplicar(IEspacio espacio)
        {
            if (SeLogroAgregar)
                return;

            SeLogroAgregar = espacio.Agregar(_elementoAAgregar);
        }
    }
}
