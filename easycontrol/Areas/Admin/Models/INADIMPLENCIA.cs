using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace easycontrol.Areas.Admin.models
{
    [Table("INADIMPLENCIA")]
    public class INADIMPLENCIA
    {
        public int ID { get; set; }
        public int USERID { get; set; }
        public int FATORID { get; set; }
        public float VALOR_ORIGINAL { get; set; }
        public float VALOR_JUROS { get; set; }
        public float VALOR_COMISSAO { get; set; }
        public float VALOR_CALCULADO { get; set; }
        public float VALOR_PARCELA { get; set; }
        public int QTD_PARCELAS { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }
        public DateTime DT_CALCULO { get; set; }

        public INADIMPLENCIA()
        {

        }

        public INADIMPLENCIA(float _VALOR_ORIGINAL, int _USERID, int _FATORID, float _VALOR_JUROS, float _VALOR_COMISSAO, float _VALOR_CALCULADO, float _VALOR_PARCELA, int _QTD_PARCELAS, DateTime _DT_VENCIMENTO, DateTime _DT_CALCULO)
        {
            this.USERID = _USERID;
            this.FATORID = _USERID;
            this.VALOR_ORIGINAL = _VALOR_ORIGINAL;
            this.VALOR_JUROS = _VALOR_JUROS;
            this.VALOR_COMISSAO = _VALOR_COMISSAO;
            this.VALOR_CALCULADO = _VALOR_CALCULADO;
            this.VALOR_PARCELA = _VALOR_PARCELA;
            this.QTD_PARCELAS = _QTD_PARCELAS;
            this.DT_VENCIMENTO = _DT_VENCIMENTO;
            this.DT_CALCULO = _DT_CALCULO;
        }
    }
}