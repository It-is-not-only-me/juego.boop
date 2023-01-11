using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion ganador", menuName = "Boop/Configuracion/Ganador")] 
    public class ConfiguracionGanador : ConfiguracionGuardable
    {
        [System.Serializable]
        private struct Datos
        {
            public string NombreGanador1, NombreGanador2;
        }

        [SerializeField] private string _nombreGanador1, _nombreGanador2;

        private string _nombreGanador;
        public string Ganador => _nombreGanador;

        public void GanoJugador1() => _nombreGanador = _nombreGanador1;

        public void GanoJugador2() => _nombreGanador = _nombreGanador2;

        public string NombreGanador1
        {
            get => _nombreGanador1;
            set
            {
                _nombreGanador1 = value;
                GuardarInfo();
            }
        }

        public string NombreGanador2
        {
            get => _nombreGanador2;
            set
            {
                _nombreGanador2 = value;
                GuardarInfo();
            }
        }

        private Datos _datosActuales;

        protected override string ProducirJson()
        {
            _datosActuales = new Datos
            {
                NombreGanador1 = _nombreGanador1,
                NombreGanador2 = _nombreGanador2
            };

            return JsonUtility.ToJson(_datosActuales);
        }

        protected override void RecibirJson(string datos)
        {
            _datosActuales = JsonUtility.FromJson<Datos>(datos);

            _nombreGanador1 = _datosActuales.NombreGanador1;
            _nombreGanador2 = _datosActuales.NombreGanador2;
        }
    }
}