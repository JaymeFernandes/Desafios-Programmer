/*

      Desafio da Sequência de Fibonacci
Este desafio tem como objetivo testar seus conhecimentos em programação em C# e sua capacidade de prever a próxima entrada na sequência de Fibonacci.


A sequência de Fibonacci é uma série de números em que cada número é a soma dos dois números anteriores. Ela começa com 0 e 1, e os números subsequentes são calculados somando os dois números anteriores. A sequência começa assim:

        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...
*/


class Principal
{
    /// <summary>
    /// Método Main
    /// </summary>
    static void Main()
    {
        try
        {
            Random random = new Random();
            int Resposta = CalcFibonacci(random.Next(1, 47));

            Console.Write("\nTente Adivinhar o Proximo Valor: ");
            int Value = int.Parse(Console.ReadLine());
            if (Value == Resposta)
            {
                Console.WriteLine("Acertou");
            }
            else
            {
                {
                    Console.WriteLine($"Valor Incorreto, a respoata era: {Resposta}");
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    /// <summary>
    /// Método para calcular o valor de Fibonacci
    /// </summary>
    /// <param name="num">Até qual posição calcular</param>
    /// <returns>O ultimo Valor Calculado/Zero(Se for invalido)</returns>
    static int CalcFibonacci(int num)
    {
        if(num > 0 && num <= 47)
        {
            int a = 0;
            int b = 1;

            Console.Write("Sequência de Fibonacci:");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"{a} ");
                int temp = a;
                a = b;
                b += temp;
            }
            Console.WriteLine();
            return a;
        }
        else { return 0; }
    }
}