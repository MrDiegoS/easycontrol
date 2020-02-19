using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easycontrol.Models.DAO
{
    public class USUARIODAO
    {
        private readonly Context.Context _context = new Context.Context();

        public USUARIODAO()
        {

        }

        /// <summary>INSERE USUARIO</summary>
        /// <param name="NOME">NOME DO USUARIO</param>
        /// <param name="USER">LOGIN DO USUARIO</param>
        /// <param name="SENHA">SENHA DO USUARIO</param>
        /// <param name="EMAIL">EMAIL DO USUARIO</param>
        /// <param name="ADMIN">FLAG PARA USUARIO ADMIN</param>
        /// <returns>O ID RESULTANTE DA INSERÇÃO</returns>
        public int InserirUsuario(string NOME, string USER, string SENHA, string EMAIL, bool ADMIN)
        {
            try
            {
                //DEFINE VARIAVEL 
                USUARIO _USUARIO = new USUARIO();

                //ATRIBUINDO OS VALORES PARA OBJETO
                _USUARIO.NOME = NOME;
                _USUARIO.USER = USER;
                _USUARIO.SENHA = SENHA;
                _USUARIO.EMAIL = EMAIL;
                _USUARIO.ADMIN = ADMIN;
                _USUARIO.DTCADASTRO = DateTime.Now;
                _USUARIO.DTALTERACAO = DateTime.Now;

                //ADICIONANDO OS VALORES AO CONTEXTO
                _context.USUARIOs.Add(_USUARIO);

                //SALVANDO MUDANÇAS
                _context.SaveChanges();

                return _USUARIO.ID;
            }
            catch (Exception e)
            {
                return 0;
            }

        }


        /// <summary>ALTERA OS DADOS DO USUARIO</summary>
        /// <param name="ID">ID DO REGISTRO A SER ALTERADO</param>
        /// <param name="NOME">NOME DO USUARIO</param>
        /// <param name="USER">LOGIN DO USUARIO</param>
        /// <param name="SENHA">SENHA DO USUARIO</param>
        /// <param name="EMAIL">EMAIL DO USUARIO</param>
        /// <param name="ADMIN">FLAG PARA USUARIO ADMIN</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool ALterarUsuario(int ID, string NOME, string USER, string SENHA, string EMAIL, bool ADMIN)
        {
            try
            {
                //DEFINE VARIAVEL 
                USUARIO _USUARIO = new USUARIO();

                //CARREGANDO AS INFORMAÇÕES EXISTENTE
                _USUARIO = _context.USUARIOs.Where(x => x.ID == ID).FirstOrDefault();

                if (_USUARIO.ID != 0)
                {
                    //ATRIBUINDO OS VALORES PARA OBJETO
                    _USUARIO.NOME = NOME;
                    _USUARIO.USER = USER;
                    _USUARIO.SENHA = SENHA;
                    _USUARIO.EMAIL = EMAIL;
                    _USUARIO.ADMIN = ADMIN;
                    _USUARIO.DTALTERACAO = DateTime.Now;

                    //SALVANDO MUDANÇAS
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>EXCLUIR USUARIO</summary>
        /// <param name="ID">ID DO REGISTRO A SER EXCLUÍDO</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool ExcluirUsuario(int ID)
        {
            try
            {
                //DEFINE VARIAVEL 
                USUARIO _USUARIO = new USUARIO();

                _context.USUARIOs.Where(x => x.ID == ID).FirstOrDefault();

                if (_USUARIO.ID != 0)
                {
                    //EXCLUINDO O REGISTRO
                    _context.USUARIOs.Remove(_USUARIO);

                    //SALVANDO MUDANÇAS
                    _context.SaveChanges();

                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}