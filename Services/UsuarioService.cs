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
using CodeFirst.HttpExceptions;

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
            string userList = "";
            try
            {
                query = @"select Id, Nombre,artista, genero, pais,ventas from dbo.USUARIO";
                userList = await _connectionSqlService.GetJsonFromSql(query);

                return userList;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return EnumExceptionsDescription.InternalError.Value;
            }
        }
       
        public async Task<string> SaveUsuarioDb(UsuarioCreatedDTO usuarioDTO)
        {
            string query = "";
            int idRowInsert = 0;
            try
            {
                query = String.Format("INSERT INTO dbo.USUARIO, (Nombre,Email) output inserted.ID VALUES('{0}', '{1}' )",usuarioDTO.Nombre, usuarioDTO.Email);

                idRowInsert = await _connectionSqlService.CrudDataToSql(query);

                return idRowInsert.ToString();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return EnumExceptionsDescription.InternalError.Value;
            }
        }

        public async Task<string> UpdateUsuarioDb(UsuarioUpdateDTO usuarioDTO)
        {
            string query = "";
            int idRowUdpate = 0;
            string response = "";
            try
            {
                query = String.Format("UPDATE dbo.USUARIO SET NOMBRE = '{0}' , EMAIL = '{1}'  OUTPUT INSERTED.ID WHERE ID = {2} ",
                        usuarioDTO.Nombre, usuarioDTO.Email, usuarioDTO.ID);

                idRowUdpate = await _connectionSqlService.CrudDataToSql(query);

                //si se ha actualizado (devolvemos el id borrado)
                if (idRowUdpate > 0)
                {
                    response = EnumExceptionsDescription.Success.Value;
                }
                //no se ha actualizado
                else
                {
                    response = EnumExceptionsDescription.Nofound.Value;
                }

                return response;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return EnumExceptionsDescription.InternalError.Value;
            }
        }

        public async Task<string> DeleteUsuarioDb(int usuarioId)
        {

            int idRowDelete = 0;
            string response = "";
            string query = "";

            try
            {
                query = String.Format("DELETE dbo.USUARIO OUTPUT deleted.ID WHERE ID ={0}", usuarioId);

                idRowDelete = await _connectionSqlService.CrudDataToSql(query);

                //si se ha borrado (devolvemos el id borrado)
                if (idRowDelete > 0)
                {
                    response = EnumExceptionsDescription.Success.Value;        
                }
                //no se ha borrado 
                else
                {
                    response = EnumExceptionsDescription.Nofound.Value;
                }

                return response;

            }
            //-1 por que ha petado 
            catch (Exception ex)
            {
                string axel = ex.ToString();
       
                return EnumExceptionsDescription.InternalError.Value;
            }

        }
    
    }
}
