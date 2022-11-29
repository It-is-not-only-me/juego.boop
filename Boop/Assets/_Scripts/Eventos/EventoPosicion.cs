using Boop.Core;
using System;
using UnityEngine;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento posicion", menuName = "Boop/Eventos/Evento Posicion")]
    public class EventoPosicion : ScriptableObject
    {
        public Action<Vector2Int, IPieza> Evento;

        public void Invoke(Vector2Int posicion, IPieza pieza) => Evento?.Invoke(posicion, pieza);
    }
}
