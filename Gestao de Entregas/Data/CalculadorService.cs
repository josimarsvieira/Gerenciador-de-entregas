using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gestao_de_Entregas.Data
{
    public class CalculadorService : DbContext
    {
        private readonly CalculadorDbContext _db;

        public CalculadorService(CalculadorDbContext db)
        {
            _db = db;
        }

        public Funcionario BuscarFuncionario(int numeroRegistro)
        {
            Funcionario result = _db.Funcionario.AsQueryable().Where(x => x.Registro == numeroRegistro).SingleOrDefault();
            return result;
        }

        public List<Funcionario> BuscarFuncionario()
        {
            List<Funcionario> todosFuncionarios = _db.Funcionario.ToList();
            return todosFuncionarios;
        }

        public List<HorasFuncionario> BuscaCartaoPonto(Funcionario funcionario, DateTime dataBusca)
        {
            List<HorasFuncionario> Cartao = _db.HorasFuncionarios.AsQueryable().Where(x => x.FuncionarioId == funcionario.Id &&
            x.DataRegistro.Month == dataBusca.Month &&
            x.DataRegistro.Year == dataBusca.Year).OrderBy(x => x.DataRegistro).ToList();
            return Cartao;
        }

        public List<HorasFuncionario> BuscaCartaoPonto(Funcionario funcionario, DateTime dataFinal, DateTime dataInicial)
        {
            List<HorasFuncionario> Cartao = _db.HorasFuncionarios.AsQueryable().Where(x => x.FuncionarioId == funcionario.Id &&
            x.DataRegistro <= dataFinal &&
            x.DataRegistro >= dataInicial).OrderBy(x => x.DataRegistro).ToList();
            return Cartao;
        }

        /// <summary>
        /// Recupera o banco de horas de um funcionario especifico.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario recuperado do BD.</param>
        /// <returns>Retorna um IEnumerable contendo uma lista de todos os registros encontrados.</returns>
        public List<BancoDeHoras> BuscaBancoDeHoras(Funcionario funcionario)
        {
            List<BancoDeHoras> Banco = _db.BancoDeHoras.AsQueryable().Where(x => x.FuncionarioId == funcionario.Id).OrderBy(x => x.DataRegistro).ToList();
            return Banco;
        }

        /// <summary>
        /// Recupera o banco de horas de um funcionario especifico, filtrado pelo mês e ano.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario recuperado do BD.</param>
        /// <param name="mes">Mes referente ao periodo desejado para recuperação.</param>
        /// <param name="ano">Ano referente ao periodo desejado para recuperação.</param>
        /// <returns>Retorna um IEnumerable contendo uma lista de todos os registros encontrados.</returns>
        public List<BancoDeHoras> BuscaBancoDeHorasFiltrado(Funcionario funcionario, DateTime dataBusca)
        {
            List<BancoDeHoras> BancoFiltrado = _db.BancoDeHoras.AsQueryable().Where(x => x.FuncionarioId == funcionario.Id &&
            x.DataRegistro.Month == dataBusca.Month &&
            x.DataRegistro.Year == dataBusca.Year).ToList();
            return BancoFiltrado;
        }

        public HorasFuncionario BuscarRegistro(Funcionario funcionario, DateTime dataAlterar)
        {
            HorasFuncionario hora = _db.HorasFuncionarios.AsQueryable().Where(x => x.FuncionarioId == funcionario.Id && x.DataRegistro == dataAlterar).SingleOrDefault();
            return hora;
        }
    }
}