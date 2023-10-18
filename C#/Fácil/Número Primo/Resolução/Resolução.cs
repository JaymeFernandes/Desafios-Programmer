using System;
using System.Numerics;
 internal class Principal()
{
    /*
     Um número primo é um número inteiro maior que 1 que só é divisível por 1 e por ele mesmo. Por exemplo, 2, 3, 5, 7, 11 são números primos.
     
     Este desafio envolve a compreensão dos conceitos de números primos e a implementação de um algoritmo eficiente para determinar se um número é primo.

     Passos:
     1 - Obter o valor a ser verificado do usuário.
     2 - Criar um método para a verificação.
     3 - Verificar se o número é negativo.
     4 - Verificar se o número é menor ou igual a 3.
     5 - Verificar se o número é divisível por 2 ou 3.
     6 - Verificar se o número é divisível por qualquer número além dele mesmo.
     7 - Exibir o resultado.

     Para a elaboração do desafio vamos usar a propriedade "%" que retorna o resto de uma divisão
    */

    static void Main()
    {
        try
        {
            int value = int.Parse(Console.ReadLine());
            if (IsPrime(value))
            {
                Console.WriteLine(value + " é um número primo");
            }
            else
            {
                Console.WriteLine(value + " não é um número primo");
            }
        }
        catch
        {
            Console.WriteLine("Erro no Valor passado");
        }
    }


    /// <summary>
    /// Verificar se o número é primo
    /// </summary>
    /// <param name="value"></param>
    /// <returns>se o número primo é true or false</returns>

    static bool IsPrime(int value)
    {
        if (value <= 1) return false;
        if (value <= 3) return true;
        if (value % 2 == 0 || value % 3 == 0) return false;
        for (int i = 5; i <= value; i += 6)
        {
            if(value % i == 0 ||  value % (i + 2) == 0)
            {
                return false;
            }
        }
        return true;
    }
}