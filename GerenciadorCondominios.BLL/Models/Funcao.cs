using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
    ////Classe que determina o cada Função/tipo de usuário. Sua PK é do tipo String.
    public class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
