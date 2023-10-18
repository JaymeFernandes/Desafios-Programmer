/*
    Sistema de Gerenciamento de Livros:

Este desafio tem como objetivo a criação de um sistema simples de gerenciamento de livros em C#. O sistema permitirá a adição de livros à biblioteca, a remoção de livros e a visualização de informações de livros existentes.

    Requisitos:

1 - Crie uma classe Book que represente um livro com as seguintes propriedades:
    Title (título do livro)
    NameAutor (nome do autor do livro)
    Date (data de lançamento do livro)

2 - Crie uma classe Library para gerenciar os livros.

*/


using System;
class Principal
{
    public int Value, day, month, year;
    static void Main()
    {
        Library library = new Library();
        int Value, day, month, year;
        while (true)
        {
            Vill(library);
            Console.WriteLine("\n1 - Adicionar livro");
            Console.WriteLine("2 - Remover Livro");
            Console.WriteLine("3 - Ver Livro");

            Value = int.Parse(Console.ReadLine());

            switch (Value)
            {
                case 1:
                    Option1(library);
                    break;

                case 2:
                    Option2(library);
                    break;

                case 3:
                    Option3(library);
                    break;
            }
        }
    }

    #region // Interface/options
    static void Vill(Library library)
    {
        int position = 0;
        List<string> list = library.AllBook();

        Console.Clear();
        Console.WriteLine("Quantidade de livros : {0}", list.Count);
        foreach(string item in list)
        {
            Console.WriteLine("{0} - {1}", position, item);
            position++;
        }
    }

    static void Option1(Library library)
    {
        int Value, day, month, year;

        Console.Clear();
        Console.Write("Nome Do Livro: ");
        string NameBook = Console.ReadLine();

        Console.Write("Nome Do Autor: ");
        string Name = Console.ReadLine();

        Console.Write("Dia de lançamento: ");
        day = int.Parse(Console.ReadLine());

        Console.Write("Mês de lançamento: ");
        month = int.Parse(Console.ReadLine());

        Console.Write("Ano de lançamento: ");
        year = int.Parse(Console.ReadLine());

        DateTime date = new DateTime(year, month, day);
        library.CreateNewBook(NameBook, Name, date);
    }

    static void Option2(Library library)
    {
        int Value;
        Vill(library);
        Console.Write("Digite a posição/nome do livro: ");
        var search = Console.ReadLine();

        if (int.TryParse(search, out Value))
        {
            library.RemoveBook(Value);
        }
        else
        {
            library.RemoveBook(search);
        }
    }

    static void Option3(Library library)
    {
        int Value;
        Vill(library);
        Console.Write("Digite a posição/nome do livro: ");
        string search = Console.ReadLine();
        List<string> values;
        if (int.TryParse(search, out Value))
        {
            values = library.VillBook(Value);
        }
        else
        {
            values = library.VillBook(library.SearchBook(search));
        }

        if (values != null)
        {
            Console.Clear();
            Console.WriteLine("Nome: {0}\nAutor: {1}\nLançamento: {2}\n", values[0], values[1], values[2]);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Não encontrado");
        }
        Console.ReadLine();
    }

    #endregion
}


/// <summary>
/// Class que representa o livro
/// </summary>
#region // Book Class
class Book
{
    public string Title { get; private set; }
    public string NameAutor { get; private set; }
    public DateTime Date { get; private set; }

    public Book(string Title, string NameAutor, DateTime Date)
    {
        this.Title = Title;
        this.NameAutor = NameAutor;
        this.Date = Date;
    }
}
#endregion

/// <summary>
/// Gerenciador dos Livros
/// </summary>
#region Gerenciador dos Livros
class Library
{
    static List<Book> books = new List<Book>();


    #region // Remoção/Criação dos Livros

    /// <summary>
    /// Cria um novo livro e o adiciona à biblioteca.
    /// </summary>
    /// <param name="title">Título do livro.</param>
    /// <param name="nameAutor">Nome do autor do livro.</param>
    /// <param name="date">Data de lançamento do livro.</param>
    public void CreateNewBook(string title, string nameAutor, DateTime date)
    {
        Book book = new Book(title, nameAutor, date);
        books.Add(book);
    }

    /// <summary>
    /// Remove um livros pela posição
    /// </summary>
    /// <param name="position">Posição no sistama do livro</param>
    public void RemoveBook(int position)
    {
        if (books.Count == 0 || position >= books.Count || position < 0) return;
        books.RemoveAt(position);
    }

    /// <summary>
    /// Remove um livro pelo Nome
    /// </summary>
    /// <param name="search">Nome a ser pesquisado</param>
    public void RemoveBook(string search)
    {
        RemoveBook(SearchBook(search));
    }
    #endregion



    #region // Ferramentas de Visualização/Pesquisas(Search)

    /// <summary>
    /// Metodo para pegar todos os nomes de livros no estoque
    /// </summary>
    /// <returns>lista de livros</returns>
    public List<string> AllBook()
    {
        List<string> list = new List<string>();
        foreach (Book book in books)
        {
            list.Add(book.Title);
        }
        return list;
    }

    /// <summary>
    /// Método para Ver um livro especifico
    /// </summary>
    /// <param name="position"></param>
    /// <returns>Lista com as Informações dos livros</returns>
    public List<string> VillBook(int position)
    {
        if (books.Count == 0 || position >= books.Count || position < 0) return null;

        return new List<string> { books[position].Title, books[position].NameAutor, books[position].Date.ToString() };
    }

    /// <summary>
    /// Ferramenta de pesquisa que retorna a posição de um livro pelo nome
    /// </summary>
    public int SearchBook(string search)
    {
        int position = 0;
        foreach (Book book in books)
        {
            if (book.NameAutor == search || book.Title == search) return position;
            position++;
        }
        return -1;
    }

    /// <summary>
    /// Metodo de pesquisa do livro
    /// </summary>
    /// <param name="search">Nome Do livro/autor pesquisado</param>
    /// <returns>retorna se o livro existe(verdadeiro/falso)</returns>
    public bool ContaisBook(string search)
    {
        foreach (Book book in books)
        {
            if (book.NameAutor == search || book.Title == search)
            {
                return true;
            }
        }
        return false;
    }

    #endregion
 
}
#endregion