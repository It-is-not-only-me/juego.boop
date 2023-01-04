using UnityEngine;
using UnityEngine.EventSystems;
using Boop.Configuracion;
using Boop.Manager;

namespace Boop.UI
{
    public class BotonEscenaUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EscenaManager _escenaManager;
        [SerializeField] private ConfiguracionEscena _escena;

        public void OnPointerClick(PointerEventData eventData)
        {
            _escenaManager.CambiarAEscena(_escena);
        }
    }
}
