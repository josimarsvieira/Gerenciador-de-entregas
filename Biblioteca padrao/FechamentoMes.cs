using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_padrao
{
    public class FechamentoMes
    {
        public int Id { get; set; }
        public DateTime DataFechamento { get; set; }
        public Funcionario Funcionario { get; set; }
        public TimeSpan TotalHoraMes { get; set; }
    }
}