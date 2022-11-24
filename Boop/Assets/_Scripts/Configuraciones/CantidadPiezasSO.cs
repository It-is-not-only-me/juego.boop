using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.Configuraciones
{
    [CreateAssetMenu(fileName = "Cantidad de piezas", menuName = "Boop/Configuraciones/Cantidad de piezas")]
    public class CantidadPiezasSO : ScriptableObject
    {
        [SerializeField] private uint _cantidadDeGatos;
        [SerializeField] private uint _cantidadDeGatitos;

        public uint CantidadDeGatos() => _cantidadDeGatitos;
        public uint CantidadDeGatitos() => _cantidadDeGatitos;
    }
}
