using Refit;
using System;
using System.Threading.Tasks;

namespace ConsultaCep
{
    class Program
    {
        class MainClass
        {
            static async Task Main(string[] args)
            {
                try
                {
                    var cepClient = RestService.For<ICepApiServece>("https://viacep.com.br");
                    Console.Write("Informe seu cep: ");

                    string cepInformado = Console.ReadLine().ToString();
                    Console.WriteLine("Consultado informações do CEP: " + cepInformado);

                    var address = await cepClient.GetAddressAsync(cepInformado);

                    Console.Write($"\nRua: {address.Logradouro}\nBairro: {address.Bairro}\nComplemento: {address.Complemento}\nCidade: {address.Localidade}\nuf: {address.Uf} ");

                    Console.ReadKey();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro na consulta de Cep: " + e.Message);
                    Console.WriteLine("Informe o Cep correto.");
                    Console.ReadLine();
                }
            }
        }
    }
}
