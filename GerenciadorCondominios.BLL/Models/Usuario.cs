using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
    //Classe que determina o Usuário do sistema. Sua PK é do tipo String.
    public class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }
        //O arquivo da foto será salvo em um diretório e o path será salvo no DB
        public string Foto { get; set; }
        public bool PrimeiroAcesso { get; set; }
        public StatusConta Status { get; set; }

        //virtual diz ao EFC que os dados só serão carregados quando for solicitado. Gera desempenho.
        public virtual ICollection<Apartamento> MoradoresApartamentos { get; set; }//quem mora no app
        public virtual ICollection<Apartamento> ProprietariosApartamentos { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }

    }

    public enum StatusConta { 
        Analisando, Aprovado, Reprovado
    }

}
