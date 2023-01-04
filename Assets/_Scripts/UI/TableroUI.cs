using Boop.Evento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.UI
{
    public class TableroUI : MonoBehaviour
    {
        [SerializeField] private EventoCoordenada _eventoSacarPieza;
        [SerializeField] private EventoTransladar _eventoTransladar;

        public SlotTableroUI[,] Tablero;

        private void OnEnable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;

            if (_eventoTransladar != null)
                _eventoTransladar.Evento += TransladarPieza;
        }

        private void OnDisable()
        {
            if (_eventoSacarPieza != null)
                _eventoSacarPieza.Evento += SacarPieza;

            if (_eventoTransladar != null)
                _eventoTransladar.Evento += TransladarPieza;
        }

        private void SacarPieza(int x, int y)
        {
            Tablero[x, y].Eliminar();
        }

        private void TransladarPieza(int xOriginal, int yOriginal, int xFinal, int yFinal)
        {
            Tablero[xOriginal, yOriginal].Transladar(Tablero[xFinal, yFinal]);
        }
    }
}
