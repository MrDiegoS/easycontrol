using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easycontrol.Areas.Admin.models
{
    public class FATOR_CALCULO
    {
        public int ID { get; set; }
        public int QTD_PARCELAS { get; set; }
        public float JUROS_PER { get; set; }
        public string JUROS_TIPO { get; set; }
        public float COMISSAO_PER { get; set; }
        public DateTime DTCADASTRO { get; set; }
        public DateTime DTALTERACAO { get; set; }

        public FATOR_CALCULO()
        {

        }

        public FATOR_CALCULO(int _QTD_PARCELAS, float _JUROS_PER, string _JUROS_TIPO, float _COMISSAO_PER, DateTime _DTCADASTRO, DateTime _DTALTERACAO)
        {
            this.QTD_PARCELAS = _QTD_PARCELAS;
            this.JUROS_PER = _JUROS_PER;
            this.JUROS_TIPO = _JUROS_TIPO;
            this.COMISSAO_PER = _COMISSAO_PER;
            this.DTCADASTRO = _DTCADASTRO;
            this.DTALTERACAO = _DTALTERACAO;
        }
    }
}