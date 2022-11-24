using Boop.Core;
using UnityEngine;

namespace Boop.Runtime
{
    public class GatoBehaviour : MonoBehaviour, IPieza
    {
        [SerializeField] private BaldeSO _balde;

        private Gato _gato;

        private void Awake()
        {
            _gato = new Gato(_balde);
        }

        public void Eliminado() => _gato.Eliminado();

        public bool EsIgual(Gatito gatito) => _gato.EsIgual(gatito);

        public bool EsIgual(Gato gato) => _gato.EsIgual(gato);

        public bool EsIgual(ItIsNotOnlyMe.Inventario.IElemento elemento) => _gato.EsIgual(elemento);

        public bool PermiteMoverse(IPieza pieza) => _gato.PermiteMoverse(pieza);

        public bool PuedeMover(Gatito gatito) => _gato.PuedeMover(gatito);

        public bool PuedeMover(Gato gato) => _gato.PuedeMover(gato);
    }
}
