using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Gestao_de_Entregas.Data
{
    public class CalculadorDbContext : DbContext
    {
        public CalculadorDbContext(DbContextOptions<CalculadorDbContext> options)
            : base(options)
        {
        }

        public CalculadorDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<HorasFuncionario> HorasFuncionarios { get; private set; }
        public DbSet<Funcionario> Funcionario { get; private set; }
        public DbSet<BancoDeHoras> BancoDeHoras { get; private set; }
    }
}