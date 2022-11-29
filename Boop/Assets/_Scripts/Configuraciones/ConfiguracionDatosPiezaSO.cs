using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Datos pieza", menuName = "Boop/Configuracion/Datos pieza")]
    public class ConfiguracionDatosPiezaSO : ScriptableObject
    {
        private enum TipoPieza
        {
            GatitoJudaor1,
            GatoJugador1,
            GatitoJugador2,
            GatoJugador2
        }

        [SerializeField] private TipoPieza _tipoPieza;

        public bool EsIgual(ConfiguracionDatosPiezaSO datosPieza) => _tipoPieza == datosPieza._tipoPieza;
    }
}
