using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        /// <summary>
        /// Method <c>ProcessarPlaca</c>
        /// Processa a placa deixando apenas as letras e números.
        /// </summary>
        /// <returns>
        /// Retorna uma string da placa apenas com os números e letras.
        /// </returns>
        private static string ProcessarPlaca(string placa)
        {
            return Regex.Replace(placa, "[^a-zA-Z0-9]", "").ToUpper();
        }

        /// <summary>
        /// Method <c>ValidarPlaca</c> Verifica se a placa segue o padrão de placas brasileiras.
        /// </summary>
        /// <returns>
        /// Retorna se placa possui o formato brasileiro.
        /// </returns>
        private static bool ValidarPlaca(string placa)
        {
            // Regex aceita AAA1234 (padrão antigo) ou AAA1B23 (padrão Mercosul)
            // após remoção de caracteres não alfanuméricos
            return Regex.IsMatch(placa, "^[A-Z]{3}\\d{4}$|^[A-Z]{3}\\d[A-Z]\\d{2}$");
        }

        public void AdicionarVeiculo()
        {
            // Solicita para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a placa do veículo para estacionar: \u001b[32m(Exemplo: ABC-1234 ou ABC1D23)\u001b[0m");

                string entrada = Console.ReadLine();
                string placa = ProcessarPlaca(entrada);

                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Veículo já adicionado");
                    break;
                }
                else if (ValidarPlaca(placa))
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo {placa} cadastrado com sucesso!");
                    Console.WriteLine("Pressione Enter para continuar.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Placa Inválida");
                Console.WriteLine("Pressione Enter para continuar.");
                Console.ReadLine();
            }
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");
            string entrada = Console.ReadLine();
            string placa = ProcessarPlaca(entrada);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;

                while (true)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    entrada = Console.ReadLine();

                    if (Int32.TryParse(entrada, out horas))
                    {
                        valorTotal = precoInicial + precoPorHora * horas;
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        break;
                    }
                    Console.WriteLine("Erro no número de horas digitadas");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }

        public void ListarVeiculos()
        {
            Console.Clear();

            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                string listaDeVeiculos = string.Empty;
                Console.WriteLine("Os veículos estacionados são:");
                // Repetição, adicionando a lista os veículos estacionados
                foreach (string placa in veiculos)
                {
                    listaDeVeiculos += $" - {placa}\n";
                }
                Console.WriteLine(listaDeVeiculos);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadLine();
        }
    }
}
