using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;

namespace Boop.UI
{
    public class BotonUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EventoVoid EventoInicializar;

        public void OnPointerClick(PointerEventData eventData)
        {
            EventoInicializar?.Invoke();
        }
    }
}
