using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easycontrol.Areas.Admin.Models.Business
{
    public class ParcelaBusiness
    {
        public int ID { get; set; }
        public float VALOR { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }

        public ParcelaBusiness()
        {

        }

        public ParcelaBusiness(int _ID, float _VALOR, DateTime _DT_VENCIMENTO)
        {
            this.ID = _ID;
            this.VALOR = _VALOR;
            this.DT_VENCIMENTO = _DT_VENCIMENTO;
        }
    }
}