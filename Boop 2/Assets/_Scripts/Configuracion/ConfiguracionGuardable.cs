using System.IO;
using UnityEngine;

namespace Boop.Configuracion
{
    public abstract class ConfiguracionGuardable : ScriptableObject
    {
        [SerializeField] private string _nombre;

        private string Direccion => $"{Application.persistentDataPath}/{_nombre}.txt";

        private void OnEnable() => LoadInfo();


        protected void GuardarInfo()
        {
            string json = ProducirJson();
            File.WriteAllText(Direccion, json);
        }

        protected void LoadInfo()
        {
            if (!File.Exists(Direccion))
                GuardarInfo();

            RecibirJson(File.ReadAllText(Direccion)); 
        }

        protected abstract string ProducirJson();

        protected abstract void RecibirJson(string datos);

    }
}