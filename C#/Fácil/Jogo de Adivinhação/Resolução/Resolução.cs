using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main()
    {
        int max, value = 0, tentativas = 0, dicas = 0, DicasMax;

        Random random = new Random();

        Console.WriteLine("Qual dificuldade desejada (Caso a resposta seja invalida sera padrão o modo facil):");
        Console.WriteLine("1 - fácil (1 a 10, dicas ilimitadas)");
        Console.WriteLine("2 - médio (1 a 50, 10 dicas)");
        Console.WriteLine("3 - difícil (1 a 100, sem dicas)");
        Console.Write("Opção: ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                max = 10;
                DicasMax = -1;
                break;
            case 2:
                max = 50;
                DicasMax = 10;
                break;
            case 3:
                max = 100;
                DicasMax = 0;
                break;
            default:
                max = 10; // Dificuldade padrão: Fácil
                DicasMax = -1;
                break;
        }

        int num = random.Next(1, max);

        Console.Write("Precione qualquer tecla para começar o jogo (possui 10 tentativas por partida): ");

        do
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Tente adivinhar o número de 1 a {max} que foi sorteado");
            Console.Write("Digite o número: ");
            value = int.Parse(Console.ReadLine());
            tentativas++;

            if (value != num && DicasMax != 0)
            {
                Console.Clear();
                Console.Write(DicasMax != -1 ? $"Deseja uma dica (1 - sim | 2 - não) - Dicas disponíveis {DicasMax - dicas}: " : "Deseja uma dica (1 - sim | 2 - não) - Dicas disponíveis: ilimitado: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1 && dicas < DicasMax)
                {
                    Console.Clear();
                    Console.WriteLine(num < value ? $"O valor é menor do que o valor passado: {value}" : $"O valor é maior do que o valor passado: {value}");
                    dicas++;
                }
            }
        } while (num != value && tentativas < 10);

        Console.Clear();
        Console.WriteLine(num == value ? $"Parabens voce acertou {num}" : $"Infelizmente você errou o valor era {num}");

    }

}