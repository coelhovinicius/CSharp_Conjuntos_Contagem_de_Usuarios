/* >>> PROGRAMA PRINCIPAL <<< */
using System;
using System.IO;
using System.Collections.Generic;
using Aula211_Conjuntos_Ex1.Entities;

namespace Aula211_Conjuntos_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<LogRecord> set = new HashSet<LogRecord>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine(); // Le o caminho do arquivo informado

            try // Tenta a execucao
            {
                using (StreamReader sr = File.OpenText(path)) // Le o arquivo de "path" e atribui a "sr"
                {
                    while (!sr.EndOfStream) // Loop - Enquanto nao chegar ao fim
                    {
                        string[] line = sr.ReadLine().Split(' '); // Le a linha e atribui ao vetor "line"
                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        set.Add(new LogRecord(name, instant));
                        // Console.WriteLine(name + " " + instant); // Imprime a linha na tela
                    }
                    Console.WriteLine("Total users: " + set.Count );
                }
            }
            catch (IOException e) // Caso de erro
            {
                Console.WriteLine(e.Message); // Exibe mensagem
            }
        }
    }
}