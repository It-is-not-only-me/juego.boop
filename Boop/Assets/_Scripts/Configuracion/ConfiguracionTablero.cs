using UnityEngine;

namespace Boop.UI
{
    [CreateAssetMenu(fileName = "Configuracion tablero", menuName = "Boop/Configuracion/Tablero")]
    public class ConfiguracionTablero : ScriptableObject
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