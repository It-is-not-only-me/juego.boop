using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento numero", menuName = "Boop/Evento/Numero")]
    public class EventoNumero : ScriptableObject
    {
        public Action<int> Evento;

        public void Invoke(int numero) => Evento?.Invoke(numero);
    }
}
