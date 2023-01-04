using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inventario", menuName = "Boop/Configuracion/Inventario")]
    public class ConfiguracionInventario : ScriptableObject
    {
        [SerializeField] private int _cantidadMaximaGatitos, _cantidadMaximaGatos;

        public int CantidadMaximaGatitos { get => _cantidadMaximaGatitos; }
        public int CantidadMaximaGatos { get => _cantidadMaximaGatos; }
    }
}