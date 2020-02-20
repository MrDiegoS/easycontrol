using easycontrol.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easycontrol.Models.DAO
{
    public class USUARIODAO
    {
        private readonly Context.Context _context = new Context.Context();
        private readonly  Hash _HASH = new Hash(); 

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
                _USUARIO.SENHA = _HASH.Criptografar(SENHA);
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
                throw new Exception(e.Message, e);
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

                if (_USUARIO != null)
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
                throw new Exception(e.Message, e);
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

                if (_USUARIO != null)
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
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>CONSULTAR O USUARIO</summary>
        /// <param name="USER">USUARIO A SER PESQUISADO</param>
        /// <returns>USUARIO</returns>
        public USUARIO ConsultarUsuario(string USER)
        {
            try
            {
                return _context.USUARIOs.Where(x => x.USER == USER).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>VALIDAR ACESSO</summary>
        /// <param name="USER">USUARIO A SER COMPARADO</param>
        /// <param name="SENHA">SENHA A SER COMPARADA</param>
        /// <returns>USUARIO</returns>
        public USUARIO ValidarAcesso(string USER, string SENHA)
        {
            try
            {
                USUARIO _USUARIO = new USUARIO();
                
                //Busca usuário correspondente no banco
                _USUARIO = ConsultarUsuario(USER);

                //Valida se busca resultou informações
                if(_USUARIO != null)
                {
                    //Compara a senha informada com a existente
                    if(_HASH.ValidarSenha(SENHA,_USUARIO.SENHA))
                    {
                        return _USUARIO;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}