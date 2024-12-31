using Gestor_de_tarefas.Enums;

namespace Gestor_de_tarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set;}
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }

    }
}
