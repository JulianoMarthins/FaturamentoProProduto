using System;
using System.Collections.Generic;
using System.IO;
using SistemaFaturamento.Entities;

namespace SistemaFaturamento
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\WorkSpace\ArquivoOrigem.txt";
            string targetPath = @"D:\WorkSpace\Out\summary.txt";

            List<Product> product = new List<Product>();


            try
            {
                using (StreamReader stream = File.OpenText(path))
                {
                    int contador = 0;
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();

                        string[] vetor = line.Split(',');

                        string name = vetor[0];
                        double price = double.Parse(vetor[1].Replace('.', ','));
                        int quantity = int.Parse(vetor[2]);

                        product.Add(new Product(name, price, quantity));
                        contador++;
                    }
                }

                using (StreamWriter novoArquivo = File.AppendText(targetPath))
                {
                    foreach (Product produto in product)
                    {
                        double total = produto.total();
                        novoArquivo.WriteLine(produto.name + "," + total);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An Error Occured!\n " + e.Message);
            }

            Console.WriteLine("Program completed successfully");
        }
    }
}

