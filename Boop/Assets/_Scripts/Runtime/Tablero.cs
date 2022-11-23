using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.Runtime
{
    public class Tablero : MonoBehaviour
    {
        [SerializeField] private Posicion[] _posicion;

        private uint _ancho = 6, _alto = 6;
    }
}