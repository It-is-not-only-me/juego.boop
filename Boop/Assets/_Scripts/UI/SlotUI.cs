using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Boop.UI
{
    public class SlotUI : MonoBehaviour, IDropHandler
    {
        private int _columna, _fila;

        public void Inicializar(int columna, int fila)
        {
            _columna = columna;
            _fila = fila;
        }

        public void OnDrop(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
