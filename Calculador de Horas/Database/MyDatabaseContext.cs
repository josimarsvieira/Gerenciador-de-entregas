﻿using Biblioteca_padrao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculador_de_Horas.Database
{
    /// <summary>
    /// Classe de acesso e alterações no banco de dados
    /// </summary>
    public class MyDatabaseContext : DbContext
    {
        /// <summary>
        /// Representação da tabela Horas dos Funcionarios no banco de dados.
        /// </summary>
        public DbSet<HorasFuncionario> HorasFuncionarios { get; private set; }

        /// <summary>
        /// Representação da tabela funcionario no banco de dados.
        /// </summary>
        public DbSet<Funcionario> Funcionario { get; private set; }

        /// <summary>
        /// Representação da tabela Banco de Horas no banco de dados.
        /// </summary>
        public DbSet<BancoDeHoras> BancoDeHoras { get; private set; }

        public DbSet<Empresa> Empresa { get; private set; }

        public DbSet<FechamentoMes> FechamentoMes { get; private set; }

        /// <summary>
        /// Metodo que fornece a String de conexão com o BD.
        /// </summary>
        /// <param name="optionsBuilder"></param>

        public MyDatabaseContext()
        : base()
        {
        }

        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(ConnectionString.StringCC);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Metodo responsavel pelo salvamento de Funcionario no BD.
        /// </summary>
        /// <param name="funcionario"></param>
        public void SalvarFuncionario(Funcionario funcionario)
        {
            Funcionario.Add(funcionario);
            SaveChanges();
        }

        /// <summary>
        /// Metodo responsavel pela atualização de Funcionario no BD.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo Funcionario com os novos dados.</param>
        /// <param name="busca">Objeto do tipo Funcionario recuperado do BD e que vai ser atualizado.</param>
        public void AtualizarFuncionario(Funcionario funcionario, Funcionario busca)
        {
            Entry(busca).CurrentValues.SetValues(busca.Nome = funcionario.Nome);
            Entry(busca).CurrentValues.SetValues(busca.Funcao = funcionario.Funcao);
            Entry(busca).CurrentValues.SetValues(busca.HoraIncio = funcionario.HoraIncio);
            Entry(busca).CurrentValues.SetValues(busca.HoraTermino = funcionario.HoraTermino);
            Entry(busca).CurrentValues.SetValues(busca.HoraAlmocoSaida = funcionario.HoraAlmocoSaida);
            Entry(busca).CurrentValues.SetValues(busca.HoraAlmocoRetorno = funcionario.HoraAlmocoRetorno);
            SaveChanges();
        }

        /// <summary>
        /// Localiza um funcionario especifico no banco de dados.
        /// </summary>
        /// <param name="numeroRegistro">Numero do registro do funcionario a ser localizado.</param>
        /// <returns>Retorna um objeto do tipo Funcionario.</returns>

        public Funcionario BuscarFuncionario(int numeroRegistro)
        {
            Funcionario result = Funcionario.FirstOrDefault(x => x.Registro == numeroRegistro);
            return result;
        }

        public List<Funcionario> BuscarFuncionario()
        {
            List<Funcionario> todosFuncionarios = Funcionario.ToList();
            return todosFuncionarios;
        }

        /// <summary>
        /// Metodo responsavel pela adição de horas ao Funcionario.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario recuperado do BD para a adição.</param>
        public void UpdateFuncionario(Funcionario funcionario)
        {
            try
            {
                if (funcionario == null)
                {
                    throw new ArgumentNullException("horasFuncionario");
                }

                Entry(funcionario).State = EntityState.Modified;
                SaveChanges();
            }
            catch (Exception dbx)
            {
                throw dbx;
            }
        }

        /// <summary>
        /// Recupera todos os registros de horas de um funcionario especifico.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo funcionario recuperado do BD.</param>
        /// <param name="mes">Mes referente ao periodo desejado para recuperação.</param>
        /// <param name="ano">Ano referente ao periodo desejado para recuperação.</param>
        /// <returns>Retorna um IEnumerable contendo uma lista de todos os registros encontrados.</returns>
        public List<HorasFuncionario> BuscaCartaoPonto(Funcionario funcionario, DateTime dataBusca)
        {
            List<HorasFuncionario> Cartao = HorasFuncionarios.AsQueryable().Where(x => x.Funcionario == funcionario &&
            x.DataRegistro.Month == dataBusca.Month &&
            x.DataRegistro.Year == dataBusca.Year).OrderBy(x => x.DataRegistro).ToList();
            return Cartao;
        }

        public List<HorasFuncionario> BuscaCartaoPonto(Funcionario funcionario, DateTime dataFinal, DateTime dataInicial)
        {
            List<HorasFuncionario> Cartao = HorasFuncionarios.AsQueryable().Where(x => x.Funcionario == funcionario &&
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
            List<BancoDeHoras> Banco = BancoDeHoras.AsQueryable().Where(x => x.Funcionario == funcionario).OrderBy(x => x.DataRegistro).ToList();
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
            List<BancoDeHoras> BancoFiltrado = BancoDeHoras.AsQueryable().Where(x => x.Funcionario == funcionario &&
            x.DataRegistro.Month == dataBusca.Month &&
            x.DataRegistro.Year == dataBusca.Year).ToList();
            return BancoFiltrado;
        }

        /// <summary>
        /// Atualiza um registro de horas especifico de um funcionario.
        /// </summary>
        /// <param name="horasFuncionario">Objeto do tipo HorasFuncionario recuperado do BD.</param>
        public void UpdateHora(HorasFuncionario horasFuncionario)
        {
            try
            {
                if (horasFuncionario == null)
                {
                    throw new ArgumentNullException("horasFuncionario");
                }

                Entry(horasFuncionario).State = EntityState.Modified;
                SaveChanges();
            }
            catch (Exception dbx)
            {
                throw dbx;
            }
        }

        /// <summary>
        /// Adiciona um novo registro no banco de horas de um funcionario.
        /// </summary>
        /// <param name="funcionario">Objeto do tipo Funcionario recuperado do BD.</param>
        public void UpdateBanco(Funcionario funcionario)
        {
            Entry(funcionario).CurrentValues.SetValues(funcionario.BancoDeHoras);
            SaveChanges();
        }

        public Empresa BuscarEmpresa()
        {
            Empresa busca = Empresa.AsQueryable().Where(x => x.RazaoSocial != null).SingleOrDefault();
            return busca;
        }

        public void SalvarEmpresa(Empresa empresa)
        {
            Empresa.Add(empresa);
            SaveChanges();
        }

        public void AtualizarEmpresa(Empresa empresa, Empresa busca)
        {
            Entry(busca).CurrentValues.SetValues(busca.RazaoSocial = empresa.RazaoSocial);
            Entry(busca).CurrentValues.SetValues(busca.CNPJ = empresa.CNPJ);
            Entry(busca).CurrentValues.SetValues(busca.DiaFechamento = empresa.DiaFechamento);
            SaveChanges();
        }

        public HorasFuncionario BuscarRegistro(Funcionario funcionario, DateTime dataAlterar)
        {
            HorasFuncionario hora = HorasFuncionarios.AsQueryable().Where(x => x.Funcionario == funcionario && x.DataRegistro == dataAlterar).SingleOrDefault();
            return hora;
        }

        public void RemoveHora(Funcionario funcionario, DateTime dataRemover)
        {
            Funcionario.Attach(funcionario);
            Funcionario.Remove(funcionario);
            SaveChanges();
        }

        public void AdicionarFechamento(FechamentoMes fechamento)
        {
            try
            {
                FechamentoMes fechamentoMes = FechamentoMes.FirstOrDefault(x => x.Funcionario == fechamento.Funcionario && x.DataFechamento == fechamento.DataFechamento);

                if (fechamentoMes != null)
                {
                    fechamentoMes.TotalHoraMes = fechamento.TotalHoraMes;
                    FechamentoMes.Update(fechamentoMes);
                }
                else
                {
                    FechamentoMes.Add(fechamento);
                }
                SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }
    }
}