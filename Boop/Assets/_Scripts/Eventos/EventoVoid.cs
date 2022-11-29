using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento void", menuName = "Boop/Eventos/Evento void")]
    public class EventoVoid : ScriptableObject
    {
        public Action Evento;

        public void Invoke() => Evento?.Invoke();
    }
}
