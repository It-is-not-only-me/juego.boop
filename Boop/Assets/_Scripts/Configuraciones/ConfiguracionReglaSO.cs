using System;
using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Regla", menuName = "Boop/Configuracion/Regla")]
    public class ConfiguracionReglaSO : ScriptableObject
    {
        [SerializeField, Range(-1, 1)] bool[,] _factores = new bool[3, 3];

        public int Ancho { get => _ancho; }
        public int Alto { get => _alto; }

        private int _ancho = 3, _alto = 3;

        public bool this[int i, int j] { get => PosicionValida(i, j) ? _factores[i, j] : false; }

        private bool PosicionValida(int i, int j) => 0 <= i && i < Ancho && 0 <= j && j < Alto;
    }
}
