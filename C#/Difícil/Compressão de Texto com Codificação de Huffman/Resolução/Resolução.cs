using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;

class Program
{
    /// <summary>
    /// Método Main do Programa
    /// </summary>
    static void Main()
    {
        string txt = 
            "Em uma cidade muito distante, vivia uma pequena garota chamada Maria. Maria adorava brincar no parque perto de sua casa. Todos os dias, depois da escola, ela corria para o parque para brincar no balanço, escalar o escorregador e construir castelos de areia. Ela adorava observar as nuvens passando e imaginava que elas eram formas de animais, castelos e outras coisas maravilhosas.\r\n\r\nUm dia, enquanto Maria estava no parque, ela viu uma pequena borboleta azul. A borboleta parecia tão bonita e graciosa que Maria decidiu segui-la. A borboleta voou por todo o parque, passando pelas flores coloridas, sobre o lago cintilante e finalmente pousou em uma árvore grande e antiga.\r\n\r\nMaria se aproximou da árvore e notou algo brilhante preso em um dos galhos. Era uma pequena chave dourada. Maria pegou a chave e notou que havia uma pequena porta escondida na base da árvore. Ela colocou a chave na fechadura e girou. Para sua surpresa, a porta se abriu.\r\n\r\nDentro da árvore, Maria encontrou um pequeno quarto cheio de livros, brinquedos e um pequeno sofá. Parecia o lugar perfeito para se aconchegar e ler um livro. Maria decidiu que este seria seu pequeno refúgio secreto.\r\n\r\nTodos os dias, depois de brincar no parque, Maria ia para seu pequeno quarto na árvore para ler e sonhar. Ela adorava seu pequeno refúgio secreto e a pequena borboleta azul que a levou até lá. E assim, todos os dias se tornaram uma pequena aventura para Maria, cheia de diversão, risos e descobertas.";
        HuffmanTree huffmanTree = new HuffmanTree(txt);
        string temp = "";
        string test1 = huffmanTree.Root.Comprimir(txt);
        string test2 = huffmanTree.Root.DesComprimir(test1);

        Console.WriteLine($"Comprimido: {test1}\n");
        Console.WriteLine("-------------------------------------------------------------------------------------------");
        Console.WriteLine($"\nDesComprimido: {test2}");
        Console.ReadLine();
    }
}

/// <summary>
/// Class Node para representar os nós
/// </summary>
class Node
{
    public string Symbol { get; set; }
    public int Frequencia { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    static private Dictionary<string, string> nodePositions = new Dictionary<string, string>();

    #region // Contrutor

    /// <summary>
    /// Contrutor dos nós
    /// </summary>
    /// <param name="Symbol">Simbolo a ser salvo</param>
    /// <param name="Frequencia">quantas vezes aparece no texto</param>
    public Node(string Symbol, int Frequencia, string Postion)
    {
        this.Symbol = Symbol;
        this.Frequencia = Frequencia;
        this.Left = null;
        this.Right = null;
    }

    #endregion





    #region // Metodos

    /// <summary>
    /// método para chamar a recursividade para salvar as posições no nodePositions
    /// </summary>
    /// <returns>nodePositions - Todas as posições das letras</returns>
    public Dictionary<string, string> SaveNodePositions()
    {
        SaveNodePositionsRecursive(this, "");

        return nodePositions;
    }

    /// <summary>
    /// Método que salva sua posição e chama a resursividade para salvar as outras
    /// </summary>
    /// <param name="node">Nós das arvore</param>
    /// <param name="currentPosition">Posição na arvore</param>
    static void SaveNodePositionsRecursive(Node node, string currentPosition)
    {
        if (node != null)
        {
            //verifica se posição é nula
            if (!string.IsNullOrEmpty(currentPosition))
            {
                //salva a posição se ela tive 1 caracter
                nodePositions[(node.Symbol.Length == 1 ? node.Symbol : "")] = currentPosition;
                node.Symbol = (node.Symbol.Length == 1 ? node.Symbol : null)
            }

            // recursividade
            SaveNodePositionsRecursive(node.Left, currentPosition + "0");
            SaveNodePositionsRecursive(node.Right, currentPosition + "1");
        }
    }

    /// <summary>
    /// Método para comprimir o texto de acordo com o caracter
    /// </summary>
    /// <param name="text">Texto a ser comprimido</param>
    /// <returns>texto comprimido</returns>
    public string Comprimir(string text)
    {
        SaveNodePositions();
        string temp = "";
        // busca nas posições salvas se existem a letra
        foreach (char tecla in text)
        {
            temp += nodePositions[tecla.ToString()];
        }
        nodePositions.Clear();
        return temp;

    }

    /// <summary>
    /// Método para descomprimir o texto de acordo com o caracter
    /// </summary>
    /// <param name="text">Texto a ser reconstruido</param>
    /// <returns>texto original</returns>
    public string DesComprimir(string text)
    {
        string temp = text;
        string result = "";
        // loop até não tiver mais texto comprimido
        while (temp.Length > 0)
        {
            result += DesComprimirChar(text, out temp);
            text = temp;
        }
        return result;
    }

    /// <summary>
    /// Método que busca a letra na arvore
    /// </summary>
    /// <param name="text">Texto com as posições</param>
    /// <param name="temp">Salvar a nova busca</param>
    /// <returns>Letra encontrada</returns>
    private string DesComprimirChar(string text, out string temp)
    {
        string result = Symbol;
        temp = text;

        if (text.Length > 0)
        {
            if (text.Substring(0, 1) == "0" && Left != null)
            {
                text = text.Substring(1, text.Length - 1);
                temp = text;
                result = Left.DesComprimirChar(text, out temp);
            }
            else if (text.Substring(0, 1) == "1" && Right != null)
            {
                text = text.Substring(1, text.Length - 1);
                temp = text;
                result = Right.DesComprimirChar(text, out temp);
            }
            else
            {
                result = this.Symbol;
            }
        }
        return result;
    }

    #endregion


}

/// <summary>
/// Claas que cria e organiza os galhos da arvore
/// </summary>
class HuffmanTree
{
    public Node Root { get; set; }

