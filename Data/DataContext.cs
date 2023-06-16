using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTcc.Models;
using ApiTcc.Utils;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace ApiTcc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Itens> Itens {get; set;}
        public DbSet<Utilizadores> Utilizadores {get; set;}
        public DbSet<Estoque> Estoque {get; set;}
        public DbSet<Agendamento> Agendamento {get; set;}
        public DbSet<Equipamentos> Equipamentos {get; set;}
        public DbSet<Item_Equipamento> Item_Equipamento{get; set;}
        public DbSet<SatatusAgendamento> StatusAgendamento{get; set;}
        public DbSet<TipoMovimentacao> TipoMovimentacao{get; set;}
        public DbSet<TipodeItem> TipodeItem{get; set;}
        
        public DbSet<StatusItem> StatusItem{get; set;}

        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            Utilizadores user = new Utilizadores();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
            user.idUtilizador = 1;
            user.nmUtilizador = "Carlos";
            user.Perfil = "Almoxarife";
            user.passwordString = string.Empty;
            user.PasswordHash = hash;
            user.passwordSalt = salt;
            user.emUtilizador = "Carlos@gmail.com";

                       modelBuilder.Entity<Utilizadores>().HasData(user); 
 modelBuilder.Entity<Utilizadores>().Property(u => u.Perfil).HasDefaultValue("Anonymous");

            
        }

        

    
    }
}