using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inventario", menuName = "Boop/Configuracion/Inventario")]
    public class ConfiguracionInventario : ScriptableObject
    {
        [SerializeField] private int _cantidadMaximaGatitos, _cantidadDeGatitos;
        [SerializeField] private int _cantidadMaximaGatos, _cantidadDeGatos;

        public int CantidadMaximaGatitos { get => _cantidadMaximaGatitos; }
        public int CantidadDeGatitos { get => _cantidadDeGatitos; }
        public int CantidadMaximaGatos { get => _cantidadMaximaGatos; }
        public int CantidadDeGatos { get => _cantidadDeGatos; }
    }
}