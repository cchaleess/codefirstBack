using CodeFirst.Context;
using CodeFirst.DTO;
using CodeFirst.DBModels;
using CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Net.Sockets;
using System.Net;

namespace CodeFirst.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MVCContext _context;
        private readonly IConnectionSqlService _connectionSqlService;

        public UsuarioService(MVCContext context, IConnectionSqlService connectionSqlService)
        {
            _context = context;
            _connectionSqlService = connectionSqlService;
        }
             

        public async Task<string> GetUSuariosList()
        {
            string query = "";
            try
            {
                query = @"select ID,NOMBRE,EMAIL from dbo.USUARIO";
                return await _connectionSqlService.GetJsonFromSql(query);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return error;
            }
        }
       
        public async Task<int> SaveUsuarioDb(UsuarioCreatedDTO usuarioDTO)
        {
            string query = "";
            try
            {
                query = String.Format("INSERT INTO dbo.USUARIO (Nombre,Email) VALUES('{0}', '{1}' )",
                                      usuarioDTO.Nombre, usuarioDTO.Email);
                return await _connectionSqlService.CrudDataToSql(query);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return -1;
            }
        }

        public async Task<int> UpdateUsuarioDb(UsuarioUpdateDTO usuarioDTO, int usuarioId)
        {
            string query = "";
            try
            {
                if (usuarioDTO.ID != usuarioId)
                {
                    return -3;
                }

                query = String.Format("UPDATE dbo.USUARIO SET NOMBRE = '{0}' , EMAIL = '{1}' WHERE ID = {2} ",
                        usuarioDTO.Nombre, usuarioDTO.Email, usuarioDTO.ID);

                return await _connectionSqlService.CrudDataToSql(query);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return -1;
            }
        }

        public async Task<int> DeleteUsuarioDb(int usuarioId)
        {

            try
            {
               var usuarioExistente = await _context.Usuario.FindAsync(usuarioId);

                if (usuarioExistente != null)
                {
                 _context.Usuario.Remove(usuarioExistente);

                return await _context.SaveChangesAsync();

                }
                else
                {
                    return -2;
                }
            }
            catch (InvalidOperationException ex)
            {
                string axel = ex.ToString();
                return -1;
            }

        }
    
    }
}
