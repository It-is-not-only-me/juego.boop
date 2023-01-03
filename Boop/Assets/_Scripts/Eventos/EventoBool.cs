using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento bool", menuName = "Boop/Evento/Bool")]
    public class EventoBool : ScriptableObject
    {
        public Action<bool> Evento;

        public void Invoke(bool valor) => Evento?.Invoke(!valor);
    }
}
