using UnityEngine;

namespace Boop.UI
{
    public abstract class SlotUI : MonoBehaviour, IReiniciable
    {
        public abstract void Reiniciar();
        public abstract void Sacar();
    }
}
