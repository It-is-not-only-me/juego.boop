using UnityEngine;
using Boop.Configuracion;
using Boop.Core;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

namespace Boop.Generador
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    public class GenerarTablero : MonoBehaviour
    {
        [Header("Configuracion")]
        [SerializeField] private ConfiguracionDimensionSO _dimensiones;
        [SerializeField] private float _espaciado = 20f;

        [Space]

        [Header("Tile")]
        [SerializeField] private Tile _tilePrefab;

        private VerticalLayoutGroup _layout;

        private void Awake()
        {
            _layout = GetComponent<VerticalLayoutGroup>();

            _layout.spacing = _espaciado;

            for(int i = 0; i < _dimensiones.Alto; i++)
            {
                GameObject nivel = new GameObject($"Nivel ({i})", typeof(RectTransform), typeof(HorizontalLayoutGroup), typeof(CanvasGroup));
                nivel.transform.SetParent(transform);
                HorizontalLayoutGroup horizontalLayout = nivel.GetComponent<HorizontalLayoutGroup>();
                nivel.GetComponent<CanvasGroup>().blocksRaycasts = false;

                horizontalLayout.spacing = _espaciado;
                horizontalLayout.childControlHeight = false;
                horizontalLayout.childControlWidth = false;

                for (int j = 0; j < _dimensiones.Ancho; j++)
                {
                    Tile tile = Instantiate(_tilePrefab, nivel.transform);
                    tile.IniciarlizarPosicion(new Vector2Int(i, j));
                    tile.AddComponent<CanvasGroup>().ignoreParentGroups = true;
                }
            }
        }

    }
}
