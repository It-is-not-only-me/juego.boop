using Boop.Core;
using UnityEngine;

namespace Boop.Runtime
{
    public class GatitoBehaviour : MonoBehaviour, IPieza
    {
        [SerializeField] private BaldeSO _balde;

        private Gatito _gatito;

        private void Awake()
        {
            _gatito = new Gatito(_balde);
        }

        public void Eliminado() => _gatito.Eliminado();

        public bool EsIgual(Gatito gatito) => _gatito.EsIgual(gatito);

        public bool EsIgual(Gato gato) => _gatito.EsIgual(gato);

        public bool EsIgual(ItIsNotOnlyMe.Inventario.IElemento elemento) => _gatito.EsIgual(elemento);

        public bool PermiteMoverse(IPieza pieza) => _gatito.PermiteMoverse(pieza);

        public bool PuedeMover(Gatito gatito) => _gatito.PuedeMover(gatito);

        public bool PuedeMover(Gato gato) => _gatito.PuedeMover(gato);
    }
}
