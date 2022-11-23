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
    }
}
