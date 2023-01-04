using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento coordenada", menuName = "Boop/Evento/Coordenada")]
    public class EventoCoordenada : ScriptableObject
    {
        public Action<int, int> Evento;

        public void Invoke(int x, int y) => Evento?.Invoke(x, y);
    }
}
