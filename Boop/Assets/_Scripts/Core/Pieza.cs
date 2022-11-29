using Boop.Configuracion;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.Core
{
    [RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
    public class Pieza : MonoBehaviour, IPieza, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [Header("Configuracion")]
        [SerializeField] private ConfiguracionDatosPiezaSO _datos;
        [SerializeField] private Canvas _canvas;

        [HideInInspector] public RectTransform Posicion;

        private Tile _tileActual = null, _tilePrevio;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            Posicion = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public bool EsIgual(IPieza pieza) => EsIgual(pieza as Pieza);
        private bool EsIgual(Pieza pieza) => _datos.EsIgual(pieza._datos);

        public void PosicionarTile(Tile tile)
        {
            _tileActual = tile;
            _tilePrevio = tile;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _tileActual?.SacarPieza(this);
            _tileActual = null;

            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0.6f;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1f;

            if (_tileActual != null)
                return;
            _tilePrevio?.UsarPieza(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Posicion.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
    }
}
