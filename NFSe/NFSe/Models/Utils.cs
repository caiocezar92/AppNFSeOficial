using System;
using static NFSe.Models.Enum.Enums;

namespace NFSe.Models
{
    /// <summary>
    /// Classe de Utilitários
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Arredonda Valor - 2 Casas Decimais
        /// </summary>
        /// <param name="valor"></param>
        public void ArredValor2(decimal valor)
        {
            Math.Round(valor, 2);
        }

        #region Tratativas Código do Serviço

        /// <summary>
        /// Retira Ponto do Código de Serviço Informado 
        /// </summary>
        /// <param name="codigoServico"></param>
        /// <returns></returns>
        public string RetiraPontoCodigoServico(string codigoServico)
        {
            if (!String.IsNullOrEmpty(codigoServico))
                codigoServico.Replace(".", "");

            return codigoServico.Trim();
        }

        /// <summary>
        /// Adiciona Zero a Esquerda no código de Serviço informado
        /// </summary>
        /// <param name="codigoServico"></param>
        /// <returns></returns>
        public string AdicionaZeroEsquerda(string codigoServico)
        {
            if (!String.IsNullOrEmpty(codigoServico))
            {
                if (codigoServico.Length.Equals(3))
                    codigoServico.PadLeft(4, '0');
                else
                    codigoServico.PadLeft(5, '0');
            }

           return codigoServico.Trim();
        }
        /// <summary>
        /// Retira zero a esquerda
        /// </summary>
        /// <param name="codigoServico"></param>
        /// <returns></returns>
        public string RetiraZeroEsquerda(string codigoServico)
        {
            if (!String.IsNullOrEmpty(codigoServico))
                codigoServico.TrimStart('0');

            return codigoServico.Trim();
        }


        #endregion Tratativas Código do Serviço
        /// <summary>
        /// Método para verificar para enviar o código cnae
        /// </summary>
        /// <param name="codigoMun"></param>
        /// <returns></returns>
        public bool EnviaCodigoCnae(string codigoMun)
        {
            bool enviaCnae = (codigoMun.Equals(Municipios.RioDeJaneiro));

            return enviaCnae;
        }

        public bool EnviaDadosObra()
        {
            //if()
            // chamar método de tratativa das obras

            return true;
        }

    }
}
