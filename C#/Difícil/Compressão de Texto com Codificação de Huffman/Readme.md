# Desafio de Compressão de Texto com Codificação de Huffman

Este é um desafio de programação que envolve a criação de um programa em C# para realizar a compressão e descompressão de texto usando a codificação de Huffman.

## Descrição

O desafio consiste em criar um programa que seja capaz de comprimir e descomprimir texto usando a codificação de Huffman. A codificação de Huffman é um algoritmo de compressão amplamente usado que atribui códigos binários mais curtos a caracteres mais frequentes, resultando em uma redução no tamanho do texto.

### Funcionalidades

O programa deve ser capaz de:

- Criar uma árvore de Huffman com base no texto de entrada, onde cada nó na árvore representa um caractere e sua frequência no texto.
- Comprimir o texto de entrada usando os códigos binários atribuídos aos caracteres na árvore de Huffman.
- Descomprimir o texto comprimido usando a árvore de Huffman, reconstruindo o texto original.

## Requisitos

- O programa deve ser escrito em C#.
- A implementação deve incluir uma classe para representar os nós da árvore de Huffman.
- Você deve criar métodos para a compressão e descompressão de texto.
- A função de compressão deve gerar uma saída que represente o texto original usando códigos binários.
- A função de descompressão deve aceitar a saída da função de compressão e reconstruir o texto original.
- O programa deve ser capaz de lidar com texto de entrada de tamanho variável.
## Exemplo de Uso

Aqui está um exemplo de como o programa pode ser usado:

```csharp
string textoOriginal = "Este é um exemplo de texto para compressão com codificação de Huffman.";
HuffmanTree huffmanTree = new HuffmanTree(textoOriginal);
string textoComprimido = huffmanTree.Root.Comprimir(textoOriginal);
string textoDescomprimido = huffmanTree.Root.DesComprimir(textoComprimido);
Console.WriteLine("Texto Original: " + textoOriginal);
Console.WriteLine("Texto Comprimido: " + textoComprimido);
Console.WriteLine("Texto Descomprimido: " + textoDescomprimido);
```

## Observações

A codificação de Huffman é um algoritmo fundamental em compressão de dados e é usado em muitos sistemas de compactação, como arquivos ZIP. A implementação bem-sucedida desse desafio demonstrará um entendimento sólido de estruturas de dados, algoritmos de compressão e manipulação de árvores.
