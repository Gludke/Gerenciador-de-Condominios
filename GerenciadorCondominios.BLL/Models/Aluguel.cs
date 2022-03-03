using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorCondominios.BLL.Models
{
    public class Aluguel
    {
        public int AluguelId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Valor { get; set; }

        [Display(Name = "Mês")]//Mostra dessa forma ao user
        public int MesId { get; set; }
        public Mes Mes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(2020, 2030, ErrorMessage = "O ano deve ser entre 2020 e 2030")]
        public int Ano { get; set; }

        public virtual ICollection<Pagamento> Pagamentos { get; set; }

    }
}