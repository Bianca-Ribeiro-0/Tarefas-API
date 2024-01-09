using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositorios.Interfaces;

namespace SistemaTarefas.Repositorios
{
    public class TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContext _dBContext = sistemaTarefasDBContext;

        public async Task<TarefaModel> BuscarPorId(int Id) => await _dBContext.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<List<TarefaModel>> BuscarTodasTarefas() => await _dBContext.Tarefas.Include(x => x.Usuario).ToListAsync();
        
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
           await _dBContext.Tarefas.AddAsync(tarefa);
           await _dBContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
           TarefaModel tarefaid = await BuscarPorId(id);

            if(tarefaid == null)
            {
                throw new Exception("$Tarefa para o ID:{id} não foi encontrado");
            }
            tarefaid.Nome = tarefa.Nome;
            tarefaid.Descricao = tarefa.Descricao;
            tarefaid.Status = tarefa.Status;
            tarefaid.UsuarioId = tarefa.UsuarioId;

            _dBContext.Tarefas.Update(tarefaid);
           await _dBContext.SaveChangesAsync();

            return tarefaid;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaid = await BuscarPorId(id);

            if (tarefaid == null)
            {
                throw new Exception("$Tarefa para o ID:{id} não foi encontrado");
            }
            _dBContext.Tarefas.Remove(tarefaid);
            await _dBContext.SaveChangesAsync();

            return true;
        }

    }
}
