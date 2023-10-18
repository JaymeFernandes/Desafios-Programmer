/*
Árvores Binárias:

Você deve criar um programa em C# que lida com a criação e manipulação de árvores binárias.

1 - Implemente uma classe Node para representar um nó em uma árvore binária. Cada nó deve ter um valor e referências para os nós filhos esquerdo e direito.

2 - Implemente uma classe BinaryTree que permite a construção de uma árvore binária. A classe deve ter um método para adicionar nós à árvore.

3 - Crie um método que percorra a árvore binária em ordem (inorder traversal) e imprima os valores dos nós em ordem crescente.

4 - Implemente um método para calcular a altura da árvore.

Desafio : Árvores Binárias


Exemplo visual:

                   Maior ->
                   Menor <-

                    (24)
                   /    \
               (10)      (32)
               /  \      /  \
             (5) (12)  (29) (35)



*/

using System.Runtime.CompilerServices;

/// <summary>
/// Class Principal/Main com a interface e a interação
/// </summary>
class Principal
{

    /// <summary>
    /// Método Main Da Interface e interação com o usuário
    /// </summary>
    /// <exception cref="ArgumentException">Caso a Resposta do usuário seja invalida</exception>
    static void Main()
    {

        Console.Write("Valor inicial: ");
        int value = int.Parse(Console.ReadLine());

        BinaryTree arvore = new BinaryTree();
        Node example = arvore.CreatNewNode(value);

        while (true)
        {
            try
            {
                Vill(example, arvore);
                Console.Write("Opção: ");
                value = int.Parse(Console.ReadLine());
                switch (value)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Valor a ser Criado: ");
                        value = int.Parse(Console.ReadLine());
                        arvore.CreatNewBranch(example, value);
                        break;
                    case 2:
                        Console.Clear();
                        arvore.OrdersNode(example);
                        Console.WriteLine();
                        Console.Write("Valor a ser Removido: ");
                        value = int.Parse(Console.ReadLine());
                        example.RemoveBranch(value);
                        break;
                    case 3:
                        Console.Clear();
                        arvore.OrdersNode(example);
                        Console.WriteLine();
                        Console.Write("Valor a ser Pesquisado: ");
                        value = int.Parse(Console.ReadLine());
                        Console.Write("Existe : {0}", example.ContaisValue(value));
                        Console.ReadKey();
                        break;
                    case 4:
                        return;
                        break;
                    default:
                        throw new ArgumentException("Valor invalido");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: {0}", ex.Message);
                Console.ReadKey();
            }
        }
    }


    /// <summary>
    /// Método para a visualização padrão da interface
    /// </summary>
    /// <param name="node"></param>
    /// <param name="tree"></param>
    static void Vill(Node node, BinaryTree tree)
    {
        Console.Clear();
        Console.Write("Árvore binária: ");
        tree.OrdersNode(node);
        Console.WriteLine($"\nAltura: {node.CalcAtura()}");
        Console.WriteLine("\n1 - Criar Nó");
        Console.WriteLine("2 - Remover Nó");
        Console.WriteLine("3 - Verificar se existe Valor");
        Console.WriteLine("4 - Sair");
    }
}


/// <summary>
/// Estrutura que representa os Nós da Arvore
/// </summary>
class Node
{
    public int Value;
    public Node Left {  get; set; }
    public Node Right { get; set; }
    
    public Node(int value, Node Left, Node Right)
    {
        this.Value = value;
        this.Left = Left;
        this.Right = Right;
    }


    /// <summary>
    /// Criação dos nós na árvore dentro do sistema
    /// </summary>
    /// <param name="value">Valor passado pelo Usuário</param>
    public void Create(int value)
    {
        if (value == Value)
        {
            return;
        }
        else if (value < Value)
        {
            if (Left == null)
            {
                Left = new Node(value, null, null);
            }
            else
            {
                Left.Create(value);
            }
        }
        else
        {
            if (this.Right == null)
            {
                Right = new Node(value, null, null);
            }
            else
            {
                Right.Create(value);
            }
        }
    }


    /// <summary>
    /// Metodo de busca recursivas se existe o valor
    /// </summary>
    /// <param name="value">Valor passado pelo Usuário<</param>
    /// <returns>Se Existe o Valor na árvore</returns>
    public bool ContaisValue(int value)
    {
        if(value == this.Value)
        {
            return true;
        }
        else if(value < this.Value && this.Left != null)
        {
            return this.Left.ContaisValue(value);
        }
        else if(this.Right != null)
        {
            return this.Right.ContaisValue(value);
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Remove o valor considerando as 3 possibilidades
    /// </summary>
    /// <param name="value">Valor passado pelo Usuário</param>
    /// <returns></returns>
    public Node RemoveBranch(int value)
    {
        if(value == Value)
        {
            //verifica se o valor uma Folha
            if(Left == null && Right == null)
            {
                return null;
            }
            //verifica se o valor é um galho com 1 parametro
            else if(Left == null || Right == null)
            {
                if(Left != null)
                {
                    return Left;
                }
                else
                {
                    return Right;
                }
            }
            //Caso o galho possua 2 Nós
            else
            {
                Node temp = Right;
                while(temp.Left != null)
                {
                    temp = temp.Left;
                }
                this.Value = temp.Value;
                Right.RemoveBranch(temp.Value);
            }
        }
        else if(value < Value && Left != null)
        {
            Left = Left.RemoveBranch(value);
            return this;
        }
        else if(value > Value  && Right != null)
        {
            Right = Right.RemoveBranch(value);
            return this;
        }
        return this;
    }


    public int CalcAtura()
    {
        if (this == null) return -1;

        int VLeft = Left?.CalcAtura() ?? 0;
        int VRigth = Right?.CalcAtura() ?? 0;

        return Math.Max(VLeft, VRigth) + 1;
    }
}


/// <summary>
/// Class do gerenciador Da árvore
/// </summary>
class BinaryTree
{
    

    /// <summary>
    /// Método para criação de uma nova Arvore
    /// </summary>
    /// <param name="value">Valor inicial</param>
    /// <returns>Retorna a Propria Arvore</returns>
    public Node CreatNewNode(int value)
    {
        Node Rood = new Node(value, null, null);
        return Rood;
    }


    /// <summary>
    /// Cria um novo galho na árvore
    /// </summary>
    /// <param name="Rood">Árvore</param>
    /// <param name="value">Valor a ser Adicionado</param>
    /// <exception cref="ArgumentException">Caso a Arvore não exista</exception>
    public void CreatNewBranch(Node Rood, int value)
    {
        if(Rood != null)
        {
            Rood.Create(value);
        }
        else
        {
            throw new ArgumentException("Falha na criação do galho");
        }
    }



    /// <summary>
    /// Escreve a árvore de forma Ordenada(Forma crescente)
    /// </summary>
    /// <param name="Rood"></param>
    public void OrdersNode(Node Rood)
    {
        if (Rood != null)
        {
            OrdersNode(Rood.Left);
            Console.Write(Rood.Value + " ");
            OrdersNode(Rood.Right);
        }
    }
}