/// <summary>
/// Class Main
/// </summary>
class Principal
{
    /// <summary>
    /// Class Main do Console
    /// </summary>
    static void Main()
    {
        Console.Write("Digite a palavra: ");
        string palavra = Console.ReadLine();

        Console.Clear();
        Console.WriteLine(ValidatePalindromo(palavra) ? $"{palavra} é um Palindromo" : $"{palavra} não é um Palindromo");
    }


    /// <summary>
    /// Método que verifica se é um palindromo 
    /// </summary>
    /// <param name="Palavra">Palavra a ser verificada</param>
    /// <returns>o resultado a verificação(true/false)</returns>
    static bool ValidatePalindromo(string Palavra)
    {
        string palavra = Palavra.Replace(" ", "").ToLower();
        string palavra2 = new string (palavra.Reverse().ToArray());

        return (palavra == palavra2);
    }
}