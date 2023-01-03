using System;
using UnityEngine;
using Boop.Modelo;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento agregar pieza", menuName = "Boop/Evento/Agregar pieza")]
    public class EventoAgregarPieza : ScriptableObject
    {
        public Action<IPieza, int, int> Evento;

        public void Invoke(IPieza pieza, int x, int y) => Evento?.Invoke(pieza, x, y);
    }
}
