using UnityEngine;
using Boop.Evento;

namespace Boop.UI
{
    public class HabilitarUI : MonoBehaviour
    {
        [SerializeField] private EventoVoid _eventoHabilitar;
        [SerializeField] private bool _estadoActual = true;

        private void Awake()
        {
            Habilitar(_estadoActual);
        }

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

        private void ActualizarHabilitacion()
        {
            _estadoActual = !_estadoActual;
            Habilitar(_estadoActual);
        }

        private void Habilitar(bool nuevoEstado)
        {
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.SetActive(nuevoEstado);
        }
    }
}
