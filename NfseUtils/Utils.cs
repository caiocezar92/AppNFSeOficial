using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NfseUtils
{
    public class Utils
    {
        public void ArredValor2Casas(decimal valor)
        {
            Math.Round(valor, 2);
        }
    }
}
