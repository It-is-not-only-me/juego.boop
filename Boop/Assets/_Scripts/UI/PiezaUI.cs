using Boop.Evento;
using Boop.Modelo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class PiezaUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private EventoCoordenada _eventoSacarPieza;
        [SerializeField] private EventoTransladar _eventoTransladarPieza;

        [Space]

        [SerializeField] private EventoMovimiento _eventoMoverPieza;

        private IPieza _pieza;
        private int _posicionX = -1, _posicionY = -1;
        private bool _posicionado;

        private SlotUI _slot;
        private Transform _padre;
        
        private Canvas _canvas;
        private Canvas _getCanvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = transform.root.GetComponent<Canvas>();
                return _canvas;
            }
        }

        private Image _imagen;
        private Image _getImagen
        {
            get
            {
                if (_imagen == null)
                    _imagen = GetComponent<Image>();
                return _imagen;
            }
        }

        private RectTransform _rectTransform;
        private RectTransform _getRectTransform
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            }
        }

        private void OnEnable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;

            if (_eventoTransladarPieza != null)
                _eventoTransladarPieza.Evento += TransladarPieza;
        }

        private void OnDisable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento -= SacarPieza;

            if (_eventoTransladarPieza != null)
                _eventoTransladarPieza.Evento -= TransladarPieza;
        }

        public void EstablecerPieza(IPieza pieza) => _pieza = pieza;

        public void Inicializar(int x, int y)
        {
            _pieza?.EstablecerTablero(x, y);
            _posicionX = x;
            _posicionY = y;

            _getImagen.raycastTarget = false;
            _posicionado = true;
        }

        public void SetSlot(SlotUI slot)
        {
            _slot?.Sacar();
            _slot = slot;
            _padre = slot.transform;
        }

        private void SacarPieza(int x, int y)
        {
            if (_posicionX != x || _posicionY != y)
                return;

            _slot?.Sacar();
            Destroy(this);
        }

        private void TransladarPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
        {
            if (_posicionX != xOriginal || _posicionY != yOriginal)
                return;

            _slot?.Sacar();
            _eventoMoverPieza?.Invoke(this, xFinal, yFinal);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _getImagen.raycastTarget = false;
            _padre = transform.parent;
            
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _getRectTransform.anchoredPosition += eventData.delta / _getCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.SetParent(_padre);
            if (!_posicionado)
                _imagen.raycastTarget = true;
        }
    }
}
