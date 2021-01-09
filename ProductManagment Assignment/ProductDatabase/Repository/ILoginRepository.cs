using ProductModel.Models;
using ProductModels.Models;

namespace ProductDBA.Repository
{
    public interface ILoginRepository
    {
        Login GetUser(string email);

        int Register(Register r);
    }
}
