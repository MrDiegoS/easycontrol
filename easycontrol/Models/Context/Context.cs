
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using easycontrol.Areas.Admin.models;

namespace easycontrol.Models.Context
{
    public class Context : DbContext
    {
        public Context() : base("ContextEasycontrol") {  }

        public DbSet<FATOR_CALCULO> FATOR_CALCULOs { get; set; }
        public DbSet<USUARIO> USUARIOs { get; set; }

    }
}