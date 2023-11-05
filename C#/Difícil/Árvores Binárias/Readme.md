# Desafio : Árvores Binárias

Você deve criar um programa em C# que lida com a criação e manipulação de árvores binárias.

## Detalhes do desafio:

- Implemente uma classe Node para representar um nó em uma árvore binária. Cada nó deve ter um valor e referências para os nós filhos esquerdo e direito.

- Implemente uma classe BinaryTree que permite a construção de uma árvore binária. A classe deve ter um método para adicionar nós à árvore.

- Crie um método que percorra a árvore binária em ordem (inorder traversal) e imprima os valores dos nós em ordem crescente.

- Implemente um método para calcular a altura da árvore.

- Adicione um método para verificar se a árvore binária é uma árvore de busca binária (Binary Search Tree - BST). Uma BST é uma árvore binária em que os nós são organizados de maneira que o valor em cada nó seja maior do que todos os valores em seus nós à esquerda e menor do que todos os valores em seus nós à direita.

## Explicação:

Uma árvore binária é uma estrutura de dados amplamente utilizada em ciência da computação para armazenar e organizar informações de forma hierárquica. Ela consiste em nós interconectados, onde cada nó pode ter, no máximo, dois filhos: um filho à esquerda e outro à direita. A primeira instância de uma árvore binária é o nó raiz, que não possui pai.

<img src="https://arquivo.devmedia.com.br/artigos/Higor_Medeiros/ArvoreBinaria/ArvoreBinaria1.jpg" sizes="20px">

### Componentes Principais:

- Nó Raiz: O nó superior da árvore, não possui pai.
- Nó: Cada elemento individual na árvore que contém um valor e pode ter até dois filhos.
- Nó Filho: Os nós que são filhos de outro nó.
- Nó Folha: Os nós que não têm filhos.
- Filho à Esquerda e à Direita: Os dois filhos que um nó pode ter, sendo o filho à esquerda geralmente menor ou igual ao nó pai e o filho à direita geralmente maior.

## Exemplo Node:

``` csharp
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
}
```