    public Dictionary<string, int> keys { get; set; }

    /// <summary>
    /// Contrutor
    /// </summary>
    /// <param name="Text">Texto a ser comprimido</param>
    public HuffmanTree(string Text)
    {
        string Symbol = "";
        int Frequencia = 0;
        keys = CountChar(Text);

        AddKeys();

    }

    #region // Manenger Values

    /// <summary>
    /// Conta quantos de cada caracteres tem no texto
    /// </summary>
    /// <param name="text">Texto original</param>
    /// <returns>Frequencia de cara letra</returns>
    public Dictionary<string, int> CountChar(string text)
    {
        Dictionary<string, int> frequencia = new Dictionary<string, int>();
        foreach (char c in text)
        {
            frequencia[c.ToString()] = (frequencia.ContainsKey(c.ToString()) ? frequencia[c.ToString()] + 1 : 1);
        }

        return frequencia;
    }
    
    /// <summary>
    /// Organiza a arvore
    /// </summary>
    public void AddKeys()
    {
        var Nodes = new List<Node>();
        Node node = null, value = null;
        var nodeskey = keys.ToList();

        foreach(var item in nodeskey)
        {
            Nodes.Add(new Node(item.Key, item.Value, ""));
        }

        while (keys.Count > 0)
        {
            var list = keys.OrderBy(x => x.Value).Take(2).ToList();
            var NodesTemp = new List<Node>();
            var indicesToRemove = new List<Node>();

            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int e = 0; e < list.Count; e++)
                {

                    if (list[e].Key == Nodes[i].Symbol)
                    {
                        NodesTemp.Add(Nodes[i]);
                        indicesToRemove.Add(Nodes[i]);
                    }
                }
            }

            foreach (var index in indicesToRemove)
            {
                Nodes.Remove(index);
            }

            if (NodesTemp.Count >= 2)
            {
                node = new Node(NodesTemp[0].Symbol + NodesTemp[1].Symbol, NodesTemp[0].Frequencia + NodesTemp[1].Frequencia, "");
                node.Right = (NodesTemp[0].Frequencia > NodesTemp[1].Frequencia ? NodesTemp[0] : NodesTemp[1]);
                node.Left = (NodesTemp[1].Frequencia < NodesTemp[0].Frequencia ? NodesTemp[1] : NodesTemp[0]);

                keys.Remove(list[0].Key);
                keys.Remove(list[1].Key);
                keys.Add(node.Symbol, node.Frequencia);

                NodesTemp.Clear();

                Nodes.Add(node);
            }
            else
            {
                Root = node;
                return;
            }


        }
    }

    #endregion


    

}

