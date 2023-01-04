using UnityEngine;
using Boop.Evento;
using System.Collections.Generic;

namespace Boop.UI
{
    public class HabilitarUI : MonoBehaviour
    {
        [SerializeField] private EventoVoid _eventoHabilitar, _eventoDeshabilitar;
        [SerializeField] private List<GameObject> _objetos;

        private void OnEnable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento += Habilitar;

            if (_eventoDeshabilitar != null)
                _eventoDeshabilitar.Evento += Deshabilitar;
        }

        private void OnDisable()
        {
            if (_eventoHabilitar != null)
                _eventoHabilitar.Evento -= Habilitar;

            if (_eventoDeshabilitar != null)
                _eventoDeshabilitar.Evento -= Deshabilitar;
        }

        private void Habilitar() => ActualizarHabilitacion(true);

        private void Deshabilitar() => ActualizarHabilitacion(false);

        private void ActualizarHabilitacion(bool estado)
        {
            foreach (GameObject objeto in _objetos)
                objeto.SetActive(estado);
        }
    }
}
