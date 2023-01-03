using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Evento;

namespace Boop.UI
{

    public class SlotTableroUI : SlotUI, IDropHandler
    {
        [SerializeField] private EventoVoid EventoInicializar;

        [Space]

        [SerializeField] private EventoMovimiento _eventoMoverPieza;
        
        private int _posicionX, _posicionY;

        private PiezaUI _piezaUI;

        private void OnEnable()
        {
            if (_eventoMoverPieza != null)
                _eventoMoverPieza.Evento += MoverPieza;
        }

        private void OnDisable()
        {
            if (_eventoMoverPieza != null)
                _eventoMoverPieza.Evento -= MoverPieza;
        }

        public void Inicializar(int x, int y)
        {
            _posicionX = x;
            _posicionY = y;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject objeto = eventData.pointerDrag;
            if (!objeto.TryGetComponent(out _piezaUI))
                return;

            SetearPieza();
        }

        private void InicializarPieza()
        {
            _piezaUI.Inicializar(_posicionX, _posicionY);
        }

        public override void Sacar()
        {
            _piezaUI = null;
            EventoInicializar.Evento -= InicializarPieza;
        }

        private void MoverPieza(PiezaUI piezaUI, int x, int y)
        {
            if (_posicionX != x || _posicionY != y)
                return;

            _piezaUI = piezaUI;
            SetearPieza();
        }

        private void SetearPieza()
        {
            _piezaUI.SetSlot(this);
            EventoInicializar.Evento += InicializarPieza;
        }
    }
}
