using CodeFirst.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Services
{
    public interface IUsuarioService
    {
        public Task<string> GetUSuariosList();
        public Task<string> SaveUsuarioDb(UsuarioCreatedDTO usuarioDTO);
        public Task<string> UpdateUsuarioDb(UsuarioUpdateDTO usuarioDTO);
        public Task<string> DeleteUsuarioDb(int usuarioId);
    }
}
