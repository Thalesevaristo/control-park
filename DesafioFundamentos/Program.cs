using System.Threading.Tasks.Dataflow;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.Clear();
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
Console.ResetColor();

Console.WriteLine("Digite o preço inicial:");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

// Loop do menu
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    int opcao = Menu();

    switch (opcao)
    {
        case 1:
            es.AdicionarVeiculo();
            break;

        case 2:
            es.RemoverVeiculo();
            break;

        case 3:
            es.ListarVeiculos();
            break;

        case 4:
            exibirMenu = false;
            Console.WriteLine("O programa será encerrado");
            break;
    }
}

/// <summary>
/// Função para exibir o menu com navegação via setas
/// </summary>
int Menu()
{
    int opcao = 1;
    ConsoleKeyInfo key;
    bool escolhido = false;

    while (!escolhido)
    {
        Console.Clear();
        Console.WriteLine("Use ↑ e ↓ para navegar ou digite a opção e pressione \u001b[32mEnter\u001b[0m para selecionar:\n");

        string seletor = "\u001b[33m> ";
        string final = "\u001b[0m";

        Console.WriteLine($"{(opcao == 1 ? seletor : "  ")}1 - Cadastrar veículo {final}");
        Console.WriteLine($"{(opcao == 2 ? seletor : "  ")}2 - Remover veículo {final}");
        Console.WriteLine($"{(opcao == 3 ? seletor : "  ")}3 - Listar veículos { final}");
        Console.WriteLine($"{(opcao == 4 ? seletor : "  ")}4 - Sair {final}");

        key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.D1:
                opcao = 1;
                break;
            case ConsoleKey.D2:
                opcao = 2;
                break;
            case ConsoleKey.D3:
                opcao = 3;
                break;
            case ConsoleKey.D4:
                opcao = 4;
                break;
            case ConsoleKey.UpArrow:
                opcao = (opcao == 1) ? 4 : opcao - 1;
                break;
            case ConsoleKey.DownArrow:
                opcao = (opcao == 4) ? 1 : opcao + 1;
                break;
            case ConsoleKey.Enter:
                escolhido = true;
                break;
        }
    }

    return opcao;
}
