using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(Button))]
    public class BotonUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EventoVoid _eventoHabilitar, _eventoDeshabilitar;

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
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento += Habilitar;

            if (_eventoDeshabilitar != null)
                _eventoDeshabilitar.Evento += Deshabilitar;
        }

        private void OnDisable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento -= Habilitar;


            if (_eventoDeshabilitar != null)
                _eventoDeshabilitar.Evento -= Deshabilitar;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventoInicializar?.Invoke();
        }

        private void Habilitar()
        {
            _getBoton.interactable = true;
        }

        private void Deshabilitar()
        {
            _getBoton.interactable = false;
        }
    }
}
