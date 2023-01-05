using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(Button))]
    public class BotonEventoNumeroUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EventoNumero _eventoNumero;
        [SerializeField] private int _numero;

        [Space]

        [SerializeField] private EventoNumero _eventoNumeroActual;

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
            if (_eventoNumeroActual != null)
                _eventoNumeroActual.Evento += ActualizarBoton;
        }

        private void OnDisable()
        {
            if (_eventoNumeroActual != null)
                _eventoNumeroActual.Evento -= ActualizarBoton;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _eventoNumero?.Invoke(_numero);
        }

        private void ActualizarBoton(int numero)
        {
            bool activar = _numero != numero;
            _getBoton.enabled = activar;
            _getBoton.interactable = activar;
        }
    }
}
