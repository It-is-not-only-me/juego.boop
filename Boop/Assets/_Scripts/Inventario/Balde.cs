namespace Boop.Inventario
{
    public class Balde : IBalde
    {
        private IEspacio _espacioGatitos, _espacioGatos;

        public Balde(IEspacio espacioGatitos, IEspacio espacioGatos)
        {
            _espacioGatitos = espacioGatitos;
            _espacioGatos = espacioGatos;
        }

        public void Agregar(IElemento elemento)
        {
            OperacionAgregarElemento operacion = new OperacionAgregarElemento(elemento);
            AplicarOperacion(operacion);
            if (!operacion.SeLogroAgregar)
                throw new NoSePudoAgregarElementoException();
        }

        public void Eliminar(IElemento elemento)
        {
            OperacionEliminarElemento operacion = new OperacionEliminarElemento(elemento);
            AplicarOperacion(operacion);
            if (!operacion.SeLogroEliminar)
                throw new NoSePudoEliminarElementoException();
        }

        public uint CantidadElementosDelTipo(IElemento elemento)
        {
            OperacionCantidadElementos operacion = new OperacionCantidadElementos(elemento);
            AplicarOperacion(operacion);
            return operacion.Cantidad;
        }

        public bool AgregarEspacio(ItIsNotOnlyMe.Inventario.IEspacio espacio) => throw new NoSePuedeAgregarEspaciosException();

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion)
        {
            _espacioGatitos.AplicarOperacion(operacion);
            _espacioGatos.AplicarOperacion(operacion);
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion)
        {
            _espacioGatitos.AplicarOperacion(operacion);
            _espacioGatos.AplicarOperacion(operacion);
        }
    }
}
