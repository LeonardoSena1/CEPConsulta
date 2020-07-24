using Newtonsoft.Json;
using Refit;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace ConsultaCep
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Infome seu cep: ");
                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("");

                if (cepInformado.Length == 8)
                {
                    var client = new RestClient("https://viacep.com.br/ws/" + $"{cepInformado}" + "/json/");
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);

                    Console.WriteLine("Status da busca " + response.StatusCode);

                    var retorno = JsonConvert.DeserializeObject<CepResponse>(response.Content);

                    Console.WriteLine($"Rua: {retorno.Logradouro} \b\n" +
                                      $"Bairro: {retorno.Bairro} \b\n" +
                                      $"Cidade: {retorno.Localidade} \b\n" +
                                      $"Complemento: {retorno.Complemento} \b\n");

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cep mal informado");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erro na consulta de Cep... ");
                Console.WriteLine("Informe o Cep correto.");
                Console.ReadLine();
            }
            finally
            {
                Console.WriteLine("Busca concluida");
                Console.ReadKey();
            }
            Console.ReadKey();
        }
    }
}
