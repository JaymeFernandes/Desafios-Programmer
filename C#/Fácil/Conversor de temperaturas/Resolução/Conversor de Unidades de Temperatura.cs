using System;
using System.Numerics;

class Principal
{
    /*
    1 - Solicite ao usuário que insira a temperatura que deseja converter.
    2 - Peça ao usuário que escolha a unidade de temperatura de origem (Celsius, Fahrenheit ou Kelvin).
    3 - Peça ao usuário que escolha a unidade de temperatura de destino (Celsius, Fahrenheit ou Kelvin).
    4 - Realize a conversão da temperatura de acordo com a escolha do usuário.
    5 - Exiba o resultado da conversão.
    */


    
    static void Main()
    {
        double value = 0;
        int temp1 = 0, temp2 = 0;

        Console.Write("Digite a temperatura: ");
        value = double.Parse(Console.ReadLine());

        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Escolha a unidade de temperatura de origem:");
                Console.WriteLine("1. Celsius\n2. Fahrenheit\n3. kelvin");
                Console.Write("Opção: ");
                temp1 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadKey();
            }
        } while (temp1 < 1 || temp1 > 3);

        do
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Escolha a unidade de temperatura de destino:");
                Console.WriteLine("1. Celsius\n2. Fahrenheit\n3. kelvin");
                Console.Write("Opção: ");
                temp2 = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Valor invalido");
                Console.ReadKey();
            }
        } while (temp2 < 1 || temp2 > 3);
        ConvertTemp(value, temp1, temp2);
    }

    /// <summary>
    /// Metodo que verifica a Opções selecionadas e faz a fórmula correspondente
    /// </summary>
    /// <param name="value">Valor a ser convertido.</param>
    /// <param name="temp1">Opção de temperatura de origem.</param>
    /// <param name="temp2">Opção de temperatura de destino.</param>

    static void ConvertTemp(double value, int temp1, int temp2)
    {
        double convertTemp;
        ///<summary>Celsius</summary>
        if(temp1 == 1 && temp2 == 2)
        {
            convertTemp = (value * 9 / 5) + 32;
            Console.WriteLine("Resultado: {0} Celsius é equivalente a {1} Fahrenheit",value, convertTemp);
        }
        if(temp1 == 1 && temp2 == 3)
        {
            convertTemp = value + 273.15;
            Console.WriteLine("Resultado: {0} Celsius é equivalente a {1} Kelvin", value, convertTemp);
        }
        
        ///<summary>Fahrenheit</summary>
        if(temp1 == 2 && temp2 == 1)
        {
            convertTemp = (value - 32) * 5 / 9;
            Console.WriteLine("Resultado: {0} Fahrenheit é equivalente a {1} Celsius", value, convertTemp);
        }
        if(temp1 == 2 && temp2 == 3)
        {
            convertTemp = (value - 32) * 5 / 9 + 273.15;
            Console.WriteLine("Resultado: {0} Fahrenheit é equivalente a {1} Kelvin", value, convertTemp);
        }

        ///<summary>Kelvin</summary>
        if(temp1 == 3 && temp2 == 1)
        {
            convertTemp = value - 273.15;
            Console.WriteLine("Resultado: {0} Kelvin é equivalente a {1} Celsius", value, convertTemp);
        }
        if(temp1 == 3 && temp2 == 2)
        {
            convertTemp = (value - 273.15) * 9 / 5 + 32;
            Console.WriteLine("Resultado: {0} Kelvin é equivalente a {1} Fahrenheit", value, convertTemp);
        }
    }
}

