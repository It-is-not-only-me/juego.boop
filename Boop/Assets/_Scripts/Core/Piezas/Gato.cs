using Boop.Inventario;

namespace Boop.Core
{
    public class Gato : IPieza
    {
        private IBalde _balde;

        public Gato(IBalde balde)
        {
            _balde = balde;
        }

        public void Eliminado() => _balde.Agregar(this);

        public bool PermiteMoverse(IPieza pieza) => pieza.PuedeMover(this);

        public bool PuedeMover(Gatito gatito) => true;

        public bool PuedeMover(Gato gato) => true;

        public bool EsIgual(ItIsNotOnlyMe.Inventario.IElemento elemento) => EsIgual(elemento as IPieza);

        private bool EsIgual(IPieza pieza) => pieza.EsIgual(this);

        public bool EsIgual(Gatito gatito) => false;

        public bool EsIgual(Gato gato) => false;
    }
}
