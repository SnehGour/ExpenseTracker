using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Server.Model;
using Server.Repository.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly AppSettings _appsettings;
        public UserRepository(ApplicationDbContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appsettings = appsettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var user = _db.usersTbl.SingleOrDefault(x=>x.Username == username && x.Password == password);   
            
            // User doesn't exists
            if(user == null)
            {
                return null;
            }

            // User found & generating JWT Token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);

            // token descripter contains information about the token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public User Delete(int id)
        {
            var obj = _db.usersTbl.SingleOrDefault(x=>x.Id == id);
            if(obj == null)
            {
                return null;
            }
            _db.usersTbl.Remove(obj);
            _db.SaveChanges();
            return obj;
        }

        public ICollection<User> GetAll()
        {
            return _db.usersTbl.ToList();
        }

        public bool IsUserUnique(string username)
        {
            var user = _db.usersTbl.SingleOrDefault(x => x.Username == username);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public User Register(string username, string password)
        {
            User user = new User()
            {
                Username = username,
                Password = password,
            };

            _db.usersTbl.Add(user);
            _db.SaveChanges();
            user.Password = "";
            return user;
        }
    }
}
