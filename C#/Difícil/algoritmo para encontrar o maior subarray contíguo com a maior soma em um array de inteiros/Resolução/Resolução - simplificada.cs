/// <summary>
/// Class Main
/// </summary>
class Principal
{

    /// <summary>
    /// Método Main
    /// </summary>
    static void Main()
    {
        int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine(SubAray(array));
    }

    /// <summary>
    /// Método Que retorna a valor da maior soma do Sub array
    /// </summary>
    /// <param name="array">Lista de numeros para a busca da soma</param>
    /// <returns>O mais valor da soma no caso 6 que é a soma de [4, -1, 2, 1]</returns>
    static int SubAray(int[] array)
    {
        int maxSum = int.MinValue; 
        int currentSum = 0; 

        foreach (int num in array)
        {
            currentSum = Math.Max(num, currentSum + num);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}