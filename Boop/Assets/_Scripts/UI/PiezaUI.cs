using Boop.Modelo;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class PiezaUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private IPieza _pieza;
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

        public void EstablecerPieza(IPieza pieza) => _pieza = pieza;

        public void Inicializar(int x, int y)
        {
            _pieza?.EstablecerTablero(x, y);
            _getImagen.raycastTarget = false;
            _posicionado = true;
        }

        public void SetSlot(SlotUI slot)
        {
            _slot?.Sacar();
            _slot = slot;
            _padre = slot.transform;
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
