using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;

namespace Boop.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class SlotTableroUI : SlotUI, IDropHandler
    {
        private int _posicionX, _posicionY;
        private PiezaUI _pieza;

        private void Start()
        {
            _pieza = null;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject objeto = eventData.pointerDrag;
            if (!objeto.TryGetComponent(out PiezaUI pieza))
                return;

            if (_pieza != null && pieza == _pieza)
                return;

            SetearPieza(pieza);
        }

        public void Inicializar(int x, int y)
        {
            _posicionX = x;
            _posicionY = y;
        }

        public void Eliminar()
        {
            _pieza.Eliminar();
            _pieza = null;
        }

        public override void Sacar()
        {
            _pieza = null;
        }

        public void Transladar(SlotTableroUI slotFinal)
        {
            if (slotFinal == this)
                return;
            
            slotFinal.SetearPieza(_pieza);
            _pieza = null;
        }

        private void SetearPieza(PiezaUI pieza)
        {
            _pieza = pieza;
            _pieza.SetearPadre(this);
            _pieza.SetearCoordenada(_posicionX, _posicionY);
        }
    }
}
