using Gestor_de_tarefas.Models;

namespace Gestor_de_tarefas.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        Task <List<TarefaModel>> BuscarTodasTarefas();
        Task <TarefaModel> BuscarPorId(int id);
        Task <TarefaModel> Adicionar(TarefaModel tarefa);
        Task <TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
