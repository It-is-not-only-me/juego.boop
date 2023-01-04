using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion grilla", menuName = "Boop/Configuracion/Grilla")]
    public class ConfiguracionGrilla : ScriptableObject
    {
        [SerializeField] private int _filas, _columnas;
        [SerializeField] private Vector2 _espaciado;
        [SerializeField] private RectOffset _padding;

        public int Filas { get => _filas; }
        public int Columnas { get => _columnas; }
        public Vector2 Espaciado { get => _espaciado; }
        public RectOffset Padding { get => _padding; }
    }
}