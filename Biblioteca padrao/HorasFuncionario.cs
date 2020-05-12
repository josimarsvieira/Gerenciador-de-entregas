using System;
using System.Collections;
using System.Collections.Generic;

namespace Biblioteca_padrao
{
    /// <summary>
    /// Classe para registro de horas do funcionario.
    /// </summary>
    public class HorasFuncionario
    {
        /// <summary>
        /// Id gerado pelo BD.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hora de entrada no trabalho.
        /// </summary>
        public TimeSpan Entrada { get; set; }

        /// <summary>
        /// Hora de saida do trabalho.
        /// </summary>
        public TimeSpan Saida { get; set; }

        /// <summary>
        /// Hora de saida para o Almoço
        /// </summary>
        public TimeSpan AlmocoSaida { get; set; }

        /// <summary>
        /// Hora de retorno do Almoço
        /// </summary>
        public TimeSpan AlmocoRetorno { get; set; }

        /// <summary>
        /// Horas extras feitas no dia.
        /// </summary>
        public TimeSpan Extras { get; set; }

        /// <summary>
        /// Id do funcionario vinculado ao registro.
        /// </summary>
        public Funcionario Funcionario { get; set; }

        /// <summary>
        /// Data do registro.
        /// </summary>
        public DateTime DataRegistro { get; set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public HorasFuncionario()
        {
        }

        /// <summary>
        /// Metodo para calcular as horas extras.
        /// </summary>
        /// <param name="totalHorasParaTrabalhar">Total de horas obrigatorias para trabalho diario, conforme contrato.</param>
        public TimeSpan CalculaExtras(TimeSpan totalHorasParaTrabalhar)
        {
            Extras = Saida.Subtract(AlmocoRetorno).Add(AlmocoSaida.Subtract(Entrada)).Subtract(totalHorasParaTrabalhar);
            return Extras;
        }
    }
}