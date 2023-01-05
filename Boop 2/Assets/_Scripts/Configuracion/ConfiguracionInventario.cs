using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inventario", menuName = "Boop/Configuracion/Inventario")]
    public class ConfiguracionInventario : ScriptableObject
    {
        public int CantidadMaximaGatitos, CantidadMaximaGatos;
    }
}