using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento string", menuName = "Boop/Evento/String")]
    public class EventoString : ScriptableObject
    {
        public Action<string> Evento;

        public void Invoke(string nombre) => Evento?.Invoke(nombre);
    }
}
