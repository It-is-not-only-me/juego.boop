using Boop.Inventario;

namespace Boop.Core
{
    public class Gatito : IPieza
    {
        private IBalde _balde;

        public Gatito(IBalde balde)
        {
            _balde = balde;
        }

        public void Eliminado() => _balde.Agregar(this);

        public bool PermiteMoverse(IPieza pieza) => pieza.PuedeMover(this);

        public bool PuedeMover(Gatito gatito) => true;

        public bool PuedeMover(Gato gato) => false;

        public bool EsIgual(ItIsNotOnlyMe.Inventario.IElemento elemento) => EsIgual(elemento as IPieza);

        private bool EsIgual(IPieza pieza) => pieza.EsIgual(this);

        public bool EsIgual(Gatito gatito) => true;

        public bool EsIgual(Gato gato) => false;
    }
}
