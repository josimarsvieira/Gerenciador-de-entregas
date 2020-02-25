using System;
using System.Collections;
using System.Collections.Generic;

namespace Gestao_de_Entregas.Data
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
        /// Horas extras feitas no dia.
        /// </summary>
        public TimeSpan Extras { get; set; }

        /// <summary>
        /// Id do funcionario vinculado ao registro.
        /// </summary>
        public int FuncionarioId { get; set; }

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
        /// Instancia um objeto para calculo de horas extras de um dia trabalhado. O objeto calcula as horas Extras automaticamente.
        /// </summary>
        /// <param name="entrada">Hora que o funcionario inicio o expediente</param>
        /// <param name="saida">Hora que o funcionario terminou o expediente</param>
        /// <param name="dataRegistro">data do registro</param>
        public HorasFuncionario(TimeSpan entrada, TimeSpan saida, DateTime dataRegistro)
        {
            Entrada = entrada;
            Saida = saida;
            DataRegistro = dataRegistro;
        }
    }
}