﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Biblioteca_padrao
{
    /// <summary>
    /// Classe responsavel pelos registros do Banco de Hora.
    /// </summary>
    public class BancoDeHoras
    {
        /// <summary>
        /// Id gerada pelo BD.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TimeSpan contendo as horas extras do funcionario.
        /// </summary>
        public TimeSpan HorasExtras { get; set; }

        /// <summary>
        /// String contendo a justificativa para adição.
        /// </summary>
        public string Justificativa { get; set; }

        /// <summary>
        /// Id do funcionario vinculado a esse registro.
        /// </summary>
        public Funcionario Funcionario { get; set; }

        /// <summary>
        /// Dia do registro.
        /// </summary>
        public DateTime DataRegistro { get; set; }

        /// <summary>
        /// Banco de horas do funcionario.
        /// </summary>
        /// <param name="horasExtras">TimeSpan contendo a quantidade de horas extras do funcionario.</param>
        /// <param name="justificativa">String de justificativa da inclusão.</param>
        /// <param name="dia">Dia do registro.</param>
        /// <param name="mes">Mes do registro.</param>
        /// <param name="ano">Ano do registro.</param>
        public BancoDeHoras(TimeSpan horasExtras, string justificativa, DateTime dataRegistro)
        {
            HorasExtras = horasExtras;
            Justificativa = justificativa;
            DataRegistro = dataRegistro;
        }
    }
}