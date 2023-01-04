using Boop.Evento;
using Boop.Modelo;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.UI
{

    public class SlotInventarioUI : SlotUI
    {
        [SerializeField] private EventoVoid _eventoAgregarPiezaDeInventario;
        [SerializeField] private EventoVoid _eventoTerminarJugada;

        [SerializeField] private GameObject _piezaPrefab;
        [SerializeField] private Transform _posicion;

        [Space]

        [SerializeField] private EventoVoid _eventoSacarPiezaDeInventario;

        [Space]

        [SerializeField] private EventoVoid _eventoReiniciar;

        private int _cantidad = 0;
        private bool _seNecesitaRegenerar = false;


        private void OnEnable()
        {
            if (_eventoAgregarPiezaDeInventario != null)
                _eventoAgregarPiezaDeInventario.Evento += Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento += RegenerarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento += Reiniciar;
        }

        private void OnDisable()
        {
            if (_eventoAgregarPiezaDeInventario != null)
                _eventoAgregarPiezaDeInventario.Evento -= Agregar;

            if (_eventoTerminarJugada != null)
                _eventoTerminarJugada.Evento -= RegenerarPieza;

            if (_eventoReiniciar != null)
                _eventoReiniciar.Evento -= Reiniciar;
        }

        private void Agregar()
        {
            _cantidad++;
            if (_cantidad == 1)
                CrearPieza();

            _seNecesitaRegenerar = false;
        }

        public override void Sacar()
        {
            if (_cantidad <= 0)
                return;
            
            _cantidad--;
            _seNecesitaRegenerar = true;
            _eventoSacarPiezaDeInventario?.Invoke();
        }

        private void RegenerarPieza()
        {
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

        public override void Reiniciar()
        {
            _cantidad = 0;
            _seNecesitaRegenerar = false;

            while (_posicion.childCount > 0)
                if (Application.isEditor)
                    DestroyImmediate(_posicion.GetChild(0).gameObject);
                else
                    Destroy(_posicion.GetChild(0).gameObject);
        }
    }
}
