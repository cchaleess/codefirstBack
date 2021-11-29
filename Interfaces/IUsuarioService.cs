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
        public Task<int> SaveUsuarioDb(UsuarioCreatedDTO usuarioDTO);
        public Task<int> UpdateUsuarioDb(UsuarioUpdateDTO usuarioDTO, int usuarioId);
        public Task<int> DeleteUsuarioDb(int usuarioId);
    }
}
