using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_lista_de_tarefas.Models
{
    public class TipoTarefa
    {
        public int TipoTarefaId { get; set; }
        public string Tipo { get; set; }

        public TipoTarefa()
        {

        }

        public TipoTarefa(int tipoTarefaId, string tipo)
        {
            TipoTarefaId = tipoTarefaId;
            Tipo = tipo;
        }

        public TipoTarefa(string tipo)
        {
            Tipo = tipo;
        }
    }
}
