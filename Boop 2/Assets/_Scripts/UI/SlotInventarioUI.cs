using Boop.Evento;
using Boop.Modelo;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.UI
{

    public class SlotInventarioUI : SlotUI, IDropHandler
    {
        [SerializeField] private EventoVoid _eventoAgregarPiezaDeInventario;
        [SerializeField] private EventoVoid _eventoTerminarJugada;

        [SerializeField] private GameObject _piezaPrefab;
        [SerializeField] private Transform _posicion;

        [Space]

        [SerializeField] private EventoVoid _eventoSacarPiezaDeInventario;

        [SerializeField] private EventoVoid _eventoAgregaSlot;
        [SerializeField] private EventoVoid _eventoSacarSlot;

        private int _cantidad = 0;
        private bool _seNecesitaRegenerar = false;

        private void Awake()
        {
            _cantidad = 0;
            _seNecesitaRegenerar = false;
        }

        private void OnEnable()
        {
            if (_eventoAgregarPiezaDeInventario != null)
                _eventoAgregarPiezaDeInventario.Evento += Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento += RegenerarPieza;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPiezaDeInventario != null)
                _eventoAgregarPiezaDeInventario.Evento -= Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento -= RegenerarPieza;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject objeto = eventData.pointerDrag;
            if (!objeto.TryGetComponent(out PiezaUI pieza))
                return;

            pieza.SetearPadre(this, _posicion);
            Agregar();
        }

        private void Agregar()
        {
            _cantidad++;
            if (_cantidad == 1)
                CrearPieza();

            _seNecesitaRegenerar = false;
            _eventoAgregaSlot?.Invoke();    
        }

        public override void Sacar()
        {
            if (_cantidad <= 0)
                return;
            
            _cantidad--;
            _seNecesitaRegenerar = true;
            _eventoSacarSlot?.Invoke();
        }

        private void RegenerarPieza()
        {
            if (_seNecesitaRegenerar)
                _eventoSacarPiezaDeInventario?.Invoke();

            if (_cantidad > 0 && _seNecesitaRegenerar)
                CrearPieza();

            _seNecesitaRegenerar = false;
        }

        private void CrearPieza()
        {
            GameObject piezaGO = Instantiate(_piezaPrefab, _posicion);            
            PiezaUI piezaUI = piezaGO.GetComponent<PiezaUI>();
            piezaUI.Inicializar(this);
        }
    }
}
