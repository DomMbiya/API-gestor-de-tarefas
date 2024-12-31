using Gestor_de_tarefas.Data;
using Gestor_de_tarefas.Models;
using Gestor_de_tarefas.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_tarefas.Repository
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly GestorTarefasDbContext _dbContext;
        public UsuarioRepositorio(GestorTarefasDbContext gestorTarefasDbContext)
        {
            _dbContext = gestorTarefasDbContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
                if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id{id} não foi encontrado");
            }
                usuarioPorId.Nome = usuario.Nome;
                usuarioPorId.Email = usuario.Email;
            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id{id} não foi encontrado");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        


    }
}
