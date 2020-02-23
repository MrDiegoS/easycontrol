using easycontrol.Areas.Admin.models;
using easycontrol.Areas.Admin.models.DAO;
using easycontrol.Areas.Admin.Models.Business;
using easycontrol.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using static easycontrol.Areas.Admin.models.DAO.FATOR_CALCULODAO;

namespace easycontrol.Areas.Admin.Models.DAO
{
    public class INADIMPLENCIADAO
    {
        private readonly Context _context = new Context();

        public INADIMPLENCIADAO()
        {

        }

        /// <summary>INSERE INADIMPLENCIA</summary>
        /// <param name="_INADIM">OBJETO DO TIPO INDADIMPLENCIA</param>
        /// <returns>O ID RESULTANTE DA INSERÇÃO</returns>
        public int InserirInadimplencia(INADIMPLENCIA _INADIM)
        {
            try
            {
                //DEFINE VARIAVEL 
                INADIMPLENCIA _INDADIMPLENCIA = new INADIMPLENCIA();

                //ATRIBUINDO OS VALORES PARA OBJETO
                _INDADIMPLENCIA.DT_CALCULO = _INADIM.DT_CALCULO;
                _INDADIMPLENCIA.DT_VENCIMENTO = _INADIM.DT_VENCIMENTO;
                _INDADIMPLENCIA.FATORID = _INADIM.FATORID;
                _INDADIMPLENCIA.QTD_PARCELAS = _INADIM.QTD_PARCELAS;
                _INDADIMPLENCIA.USERID = _INADIM.USERID;
                _INDADIMPLENCIA.VALOR_CALCULADO = _INADIM.VALOR_CALCULADO;
                _INDADIMPLENCIA.VALOR_COMISSAO = _INADIM.VALOR_COMISSAO;
                _INDADIMPLENCIA.VALOR_JUROS = _INADIM.VALOR_JUROS;
                _INDADIMPLENCIA.VALOR_ORIGINAL = _INADIM.VALOR_ORIGINAL;
                _INDADIMPLENCIA.VALOR_PARCELA = _INADIM.VALOR_PARCELA;

                //ADICIONANDO OS VALORES AO CONTEXTO
                _context.INADIMPLENCIAs.Add(_INDADIMPLENCIA);

                //SALVANDO MUDANÇAS
                _context.SaveChanges();

                return _INDADIMPLENCIA.ID;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>LISTA DIVIDAS</summary>
        /// <returns>LISTA DE INADIMPLENCIAS</returns>
        public List<InadimplenciaBusiness> litarInadim()
        {
            try
            {
                List<InadimplenciaBusiness> _INADIMPLENCIABUSINESS = new List<InadimplenciaBusiness>();
                List<INADIMPLENCIA> _INADIMPLENCIA = new List<INADIMPLENCIA>();
                List<USUARIO> _USUARIO = new List<USUARIO>();
                InadimplenciaBusiness _INADIMBUSINESS = new InadimplenciaBusiness();
                ParcelaBusiness _PARCELASBUSINESS = new ParcelaBusiness();

                _INADIMBUSINESS.INADIMPLENCIA = new INADIMPLENCIA();
                _INADIMBUSINESS.USUARIO = new USUARIO();
                _INADIMBUSINESS.PARCELAS = new List<ParcelaBusiness>();

                _INADIMPLENCIA = _context.INADIMPLENCIAs.ToList();

                //PERCORRE A LISTA DE INADIMPLENCIA ENCONTRADA
                foreach (var item in _INADIMPLENCIA)
                {
                    //CARREGA OS DADOS NO OBJETO
                    _INADIMBUSINESS.USUARIO = _context.USUARIOs.Where(x => x.ID == item.USERID).FirstOrDefault();
                    _INADIMBUSINESS.INADIMPLENCIA.DT_CALCULO = item.DT_CALCULO;
                    _INADIMBUSINESS.INADIMPLENCIA.DT_VENCIMENTO = item.DT_VENCIMENTO;
                    _INADIMBUSINESS.INADIMPLENCIA.QTD_PARCELAS = item.QTD_PARCELAS;
                    _INADIMBUSINESS.INADIMPLENCIA.VALOR_CALCULADO = item.VALOR_CALCULADO;
                    _INADIMBUSINESS.INADIMPLENCIA.VALOR_JUROS = item.VALOR_JUROS;
                    _INADIMBUSINESS.INADIMPLENCIA.VALOR_ORIGINAL = item.VALOR_ORIGINAL;

                    //PERCORRE A LISTA DE PARCELAS REFERENTE A INADIMPLENCIA
                    for (int i = 1; i < item.QTD_PARCELAS; i++)
                    {
                        _PARCELASBUSINESS.ID = i;
                        _PARCELASBUSINESS.DT_VENCIMENTO = item.DT_VENCIMENTO.AddMonths(i);
                        _PARCELASBUSINESS.VALOR = item.VALOR_PARCELA;
                        _INADIMBUSINESS.PARCELAS.Add(_PARCELASBUSINESS);
                    }
                    //PERCORRE ADICIONA A INDADIMPLENCIA A LISTA
                    _INADIMPLENCIABUSINESS.Add(_INADIMBUSINESS);
                }
                return _INADIMPLENCIABUSINESS;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>CALCULA INADIMPLENCIA</summary>
        /// <param name="_INADIM">OBJETO DO TIPO INDADIMPLENCIA</param>
        /// <returns>MENSAGEM COM O RESULTADO DA OPERAÇÃO</returns>
        public string calcularInadim(INADIMPLENCIA _INADIM)
        {
            try
            {
                //DEFINE VARIÁVEIS 
                string _retorno = String.Empty;
                float _juros = new float();
                float _comissao = new float();
                float _valorfinal = new float();
                float _valorParcela = new float();
                int _diasAtraso = 0;

                FATOR_CALCULODAO _FATOR_CALCULODAO = new FATOR_CALCULODAO();
                FATOR_CALCULO _FATOR_CALCULO = new FATOR_CALCULO();

                USUARIODAO _USUARIODAO = new USUARIODAO();
                USUARIO _USUARIO = new USUARIO();

                INADIMPLENCIA _INADIMPLENCIA = new INADIMPLENCIA();

                _FATOR_CALCULO = _context.FATOR_CALCULOs.Where(x => x.ID == _INADIM.FATORID).FirstOrDefault();
                _USUARIO = _context.USUARIOs.Where(x => x.ID == _INADIM.USERID).FirstOrDefault();

                //VERIFICAR SE O FATOR CALCULO FOI ENCONTRADO
                if (_FATOR_CALCULO != null)
                {
                    //VERIFICA SE USUÁRIO FOI ENCONTRADO
                    if (_USUARIO != null)
                    {
                        //VERIFICA SE A QUANTIDADE DE PARCELAS INFORMADA É MENOR OU IGUAL QUE A PERMITIDA
                        if (_INADIM.QTD_PARCELAS <= _FATOR_CALCULO.QTD_PARCELAS)
                        {
                            //CALCULA O ATRASO EM DIAS
                            _diasAtraso = Convert.ToInt32(DateTime.Now.Subtract(_INADIM.DT_VENCIMENTO).TotalDays);

                            //VERIFICA O TIPO DO JUROS
                            if (_FATOR_CALCULO.JUROS_TIPO == ((EnumJuros)EnumJuros.Simples).ToString())
                            {
                                _juros = _INADIM.VALOR_ORIGINAL * ((_FATOR_CALCULO.JUROS_PER / 100) * _diasAtraso);
                                _valorfinal = _INADIM.VALOR_ORIGINAL + _juros;
                                _valorParcela = _valorfinal / _INADIM.QTD_PARCELAS;
                                _comissao = _valorfinal * (_FATOR_CALCULO.COMISSAO_PER / 100);
                            }
                            else if (_FATOR_CALCULO.JUROS_TIPO == ((EnumJuros)EnumJuros.Composto).ToString())
                            {
                                _juros = _INADIM.VALOR_ORIGINAL * float.Parse(Math.Pow((1 + (_FATOR_CALCULO.JUROS_PER / 100)), _diasAtraso).ToString());
                                _valorfinal = _INADIM.VALOR_ORIGINAL + _juros;
                                _valorParcela = _valorfinal / _INADIM.QTD_PARCELAS;
                                _comissao = _valorfinal * (_FATOR_CALCULO.COMISSAO_PER / 100);
                            };

                            //CARREGA OS DADOS NO OBJETO
                            _INADIMPLENCIA.VALOR_CALCULADO = _valorfinal;
                            _INADIMPLENCIA.QTD_PARCELAS = _INADIM.QTD_PARCELAS;
                            _INADIMPLENCIA.DT_VENCIMENTO = _INADIM.DT_VENCIMENTO;
                            _INADIMPLENCIA.DT_CALCULO = DateTime.Now;
                            _INADIMPLENCIA.VALOR_PARCELA = _valorParcela;
                            _INADIMPLENCIA.VALOR_ORIGINAL = _INADIM.VALOR_ORIGINAL;
                            _INADIMPLENCIA.VALOR_JUROS = _juros;
                            _INADIMPLENCIA.VALOR_COMISSAO = _comissao;
                            _INADIMPLENCIA.USERID = _INADIM.USERID;
                            _INADIMPLENCIA.FATORID = _INADIM.FATORID;

                            //CHAMA O MÉTODO DE INSERIR
                            InserirInadimplencia(_INADIMPLENCIA);

                            _retorno = "Dívida cadastrada com sucesso";
                        }
                        else
                        {
                            _retorno = "A quantidade de parcelas solicitada é maior que a permitida para esse Fator";
                        }
                    }
                    else
                    {
                        _retorno = "Não foi localizar o Usuário informado";
                    }
                }
                else
                {
                    _retorno = "Não foi localizar o Fator do Calculo informado";

                }

                return _retorno;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}