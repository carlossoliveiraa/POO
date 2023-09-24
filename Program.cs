using System;
using System.Collections.Generic;

// Interface para objetos que podem ser impressos
interface IPrintable
{
    void PrintInfo();
}

// Classe abstrata para representar uma pessoa
abstract class Pessoa
{
    // Propriedades públicas encapsuladas
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Construtor para inicializar dados básicos
    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

// Classe Cliente que herda de Pessoa e implementa IPrintable
class Cliente : Pessoa, IPrintable
{
    // Propriedade privada encapsulada
    private string endereco;

    // Propriedade pública com validação
    public string Endereco
    {
        get { return endereco; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                endereco = value;
        }
    }

    // Construtor que chama o construtor da classe base
    public Cliente(string nome, int idade, string endereco) : base(nome, idade)
    {
        Endereco = endereco;
    }

    // Implementação do método PrintInfo da interface IPrintable
    public void PrintInfo()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade}");
        Console.WriteLine($"Endereço: {Endereco}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando uma lista de clientes
        List<IPrintable> clientes = new List<IPrintable>
        {
            new Cliente("João", 30, "Rua A"),
            new Cliente("Maria", 25, "Rua B")
        };

        // Iterando e imprimindo informações dos clientes
        foreach (var cliente in clientes)
        {
            Console.WriteLine("Informações do Cliente:");
            cliente.PrintInfo();
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
