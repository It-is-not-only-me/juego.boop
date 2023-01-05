using Boop.Bahaviour;
using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inicio", menuName = "Boop/Configuracion/Inicio")]
    public class ConfiguracionInicio : ConfiguracionGuardable
    {
        [System.Serializable]
        private class Datos
        {
            public int CantidadDeGatitosJugador1, CantidadDeGatosJugador1, CantidadDeGatitosJugador2, CantidadDeGatosJugador2;
            public GameBehaviour.EstadoJuego PrimerJugador;
        }

        [SerializeField] private int _cantidadDeGatitosJugador1, _cantidadDeGatosJugador1;
        [SerializeField] private int _cantidadDeGatitosJugador2, _cantidadDeGatosJugador2;

        [SerializeField] private GameBehaviour.EstadoJuego _primerJugador;

        public int CantidadDeGatitosJugador1
        {
            get => _cantidadDeGatitosJugador1;
            set
            {
                _cantidadDeGatitosJugador1 = value;
                GuardarInfo();
            }
        }

        public int CantidadDeGatosJugador1
        {
            get => _cantidadDeGatosJugador1;
            set 
            {
                _cantidadDeGatosJugador1 = value;
                GuardarInfo();
            }
        }

        public int CantidadDeGatitosJugador2
        {
            get => _cantidadDeGatitosJugador2;
            set 
            {
                _cantidadDeGatitosJugador2 = value;
                GuardarInfo();
            }
        }

        public int CantidadDeGatosJugador2
        {
            get => _cantidadDeGatosJugador2;
            set 
            {
                _cantidadDeGatosJugador2 = value;
                GuardarInfo();
            }
        }

        public GameBehaviour.EstadoJuego PrimerJugador
        {
            get => _primerJugador;
            set 
            {
                _primerJugador = value;
                GuardarInfo();
            }
        }

        private Datos _datosActuales;

        protected override string ProducirJson()
        {
            _datosActuales = new Datos
            {
                CantidadDeGatitosJugador1 = _cantidadDeGatitosJugador1,
                CantidadDeGatosJugador1 = _cantidadDeGatosJugador1,
                CantidadDeGatitosJugador2 = _cantidadDeGatitosJugador2,
                CantidadDeGatosJugador2 = _cantidadDeGatosJugador2,
                PrimerJugador = _primerJugador
            };

            return JsonUtility.ToJson(_datosActuales);
        }

        protected override void RecibirJson(string datos)
        {
            _datosActuales = JsonUtility.FromJson<Datos>(datos);

            _cantidadDeGatitosJugador1 = _datosActuales.CantidadDeGatitosJugador1;
            _cantidadDeGatosJugador1 = _datosActuales.CantidadDeGatosJugador1;
            _cantidadDeGatitosJugador2 = _datosActuales.CantidadDeGatitosJugador2;
            _cantidadDeGatosJugador2 = _datosActuales.CantidadDeGatosJugador2;
            _primerJugador = _datosActuales.PrimerJugador;
        }
    }
}