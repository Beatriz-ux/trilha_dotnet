using Financa.Core.Interfaces;
using Financa.Core.Entities;

namespace Financa.Infrastructure.Persistence.DataBase;

public class UsuarioDB : IUsuarioCollection
{
    private readonly List<Usuario> _usuarios = new List<Usuario>();
    private int _id=0;

     public UsuarioDB()
    {
        InicializaDB();
    }

    public void InicializaDB()
    {
        // Create(new Usuario { NomeUsuario = "Alessandro C. Santos" });
        // Create(new Usuario { NomeUsuario = "Alberto de Nóbrega" });
        // Create(new Usuario { NomeUsuario = "Aquiles Prestes" });
    }

    public void Create(Usuario entity)
    {
        _id++;
        entity.IdUsuario = _id;
        _usuarios.Add(entity);
    }

    public ICollection<Usuario> GetAll()
    {
        return _usuarios;
    }

    public Usuario GetById(int id)
    {
        return _usuarios.FirstOrDefault(c => c.IdUsuario == id);
    }

    public void Delete(Usuario entity)
    {
        _usuarios.RemoveAll(c => c.IdUsuario == entity.IdUsuario);
    }

    public void Update(Usuario entity)
        {
            var usuarioExistente = _usuarios.FirstOrDefault(c => c.IdUsuario == entity.IdUsuario);
            if (usuarioExistente != null)
            {
                // Atualiza os dados do usuário existente com os dados do usuário fornecido
                usuarioExistente.NomeUsuario = entity.NomeUsuario;
                usuarioExistente.EmailUsuario = entity.EmailUsuario;
                usuarioExistente.SenhaUsuario = entity.SenhaUsuario;
                usuarioExistente.IdConta = entity.IdConta;
            }
            else
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }
        }
}
