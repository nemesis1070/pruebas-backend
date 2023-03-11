using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DataAccessLogic;
using BackEnd.DTO;
using BackEnd.ModeloDb;
using BackEnd.Utilidad;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.BusinessLogic.Servicios
{
    public class UsuarioService : IUsuarioBL
    {
        private PruebaTecnicaContext _db;
        private readonly AppSettings _app;
        public UsuarioService(PruebaTecnicaContext db, IOptions<AppSettings> app)
        {
            _db = db;
            _app = app.Value;
        }

        public async Task<CredencialesDTO> InicioSesion(LoginDTO modelo)
        {
            var datos = new CredencialesDTO();
            var respuesta = await new UsuarioDALC(_db).Login(modelo.NombreUsuario, modelo.Password);
            datos.Token = GetToken(respuesta);
            return datos;

        }

        private string GetToken(Usuario modelo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_app.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, modelo.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role,modelo.Rol)

                    }
                 ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
