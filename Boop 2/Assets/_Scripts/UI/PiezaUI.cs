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
        [SerializeField] private EventoVoid _eventoTerminarTurno;

        [Space]

        [SerializeField] private EventoCoordenada _eventoAgregarPieza;

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

        private int _posicionX, _posicionY;
        private SlotUI _slot;
        private Transform _padre;
        private bool _moverPieza = false;

        public void Inicializar(SlotUI slot) => _slot = slot;

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
            _getImagen.raycastTarget = true;
            transform.SetParent(_padre);
        }

        public void SetearCoordenada(int x, int y)
        {
            _posicionX = x;
            _posicionY = y;

            if (_eventoTerminarTurno != null && !_moverPieza)
            {
                _moverPieza = true;
                _eventoTerminarTurno.Evento += AsignarPosicion;
            }
        }

        public void SetearPadre(SlotUI slot)
        {
            _slot?.Sacar();
            _slot = slot;
            _padre = _slot.transform;
            transform.SetParent(_padre);
        }

        public void Eliminar()
        {
            Destroy(gameObject);
        }

        private void AsignarPosicion()
        {
            _eventoAgregarPieza?.Invoke(_posicionX, _posicionY);
            _getImagen.raycastTarget = false;
            
            if (_eventoTerminarTurno != null)
                _eventoTerminarTurno.Evento -= AsignarPosicion;
        }
    }
}
