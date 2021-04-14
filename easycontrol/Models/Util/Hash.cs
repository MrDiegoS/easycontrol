using System;

namespace easycontrol.Models.Util
{
    public class Hash
    {

        public Hash()
        {

        }

        /// <summary>CRIPTOGRAFA UM TEXTO</summary>
        /// <param name="TEXTO">TEXTO A SER CRIPTOGRAFADO</param>
        /// <returns>O TEXTO CRIPTOGRAFADO</returns>
        public string Criptografar(string TEXTO)
        {
            Byte[] cript = System.Text.ASCIIEncoding.ASCII.GetBytes(TEXTO);
            return Convert.ToBase64String(cript);
        }

        /// <summary>DESCRIPTOGRAFA UM TEXTO</summary>
        /// <param name="TEXTO">TEXTO A SER DESCRIPTOGRAFADO</param>
        /// <returns>O TEXTO DESCRIPTOGRAFADO</returns>
        public string Descriptografar(string TEXTO)
        {
            Byte[] cript = Convert.FromBase64String(TEXTO);
            return System.Text.ASCIIEncoding.ASCII.GetString(cript);
        }

        /// <summary>COMPARA A SENHA CRIPTOGRAFADA COM A NOVA</summary>
        /// <param name="SENHADIGITADA">SENHA INSERIDA</param>
        /// <param name="SENHACADASTRADA">SENHA EXISTENTE</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool ValidarSenha(string SENHADIGITADA, string SENHACADASTRADA)
        {
            return Criptografar(SENHADIGITADA) == SENHACADASTRADA;
        }

    }
}

