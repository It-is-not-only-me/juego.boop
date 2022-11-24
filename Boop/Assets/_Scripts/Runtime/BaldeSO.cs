using Boop.Configuraciones;
using Boop.Inventario;
using ItIsNotOnlyMe.Inventario;
using UnityEngine;

namespace Boop.Runtime
{
    [CreateAssetMenu(fileName = "Balde", menuName = "Boop/Inventario/Balde")]
    public class BaldeSO : ScriptableObject, IBalde
    {
        [SerializeField] private CantidadPiezasSO _cantidadDePiezas;
        
        private IBalde _balde;


        private void OnEnable()
        {
            _balde = new Balde(new Espacio(_cantidadDePiezas.CantidadDeGatitos()), new Espacio(_cantidadDePiezas.CantidadDeGatos()));
        }

        public void Agregar(Inventario.IElemento elemento) => _balde.Agregar(elemento);

        public void Eliminar(Inventario.IElemento elemento) => _balde.Eliminar(elemento);

        public uint CantidadElementosDelTipo(Inventario.IElemento elemento) => _balde.CantidadElementosDelTipo(elemento);

        public bool AgregarEspacio(ItIsNotOnlyMe.Inventario.IEspacio espacio) => _balde.AgregarEspacio(espacio);

        public void AplicarOperacion(IOperacionElementos operacion) => _balde.AplicarOperacion(operacion);

        public void AplicarOperacion(IOperacionEspacios operacion) => _balde.AplicarOperacion(operacion);
    }
}
