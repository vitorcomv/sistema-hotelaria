﻿using System.Text;
using sistema_hotelaria.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a lista para armazenar reservas
List<Reserva> reservas = new List<Reserva>();

// Controla a exibição do menu
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();

    // Exibe o cabeçalho e as opções do sistema
    Console.WriteLine("===== Sistema de Hotelaria =====");
    Console.WriteLine("1 - Cadastrar Reserva");
    Console.WriteLine("2 - Listar Reservas");
    Console.WriteLine("3 - Encerrar");
    Console.Write("Digite a sua opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();

            // Solicita os dias de hospedagem
            Console.Write("Quantos dias de hospedagem? ");
            int dias = int.Parse(Console.ReadLine());

            // Solicita o tipo da suíte
            Console.Write("Tipo da suíte: ");
            string tipoSuite = Console.ReadLine();

            // Solicita a capacidade da suíte
            Console.Write("Capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());

            // Solicita o valor da diária
            Console.Write("Valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            // Cria a suíte com os dados informados
            Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

            // Cria a reserva e associa a suíte
            Reserva reserva = new Reserva(dias);
            reserva.CadastrarSuite(suite);

            // Cria a lista de hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();

            // Solicita a quantidade de hóspedes
            Console.Write("Quantos hóspedes? ");
            int qtdHospedes = int.Parse(Console.ReadLine());

            // Solicita o nome de cada hóspede e adiciona à lista
            for (int i = 1; i <= qtdHospedes; i++)
            {
                Console.Write($"Nome do hóspede {i}: ");
                string nome = Console.ReadLine();
                hospedes.Add(new Pessoa(nome));
            }

            try
            {
                // Tenta cadastrar os hóspedes na reserva
                reserva.CadastrarHospedes(hospedes);

                // Adiciona a reserva à lista de reservas
                reservas.Add(reserva);

                Console.WriteLine("\nReserva cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                // Exibe mensagem de erro caso ocorra
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            // Pausa para o usuário voltar ao menu
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            break;

        case "2":
            Console.Clear();

            // Exibe o cabeçalho da listagem de reservas
            Console.WriteLine("===== Reservas Cadastradas =====");

            // Verifica se há reservas cadastradas
            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
            }
            else
            {
                // Exibe detalhes de cada reserva
                foreach (var r in reservas)
                {
                    Console.WriteLine($"Suíte: {r.Suite.TipoSuite} | " +
                                      $"Hóspedes: {r.ObterQuantidadeHospedes()} | " +
                                      $"Dias: {r.DiasReservados} | " +
                                      $"Valor Total: R$ {r.CalcularValorDiaria()}");
                }
            }

            // Pausa para o usuário voltar ao menu
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
            break;

        case "3":
            // Encerra o menu
            exibirMenu = false;
            break;

        default:
            // Mensagem de opção inválida
            Console.WriteLine("\nOpção inválida. Pressione ENTER para tentar novamente.");
            Console.ReadLine();
            break;
    }
}

