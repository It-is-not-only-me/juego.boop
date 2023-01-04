using Boop.Configuracion;
using Boop.Evento;
using Boop.Manager;
using UnityEngine;

namespace Boop.Bahaviour
{
    public class EscenaBehavouir : MonoBehaviour
    {
        [SerializeField] private EventoVoid _eventoCambiarEscene;
        [SerializeField] private EscenaManager _escenaManager;
        [SerializeField] private ConfiguracionEscena _escena;

        private void OnEnable()
        {
            if (_eventoCambiarEscene != null)
                _eventoCambiarEscene.Evento += CambiarEscena;
        }

        private void OnDisable()
        {
            if (_eventoCambiarEscene != null)
                _eventoCambiarEscene.Evento -= CambiarEscena;
        }

        private void CambiarEscena()
        {
            _escenaManager?.CambiarAEscena(_escena);
        }
    }
}
