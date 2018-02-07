using System.Threading.Tasks;

namespace ngScaffolding.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUser();
    }
}