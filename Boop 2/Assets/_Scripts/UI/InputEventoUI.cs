using Boop.Evento;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class InputEventoUI : MonoBehaviour
{
    [SerializeField] private EventoString _eventoNombre;

    [Space]

    [SerializeField] private EventoString _eventoNombreActual;

    private TMP_InputField _inputField;
    private TMP_InputField _getInputField
    {
        get
        {
            if (_inputField == null)
                _inputField = GetComponent<TMP_InputField>();
            return _inputField;
        }
    }

    private void OnEnable()
    {
        if (_eventoNombreActual != null)
            _eventoNombreActual.Evento += ActualizarNombre;

        _getInputField.onValueChanged.AddListener(MandarNombre);
    }

    private void OnDisable()
    {
        if (_eventoNombreActual != null)
            _eventoNombreActual.Evento -= ActualizarNombre;

        _getInputField.onValueChanged.RemoveListener(MandarNombre);
    }

    private void ActualizarNombre(string nombre)
    {
        _getInputField.text = nombre;
    }

    private void MandarNombre(string nombre)
    {
        _getInputField.text = nombre;
        _eventoNombre?.Invoke(nombre);
    }
}
