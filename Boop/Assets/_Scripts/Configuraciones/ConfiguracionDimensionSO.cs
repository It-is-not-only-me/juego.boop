using System;
using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Dimensiones", menuName = "Boop/Configuracion/Dimensiones")]
    public class ConfiguracionDimensionSO : ScriptableObject
    {
        [SerializeField, Range(1, 20)] uint _ancho, _alto;

        public uint Ancho { get => _ancho; }
        public uint Alto { get => _alto; }
    }
}
