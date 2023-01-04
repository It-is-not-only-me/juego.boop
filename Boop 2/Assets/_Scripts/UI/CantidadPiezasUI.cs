using Boop.Evento;
using UnityEngine;
using TMPro;

namespace Boop.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CantidadPiezasUI : MonoBehaviour, IReiniciable
    {
        [SerializeField] private EventoVoid _eventoAgregarPieza, _eventoSacarPieza;

        [Space]

        [SerializeField] private EventoVoid _eventoReiniciar;

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

        private void OnEnable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento += AgregarPieza;

            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento += Reiniciar;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPieza != null)
                _eventoAgregarPieza.Evento -= AgregarPieza;

            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento -= SacarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento -= Reiniciar;
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

        public void Reiniciar()
        {
            _cantidad = 0;
            ActualizarTexto();
        }

        private void ActualizarTexto()
        {
            _getTexto.text = $"{_cantidad}";
        }
    }
}
