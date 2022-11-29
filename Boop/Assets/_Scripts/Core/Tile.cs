using Boop.Evento;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.Core
{
    [RequireComponent(typeof(RectTransform))]
    public class Tile : MonoBehaviour, IDropHandler
    {
        [Header("Eventos")]
        [SerializeField] private EventoPosicion _sacarPieza;
        [SerializeField] private EventoPosicion _agregarPieza;

        [Space]

        [Header("Posicion")]
        [SerializeField] private Vector2Int _posicion;

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
            _agregarPieza?.Invoke(_posicion, pieza);
            pieza.Posicion.anchoredPosition = _rectTransform.anchoredPosition;
        }

        public void SacarPieza(Pieza pieza)
        {
            _sacarPieza?.Invoke(_posicion, pieza);
        }
    }
}
