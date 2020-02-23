using easycontrol.Areas.Admin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easycontrol.Areas.Admin.Models.Business
{
    public class InadimplenciaBusiness
    {
        public INADIMPLENCIA INADIMPLENCIA { get; set; }
        public USUARIO USUARIO { get; set; }
        public List<ParcelaBusiness> PARCELAS { get; set; }


        public InadimplenciaBusiness()
        {

        }

        public InadimplenciaBusiness(INADIMPLENCIA _INADIMPLENCIA, USUARIO _USUARIO, List<ParcelaBusiness> _PARCELAS)
        {
            this.INADIMPLENCIA = _INADIMPLENCIA;
            this.USUARIO = _USUARIO;
            this.PARCELAS = _PARCELAS;
        }
    }
}