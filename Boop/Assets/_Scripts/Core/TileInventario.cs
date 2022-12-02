using Boop.Evento;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.Core
{
    [RequireComponent(typeof(RectTransform))]
    public class TileInventario : MonoBehaviour, IDropHandler, ITile
    {
        [Header("Eventos")]
        [SerializeField] private EventoVoid _sacarPieza;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            if (!eventData.pointerDrag.TryGetComponent(out Pieza pieza))
                return;

            UsarPieza(pieza);
        }

        public void UsarPieza(Pieza pieza)
        {
            pieza.PosicionarTile(this);
            pieza.Posicion.anchoredPosition = _rectTransform.anchoredPosition;
        }

        public void SacarPieza(Pieza pieza)
        {
            _sacarPieza?.Invoke();
        }
    }
}
