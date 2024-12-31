using Gestor_de_tarefas.Models;

namespace Gestor_de_tarefas.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task <List<UsuarioModel>> BuscarTodosUsuarios();
        Task <UsuarioModel> BuscarPorId(int id);
        Task <UsuarioModel> Adicionar(UsuarioModel usuario);
        Task <UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
