using Boop.Configuracion;
using System.Collections.Generic;
using UnityEngine;

namespace Boop.Core
{
    [CreateAssetMenu(fileName = "Comprobacion", menuName = "Boop/Core/Comprobacion")]
    public class Comprobacion : ScriptableObject
    {
        [Header("Configuracion")]
        [SerializeField] ConfiguracionDimensionSO _dimensiones;

        [Space]

        [Header("Reglas")]
        [SerializeField] List<ConfiguracionReglaSO> _reglas = new List<ConfiguracionReglaSO>();

        [Space]

        [Header("Tablero")]
        [SerializeField] TableroSO _tablero;

        private List<CumplimientoDeRegla> SeCumplenLasReglas(IPieza pieza)
        {
            List<CumplimientoDeRegla> resultado = new List<CumplimientoDeRegla>();


            for (int i = 1; i < _dimensiones.Ancho - 1; i++)
                for (int j = 1; j < _dimensiones.Alto - 1; j++)
                    foreach (ConfiguracionReglaSO regla in _reglas)
                    {
                        if (!CumpleUnaRegla(pieza, regla, i, j))
                            continue;
                        resultado.Add(new CumplimientoDeRegla(new Vector2Int(i, j), regla));
                    }

            return resultado;
        }

        private bool CumpleUnaRegla(IPieza pieza, ConfiguracionReglaSO regla, int x, int y)
        {
            bool seCumple = true;
            for (int i = 0; i < regla.Ancho; i++)
                for (int j = 0; j < regla.Alto; i++)
                {
                    if (!regla[i, j])
                        continue;
                    seCumple &= pieza.EsIgual(_tablero[x + i - 1, y + j - 1]);
                }

            return seCumple;
        }
    }
}
