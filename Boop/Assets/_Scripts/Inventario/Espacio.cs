using System.Collections.Generic;

namespace Boop.Inventario
{
    public class Espacio : IEspacio
    {
        private List<IElemento> _elementos;
        private uint _cantidadMaxima;

        private IElemento _elementoRepresentativo 
        { 
            get 
            {
                if (Vacio())
                    return null;
                return _elementos[0];
            } 
        }
        private uint _cantidad { get => (uint)_elementos.Count; }

        public Espacio(uint cantidadMaxima)
        {
            _elementos = new List<IElemento>();
            _cantidadMaxima = cantidadMaxima;
        }

        public bool Agregar(IElemento elemento)
        {
            if ((_elementoRepresentativo != null && !_elementoRepresentativo.EsIgual(elemento)) || _cantidad == _cantidadMaxima)
                return false;

            _elementos.Add(elemento);
            return true;
        }

        public bool Eliminar(IElemento elemento)
        {
            if (_elementoRepresentativo == null || !_elementoRepresentativo.EsIgual(elemento))
                return false;

            _elementos.RemoveAt(0);
            return true;
        }

        private bool Vacio() => _cantidad == 0;

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion) => _elementos.ForEach(elemento => operacion.Aplicar(elemento));

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion) => operacion.Aplicar(this);
    }
}
