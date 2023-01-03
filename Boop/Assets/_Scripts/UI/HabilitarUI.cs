using UnityEngine;
using Boop.Evento;
using System.Collections.Generic;

namespace Boop.UI
{
    public class HabilitarUI : MonoBehaviour
    {
        [SerializeField] private EventoBool _eventoHabilitar;
        [SerializeField] private List<GameObject> _objetos;

        private void OnEnable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento += ActualizarHabilitacion;
        }

        private void OnDisable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento -= ActualizarHabilitacion;
        }

        private void ActualizarHabilitacion(bool estado)
        {
            foreach (GameObject objeto in _objetos)
                objeto.SetActive(estado);
        }
    }
}
