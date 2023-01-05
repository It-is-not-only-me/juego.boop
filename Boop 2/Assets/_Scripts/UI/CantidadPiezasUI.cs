using Boop.Evento;
using UnityEngine;
using TMPro;

namespace Boop.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CantidadPiezasUI : MonoBehaviour
    {
        [SerializeField] private EventoVoid _eventoAgregarPieza, _eventoSacarPieza;

        private int _cantidad = 0;

        private TextMeshProUGUI _texto;
        private TextMeshProUGUI _getTexto
        {
            get
            {
                if (_texto == null)
                    _texto = GetComponent<TextMeshProUGUI>();
                return _texto;
            }
        }

        private void Awake()
        {
            _cantidad = 0;
        }

        private void OnEnable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento += AgregarPieza;

            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento -= AgregarPieza;

            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento -= SacarPieza;
        }

        private void AgregarPieza()
        {
            _cantidad++;
            ActualizarTexto();
        }

        private void SacarPieza()
        {
            _cantidad--;
            ActualizarTexto();
        }

        private void ActualizarTexto()
        {
            _getTexto.text = $"{_cantidad}";
        }
    }
}
