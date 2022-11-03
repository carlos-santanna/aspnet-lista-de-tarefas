using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_lista_de_tarefas.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Nome { get; set; }

        public Status()
        {
                
        }

        public Status(int statusId, string nome)
        {
            StatusId = statusId;
            Nome = nome;
        }

        public Status(string nome)
        {
            Nome = nome;
        }
    }
}
