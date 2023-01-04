using System;
using UnityEngine;
using Boop.UI;

namespace Boop.Evento
{
    [CreateAssetMenu(fileName = "Evento movimiento", menuName = "Boop/Evento/Movimiento")]
    public class EventoMovimiento : ScriptableObject
    {
        public Action<PiezaUI, int, int> Evento;

        public void Invoke(PiezaUI piezaUI, int x, int y) => Evento?.Invoke(piezaUI, x, y);
    }
}
