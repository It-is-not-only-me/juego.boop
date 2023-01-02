using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boop
{
    public interface IRegla
    {
        public void Aplicar(IPieza pieza, int x, int y);
    }
}
