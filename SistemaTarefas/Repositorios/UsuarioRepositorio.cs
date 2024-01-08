using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositorios.Interfaces;

namespace SistemaTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dBContext;

        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dBContext = sistemaTarefasDBContext;
        }
        public async Task<UsuarioModel> BuscarPorId(int Id) => await _dBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios() => await _dBContext.Usuarios.ToListAsync();
        
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dBContext.Usuarios.AddAsync(usuario);
           await _dBContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
           UsuarioModel usuarioid = await BuscarPorId(id);

            if(usuarioid == null)
            {
                throw new Exception("$Usuario para o ID:{id} não foi encontrado");
            }
            usuarioid.Nome = usuario.Nome;
            usuarioid.Email = usuario.Email;

            _dBContext.Usuarios.Update(usuarioid);
           await _dBContext.SaveChangesAsync();

            return usuarioid;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioid = await BuscarPorId(id);

            if (usuarioid == null)
            {
                throw new Exception("$Usuario para o ID:{id} não foi encontrado");
            }
            _dBContext.Usuarios.Remove(usuarioid);
            await _dBContext.SaveChangesAsync();
            return true;
        }

    }
}
