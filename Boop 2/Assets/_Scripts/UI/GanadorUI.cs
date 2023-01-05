using Boop.Configuracion;
using TMPro;
using UnityEngine;

namespace Boop.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GanadorUI : MonoBehaviour
    {
        [SerializeField] private ConfiguracionGanador _configuracion;

        private TextMeshProUGUI _texto;
        private TextMeshProUGUI _getTexto
        {
            get
            {
                if (_texto == null)
                    _texto = GetComponent<TextMeshProUGUI>();
                return _texto;
            }
        }

        private void Start()
        {
            _getTexto.text = _configuracion.Ganador;
        }
    }
}
