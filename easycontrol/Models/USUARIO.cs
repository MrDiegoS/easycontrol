using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace easycontrol.Models
{
    [Table("USUARIO")]
    public class USUARIO
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string USER { get; set; }
        public string SENHA { get; set; }
        public string EMAIL { get; set; }
        public bool ADMIN { get; set; }
        public DateTime DTCADASTRO { get; set; }
        public DateTime DTALTERACAO { get; set; }

        public USUARIO()
        {
                
        }

        public USUARIO(string _NOME, string _USER, string _SENHA, string _EMAIL, bool _ADMIN, DateTime _DTCADASTRO, DateTime _DTALTERACAO)
        {
            this.NOME = _NOME;
            this.USER = _USER;
            this.SENHA = _SENHA;
            this.EMAIL = _EMAIL;
            this.ADMIN = _ADMIN;
            this.DTCADASTRO = _DTCADASTRO;
            this.DTALTERACAO = _DTALTERACAO;
        }
    }
}