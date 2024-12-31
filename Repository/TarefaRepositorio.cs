using Gestor_de_tarefas.Data;
using Gestor_de_tarefas.Models;
using Gestor_de_tarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_tarefas.Repository
{
    public class TarefaRepositorio : ITarefaRepository
    {
        private readonly GestorTarefasDbContext _dbContext;
        public TarefaRepositorio(GestorTarefasDbContext gestorTarefasDbContext)
        {
            _dbContext = gestorTarefasDbContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include (x => x.Usuario)
                .ToListAsync();
        }
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            _dbContext.SaveChanges();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
                if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id{id} não foi encontrado");
            }
                tarefaPorId.Name = tarefa.Name;
                tarefaPorId.Descricao = tarefa.Descricao;
                tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId= tarefa.UsuarioId;


            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return tarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id{id} não foi encontrado");
            }
            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        


    }
}
