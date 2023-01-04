using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento transladar", menuName = "Boop/Evento/Transladar")]
    public class EventoTransladar : ScriptableObject
    {
        public Action<int, int, int, int> Evento;

        public void Invoke(int xOriginal, int yOriginal, int xFinal, int yFinal) => Evento?.Invoke(xOriginal, yOriginal, xFinal, yFinal);
    }
}
