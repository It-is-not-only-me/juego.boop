using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(Button))]
    public class BotonUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EventoBool _eventoHabilitar;

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
        }

        private void OnDisable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento -= Habilitar;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventoInicializar?.Invoke();
        }

        private void Habilitar(bool estado)
        {
            _getBoton.interactable = estado;
        }
    }
}
