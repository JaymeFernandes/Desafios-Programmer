/*
     Crie um programa em C# que permita a um professor calcular a média das notas de alunos.

        1 - Solicitar ao professor o número de alunos para os quais deseja calcular a média.
        2 - Para cada aluno, solicitar o nome do aluno.
        3 - Para cada aluno, solicitar três notas (pode ser uma quantidade fixa de notas) e calcular a média das notas do aluno.
        4 - Exibir o nome do aluno, suas notas e a média de notas.


*/

/// <summary>
/// class Mein do Programa
/// </summary>
class media
{

    /// <summary>
    /// Menu Principal para Adicionar e ver notas
    /// </summary>
    static void Main()
    {
        List<alunos> listalunos = new List<alunos>();
        List<int> Nota = new List<int>();
        int Temp = 0, num, value;

        Console.Write("Quantas notas a serem inseridas: ");
        num = int.Parse(Console.ReadLine());

        //Menu
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - adicionar nota de aluno");
                Console.WriteLine("2 - Ver notas");
                Console.WriteLine("3 - Limpar notas");
                Console.WriteLine("4 - Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                value = int.Parse(Console.ReadLine());
                switch (value)
                {
                    case 1:
                        Console.Write("Nome do aluno: ");
                        string name = Console.ReadLine();
                        Nota.Clear();
                        while (Nota.Count < num)
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Valor da nota(0 a 10): {0} ", Nota.Count);
                                value = int.Parse(Console.ReadLine());
                                if (value <= 10 && value >= 0)
                                {
                                    Nota.Add(value);
                                }
                                else
                                {
                                    throw new ArgumentException("Nota Invalida para os parametros(0 a 10)");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Valor Invalido: " + ex.Message);
                                Console.ReadKey();
                            }
                        }
                        alunos aluno = new alunos(name, Nota);
                        listalunos.Add(aluno);
                        break;


                    case 2:
                        Console.Clear();
                        for (int i = 0; i < listalunos.Count; i++)
                        {
                            listalunos[i].VillAluno();
                        }
                        Console.ReadKey();
                        break;


                    case 3:
                        listalunos.Clear();
                        break;


                    case 4:
                        return;
                    default:
                        throw new Exception();


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Valor Invalido :" + ex.Message);
                Console.ReadKey();
            }
        }
    }
}

/// <summary>
/// class representando o aluno
/// </summary>
class alunos
{
    static int NumAluno;
    public int ID;
    public string Name;
    public List<int> Notas;

    public alunos(string Name, List<int> Notas)
    {
        this.Name = Name;
        this.Notas = Notas;
        ID = NumAluno++;
    }


    /// <summary>
    /// Método que faz o cálculo da Média do Aluno
    /// </summary>
    /// <returns>Média das Notas</returns>
    public int CalMedia()
    {
        int Temp = 0;
        for (int i = 0;i < Notas.Count; i++)
        {
            Temp += Notas[i];
        }
        return Temp / Notas.Count;
    }

    /// <summary>
    /// Método para a visualização dos alunos
    /// </summary>
    public void VillAluno()
    {
        Console.WriteLine("Aluno {0}",ID);
        Console.WriteLine("Nome {0}",Name);
        for (int i = 0; i < Notas.Count; i++)
        {
            Console.WriteLine("Nota {0}: {1}", i + 1, Notas[i]);
        }
        Console.WriteLine("Media Final: " + CalMedia().ToString());
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------------");
    }

}