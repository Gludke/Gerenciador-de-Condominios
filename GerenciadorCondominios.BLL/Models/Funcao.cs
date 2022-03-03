using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
    //Classe que determina as ações de cada User. A chave para distinção é uma String
    public class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
