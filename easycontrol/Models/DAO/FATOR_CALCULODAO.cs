using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace easycontrol.Models.DAO
{
    public class FATOR_CALCULODAO
    {
        private readonly Context.Context _context = new Context.Context();


        public FATOR_CALCULODAO()
        {
        }

        /// <summary>INSERE OS PARÂMETROS PARA CALCULO DA DÍVIDA</summary>
        /// <param name="QTD_PARCELAS">QUANTIDADE DE PARCELAS PERMITIDAS</param>
        /// <param name="JUROS_PER">JUROS PERCENTUAL</param>
        /// <param name="COMISSAO_PER">COMISSÃO SOBRE A DÍVIDA</param>
        /// <returns>O ID RESULTANTE DA INSERÇÃO</returns>
        public int InserirFatorCalculo(int QTD_PARCELAS, float JUROS_PER, float COMISSAO_PER)
        {
            try
            {
                //DEFINE VARIAVEL 
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                //ATRIBUINDO OS VALORES PARA OBJETO
                _FATOR_CALCULO.QTD_PARCELAS = QTD_PARCELAS;
                _FATOR_CALCULO.JUROS_PER = JUROS_PER;
                _FATOR_CALCULO.COMISSAO_PER = COMISSAO_PER;
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
        /// <param name="COMISSAO_PER">COMISSÃO SOBRE A DÍVIDA</param>
        /// <returns>SUCESSO OU FALSO</returns>
        public bool ALterarFatorCalculo(int ID, int QTD_PARCELAS, float JUROS_PER, float COMISSAO_PER)
        {
            try
            {
                //DEFINE VARIAVEL 
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                //CARREGANDO AS INFORMAÇÕES EXISTENTE
                _FATOR_CALCULO = _context.FATOR_CALCULOs.Where(x => x.ID == ID).FirstOrDefault();

                if (_FATOR_CALCULO.ID != 0)
                {
                    //ATRIBUINDO OS VALORES PARA OBJETO
                    _FATOR_CALCULO.QTD_PARCELAS = QTD_PARCELAS;
                    _FATOR_CALCULO.JUROS_PER = JUROS_PER;
                    _FATOR_CALCULO.COMISSAO_PER = COMISSAO_PER;
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

                _context.FATOR_CALCULOs.Where(x => x.ID == ID).FirstOrDefault();

                if (_FATOR_CALCULO.ID != 0)
                {
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

    }
}