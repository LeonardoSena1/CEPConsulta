using Refit;
using System.Threading.Tasks;

namespace ConsultaCep
{
    public interface ICepApiServece
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);

    }
}
