using easycontrol.Models.Context;
using easycontrol.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace easycontrol.Areas.Admin.models.DAO
{
    public class USUARIODAO
    {
        private readonly Context _context = new Context();
        private readonly Hash _HASH = new Hash();

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
        public int InserirUsuario(USUARIO _usuario)
        {
            try
            {
                //DEFINE VARIAVEL 
                USUARIO _USUARIO = new USUARIO();

                //Pesquisa usuário com o mesmo user
                _USUARIO = _context.USUARIOs.Where(x => x.USER.ToLower() == _usuario.USER.ToLower()).FirstOrDefault();

                if (_USUARIO == null)
                {
                    //Limpando sujeira da variavel
                    _USUARIO = new USUARIO();

                    //ATRIBUINDO OS VALORES PARA OBJETO
                    _USUARIO.NOME = _usuario.NOME;
                    _USUARIO.USER = _usuario.USER;
                    _USUARIO.SENHA = _HASH.Criptografar(_usuario.SENHA);
                    _USUARIO.EMAIL = _usuario.EMAIL;
                    _USUARIO.ADMIN = _usuario.ADMIN;
                    _USUARIO.DTCADASTRO = DateTime.Now;
                    _USUARIO.DTALTERACAO = DateTime.Now;

                    //ADICIONANDO OS VALORES AO CONTEXTO
                    _context.USUARIOs.Add(_USUARIO);

                    //SALVANDO MUDANÇAS
                    _context.SaveChanges();

                    return _USUARIO.ID;
                }
                return 0;
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
        /// <param name="EMAIL">EMAIL DO USUARIO</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool AlterarUsuario(USUARIO _USER)
        {
            try
            {
                //DEFINE VARIAVEL 
                USUARIO _USUARIO = new USUARIO();

                //CARREGANDO AS INFORMAÇÕES EXISTENTE
                _USUARIO = _context.USUARIOs.Where(x => x.ID == _USER.ID).FirstOrDefault();

                if (_USUARIO != null)
                {
                    //ATRIBUINDO OS VALORES PARA OBJETO
                    _USUARIO.NOME = _USER.NOME;
                    _USUARIO.USER = _USER.USER;
                    _USUARIO.EMAIL = _USER.EMAIL;
                    _USUARIO.ADMIN = _USER.ADMIN;
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

                _USUARIO = _context.USUARIOs.Where(x => x.ID == ID).FirstOrDefault();

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
                if (_USUARIO != null)
                {
                    //Compara a senha informada com a existente
                    if (_HASH.ValidarSenha(SENHA, _USUARIO.SENHA))
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

        /// <summary>LISTA OS USUÁRIOS</summary>
        /// <returns>LISTA DE USUÁRIOS</returns>
        public List<USUARIO> ListarUser()
        {
            try
            {
                //DEFINE VARIAVEL 
                List<USUARIO> _USUARIO = new List<USUARIO>();

                _USUARIO = _context.USUARIOs.ToList();

                if (_USUARIO != null) return _USUARIO;

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>BUSCA O USUÁRIO POR ID OU USER</summary>
        /// <param name="_USUARIO">USUARIO A SER BUSCADO</param>
        /// <returns>RETORNAR USUARIO</returns>
        public USUARIO PesquisarUsuario(USUARIO _USUARIO)
        {
            try
            {
                if (_USUARIO.ID > 0)
                {
                    return _context.USUARIOs.Where(x => x.ID == _USUARIO.ID).FirstOrDefault();
                }
                else
                {
                    return _context.USUARIOs.Where(x => x.USER.ToLower() == _USUARIO.USER.ToLower()).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}