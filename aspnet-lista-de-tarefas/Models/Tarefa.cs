using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_lista_de_tarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataExecucao { get; set; }
        public int TipoTarefaId { get; set; }
        virtual public TipoTarefa TipoTarefa { get; set; }

        public int StatusId { get; set; }
        virtual public Status Status { get; set; }

        public Tarefa()
        {
                
        }

        public Tarefa(int tarefaId, string nome, string descricao, DateTime dataExecucao, int tipoTarefaId, int statusId)
        {
            TarefaId = tarefaId;
            Nome = nome;
            Descricao = descricao;
            DataExecucao = dataExecucao;
            TipoTarefaId = tipoTarefaId;
            
            StatusId = statusId;
            
        }

        public Tarefa(string nome, string descricao, DateTime dataExecucao, int tipoTarefaId, int statusId)
        {
            Nome = nome;
            Descricao = descricao;
            DataExecucao = dataExecucao;
            TipoTarefaId = tipoTarefaId;
            StatusId = statusId;
        }

        public Tarefa(string nome, string descricao, DateTime dataExecucao)
        {
            Nome = nome;
            Descricao = descricao;
            DataExecucao = dataExecucao;
        }
    }
}
