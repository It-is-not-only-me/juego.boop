using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;

namespace Boop.UI
{
    public class BotonEventoUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EventoVoid _eventoHabilitar;

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventoHabilitar?.Invoke();
        }
    }
}
