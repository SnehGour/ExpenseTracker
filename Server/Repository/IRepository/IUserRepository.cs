using Server.Model;

namespace Server.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<User> GetAll();
        bool IsUserUnique(string username);
        User Authenticate(string username, string password);
        User Register(string username, string password);
        User Delete(int id);  
    }
}
