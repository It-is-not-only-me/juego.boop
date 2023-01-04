using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion escena", menuName = "Boop/Configuracion/Escena")]
    public class ConfiguracionEscena : ScriptableObject
    {
        [SerializeField] private int _indice;

        public int Indice => _indice;
    }
}