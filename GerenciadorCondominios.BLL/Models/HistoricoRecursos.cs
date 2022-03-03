using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
    //Classe que gerencia todas os pagamentos - alugueis e gastos - serviços
    public class HistoricoRecursos
    {
        public int HistoricoRecursosId { get; set; }
        public decimal Valor { get; set; }
        public Tipos Tipo { get; set; }
        public int Dia { get; set; }

        public int MesId { get; set; }
        public virtual Mes Mes { get; set; }

        public int Ano { get; set; }
    }

    public enum Tipos
    {
        Entrada, Saida
    }
}