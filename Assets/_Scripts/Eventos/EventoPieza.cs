using Boop.Modelo;
using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento pieza", menuName = "Boop/Evento/Pieza")]
    public class EventoPieza : ScriptableObject
    {
        public Action<IPieza> Evento;

        public void Invoke(IPieza pieza) => Evento?.Invoke(pieza);
    }
}
