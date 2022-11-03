using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnet_lista_de_tarefas.Models;

namespace aspnet_lista_de_tarefas.Data
{
    public class ListaTarefasDbContext: DbContext
    {
        public ListaTarefasDbContext(DbContextOptions<ListaTarefasDbContext> options): base(options)
        {

        }
        public DbSet<TipoTarefa> TiposTarefas { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Status>()
                .HasData(new List<Status> { 
                    new Status(1,"A fazer"),
                    new Status(2,"Fazendo"),
                    new Status(3,"Feito")
                });

            builder.Entity<TipoTarefa>()
                .HasData(new List<TipoTarefa> {
                    new TipoTarefa(1,"Trabalho"),
                    new TipoTarefa(2,"Faculdade"),
                    new TipoTarefa(3,"Estudo"),
                    new TipoTarefa(4,"Pessoal")
                });
        }
    }
}
