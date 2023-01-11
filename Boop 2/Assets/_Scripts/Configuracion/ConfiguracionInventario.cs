using UnityEngine;

namespace Boop.Configuracion
{
    [CreateAssetMenu(fileName = "Configuracion inventario", menuName = "Boop/Configuracion/Inventario")]
    public class ConfiguracionInventario : ConfiguracionGuardable
    {
        [System.Serializable]
        private struct Datos
        {
            public int CantidadMaximaGatitos, CantidadMaximaGatos;
        }

        [SerializeField] private int _cantidadMaximaGatitos, _cantidadMaximaGatos;

        public int CantidadMaximaGatitos
        {
            get => _cantidadMaximaGatitos;
            set
            {
                _cantidadMaximaGatitos = value;
                GuardarInfo();
            }
        }

        public int CantidadMaximaGatos
        {
            get => _cantidadMaximaGatos;
            set
            {
                _cantidadMaximaGatos = value;
                GuardarInfo();
            }
        }

        private Datos _datosActuales;

        protected override string ProducirJson()
        {
            _datosActuales = new Datos
            {
                CantidadMaximaGatitos = _cantidadMaximaGatitos,
                CantidadMaximaGatos = _cantidadMaximaGatos
            };

            return JsonUtility.ToJson(_datosActuales);
        }

        protected override void RecibirJson(string datos)
        {
            _datosActuales = JsonUtility.FromJson<Datos>(datos);

            _cantidadMaximaGatitos = _datosActuales.CantidadMaximaGatitos;
            _cantidadMaximaGatos = _datosActuales.CantidadMaximaGatos;
        }
    }
}