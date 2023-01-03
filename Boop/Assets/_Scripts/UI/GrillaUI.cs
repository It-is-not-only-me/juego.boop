using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Boop.UI
{
    [RequireComponent(typeof(RectTransform), typeof(GridLayoutGroup))]
    public class GrillaUI : MonoBehaviour
    {
        [SerializeField] private ConfiguracionGrilla _configuracion;
        [SerializeField] private GameObject _slotPrefab;

        private RectTransform _rectTransform;
        private RectTransform _getRectTransfrom
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();
                return _rectTransform;
            }
        }

        private GridLayoutGroup _gridLayout;
        private GridLayoutGroup _getGridLayout
        {
            get
            {
                if (_gridLayout == null)
                    _gridLayout = GetComponent<GridLayoutGroup>();
                return _gridLayout;
            }
        }

        [ContextMenu("Recalcular tablero")]
        private void GenerarTablero()
        {
            EliminarInformacionExistente();

            _getGridLayout.padding = _configuracion.Padding;
            _getGridLayout.spacing = _configuracion.Espaciado;
            _getGridLayout.childAlignment = TextAnchor.MiddleCenter;
            _getGridLayout.cellSize = TamanioSlots(_configuracion.Columnas,
                                                   _configuracion.Filas,
                                                   _getRectTransfrom.sizeDelta,
                                                   _configuracion.Padding,
                                                   _configuracion.Espaciado);

            for (int i = 0; i < _configuracion.Columnas; i++)
                for (int j = 0; j < _configuracion.Filas; j++)
                {
                    GameObject slotGameObject = Instantiate(_slotPrefab, transform);
                    slotGameObject.name = $"Slot ({i}-{j})";

                    SlotTableroUI slot = slotGameObject.GetComponent<SlotTableroUI>();
                    slot.Inicializar(i, j);
                }

        }

        private Vector2 TamanioSlots(int columnas, int filas, Vector2 dimensiones, RectOffset padding, Vector2 espaciado)
        {
            float x = TamanioSlotsUnaDimension(columnas, dimensiones.x, padding.horizontal, espaciado.x);
            float y = TamanioSlotsUnaDimension(filas, dimensiones.y, padding.vertical, espaciado.y);

            return new Vector2(x, y);
        }

        private float TamanioSlotsUnaDimension(int cantidad, float dimension, float padding, float espaciado)
        {
            float ocupadaPorEspaciado = espaciado * (cantidad - 1);
            float dimensionReducida = dimension - padding - ocupadaPorEspaciado;
            return dimensionReducida / cantidad;
        }

        private void EliminarInformacionExistente()
        {
            while (transform.childCount > 0)
            {
                if (Application.isEditor)
                    DestroyImmediate(transform.GetChild(0).gameObject);
                else
                    Destroy(transform.GetChild(0).gameObject);
            }            
        }

    }
}