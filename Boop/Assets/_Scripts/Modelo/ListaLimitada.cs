using System.Collections.Generic;

namespace Boop
{
    public class ListaLimitada<TTipo> where TTipo : class
    {
        private List<TTipo> _lista;
        private int _limite;

        public ListaLimitada(List<TTipo> lista, int limite)
        {
            _lista = lista;
            _limite = limite;
        }

        public bool Agregar(TTipo elemento)
        {
            if (_lista.Count >= _limite)
                return false;

            _lista.Add(elemento);
            return true;
        }

        public bool Eliminar()
        {
            if (_lista.Count <= 0)
                return false;

            _lista.RemoveAt(0);
            return true;
        }
    }
}