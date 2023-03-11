using AutoMapper;
using BackEnd.DTO;
using BackEnd.ModeloDb;
using BackEnd.Utilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.DataAccessLogic
{
    public class UsuarioDALC
    {
        private readonly PruebaTecnicaContext _context;

        public UsuarioDALC(PruebaTecnicaContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Login(string usuario, string password)
        {
            var datos = new CredencialesDTO();
            //string enpasssword = Encrypt.GetSHA256(password);

            var respuestaDb = await _context.Usuarios.Where(u => u.NombreUsuario == usuario && u.Password == password).FirstOrDefaultAsync();

            return respuestaDb;

        }

        
    }
}
