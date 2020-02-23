using easycontrol.Areas.Admin.Models.DAO;
using easycontrol.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace easycontrol.Areas.Admin.models.DAO
{
    public class FATOR_CALCULODAO
    {
        private readonly Context _context = new Context();


        public FATOR_CALCULODAO()
        {
        }

        /// <summary>INSERE OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <param name="QTD_PARCELAS">QUANTIDADE DE PARCELAS PERMITIDAS</param>
        /// <param name="JUROS_PER">JUROS PERCENTUAL</param>
        /// <param name="JUROS_TIPO">TIPO DO JUROS</param>
        /// <param name="COMISSAO_PER">COMISSÃO SOBRE A DÍVIDA</param>
        /// <returns>O ID RESULTANTE DA INSERÇÃO</returns>
        public int InserirFatorCalculo(FATOR_CALCULO _FATOR)
        {
            try
            {
                //DEFINE VARIAVEL 
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                //ATRIBUINDO OS VALORES PARA OBJETO
                _FATOR_CALCULO.QTD_PARCELAS = _FATOR.QTD_PARCELAS;
                _FATOR_CALCULO.JUROS_PER = _FATOR.JUROS_PER;
                _FATOR_CALCULO.JUROS_TIPO = ((EnumJuros)Convert.ToInt32(_FATOR.JUROS_TIPO)).ToString();
                _FATOR_CALCULO.COMISSAO_PER = _FATOR.COMISSAO_PER;
                _FATOR_CALCULO.DTCADASTRO = DateTime.Now;
                _FATOR_CALCULO.DTALTERACAO = DateTime.Now;

                //ADICIONANDO OS VALORES AO CONTEXTO
                _context.FATOR_CALCULOs.Add(_FATOR_CALCULO);

                //SALVANDO MUDANÇAS
                _context.SaveChanges();

                return _FATOR_CALCULO.ID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }

        /// <summary>ALTERA OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <param name="ID">ID DO REGISTRO A SER ALTERADO</param>
        /// <param name="QTD_PARCELAS">QUANTIDADE DE PARCELAS PERMITIDAS</param>
        /// <param name="JUROS_PER">JUROS PERCENTUAL</param>
        /// <param name="JUROS_TIPO">TIPO DO JUROS</param>
        /// <param name="COMISSAO_PER">COMISSÃO SOBRE A DÍVIDA</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool AlterarFatorCalculo(FATOR_CALCULO _FATOR)
        {
            try
            {
                //DEFINE VARIAVEL 
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                //CARREGANDO AS INFORMAÇÕES EXISTENTE
                _FATOR_CALCULO = _context.FATOR_CALCULOs.Where(x => x.ID == _FATOR.ID).FirstOrDefault();

                if (_FATOR_CALCULO != null)
                {
                    //ATRIBUINDO OS VALORES PARA OBJETO
                    _FATOR_CALCULO.QTD_PARCELAS = _FATOR.QTD_PARCELAS;
                    _FATOR_CALCULO.JUROS_PER = _FATOR.JUROS_PER;
                    _FATOR_CALCULO.JUROS_TIPO = ((EnumJuros)Convert.ToInt32(_FATOR.JUROS_TIPO)).ToString();
                    _FATOR_CALCULO.COMISSAO_PER = _FATOR.COMISSAO_PER;
                    _FATOR_CALCULO.DTALTERACAO = DateTime.Now;

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

        /// <summary>EXCLUIR OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <param name="ID">ID DO REGISTRO A SER EXCLUÍDO</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool ExcluirFatorCalculo(int ID)
        {
            try
            {
                //DEFINE VARIAVEL 
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                _FATOR_CALCULO = _context.FATOR_CALCULOs.Where(x => x.ID == ID).FirstOrDefault();

                if (_FATOR_CALCULO != null)
                {

                    //VERIFICA AMARRAÇÃO COM FATOR CALCULO
                    if (_context.INADIMPLENCIAs.Where(x => x.FATORID == _FATOR_CALCULO.ID).FirstOrDefault() != null)
                    {
                        return false;
                    }

                    //EXCLUINDO O REGISTRO
                    _context.FATOR_CALCULOs.Remove(_FATOR_CALCULO);

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

        /// <summary>BUSCA OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <param name="ID">ID DO REGISTRO A SER BUSCADO</param>
        /// <returns>FATOR CALCULO</returns>
        public FATOR_CALCULO PesquisarFatorCalculo(int ID)
        {
            try
            {
                return _context.FATOR_CALCULOs.Where(x => x.ID == ID).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>LISTA OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <returns>LISTA DE PARÂMETROS PARA CALCULO DA DÍVIDA</returns>
        public List<FATOR_CALCULO> ListarFatorCalculo()
        {
            try
            {
                //DEFINE VARIAVEL 
                List<FATOR_CALCULO> _FATOR_CALCULO = new List<FATOR_CALCULO>();

                _FATOR_CALCULO = _context.FATOR_CALCULOs.ToList();

                if (_FATOR_CALCULO != null) return _FATOR_CALCULO;

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        //Listas dos tipos de juros
        public enum EnumJuros
        {
            Simples = 1,
            Composto = 2
        }
    }
}