using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Boop.UI
{
    [RequireComponent(typeof(Button))]
    public class BotonUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private List<EventoVoid> _eventoHabilitar = new List<EventoVoid>();
        [SerializeField] private List<EventoVoid> _eventoDeshabilitar = new List<EventoVoid>();

        [Space]

        [SerializeField] private EventoVoid _eventoInicializar;

        private Button _boton;
        private Button _getBoton
        {
            get 
            {
                if (_boton == null)
                    _boton = GetComponent<Button>();
                return _boton; 
            }
        }

        private void OnEnable()
        {
            _eventoHabilitar.ForEach(eventoHabilitar => eventoHabilitar.Evento += Habilitar);
            _eventoDeshabilitar.ForEach(eventoDeshabilitar => eventoDeshabilitar.Evento += Deshabilitar);
        }

        private void OnDisable()
        {
            _eventoHabilitar.ForEach(eventoHabilitar => eventoHabilitar.Evento -= Habilitar);
            _eventoDeshabilitar.ForEach(eventoDeshabilitar => eventoDeshabilitar.Evento -= Deshabilitar);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventoInicializar?.Invoke();
        }

        private void Habilitar()
        {
            _getBoton.enabled = true;
            _getBoton.interactable = true;
        }

        private void Deshabilitar()
        {
            _getBoton.enabled = false;
            _getBoton.interactable = false;
        }
    }
}
