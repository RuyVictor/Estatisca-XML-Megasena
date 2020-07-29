using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Megasena
{
    class Program
    {
        static void Main(string[] args)
        {
            char menu1;
            Console.WriteLine(".....CONSULTA AOS DADOS DA MEGASENA.....", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine();
            Console.WriteLine("-----------ESCOLHA UMA OPÇÃO-----------", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("1 - PROCURAR RESULTADOS POR NÚMERO DE SORTEIO:", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("2 - PROCURAR RESULTADOS POR DATA:");
            Console.WriteLine("3 - QUANTIDADE DE VEZES QUE CADA NÚMERO FOI SORTEADO:");
            Console.WriteLine("4 - OS 20 NÚMEROS QUE MAIS FORAM SORTEADOS:");
            Console.WriteLine("5 - OS 20 NÚMEROS QUE MENOS FORAM SORTEADOS:");
            Console.Write("INFORME A OPÇÃO --> ", Console.ForegroundColor = ConsoleColor.DarkGray);
            menu1 = char.Parse(Console.ReadLine());
            if (menu1 == '1')
            {
                ChamarOp1();
            }
            else if (menu1 == '2')
            {
                ChamarOp2();
            }
            else if (menu1 == '3')
            {
                ChamarOp3();
            }
            else if (menu1 == '4')
            {
                ChamarOp4();
            }
            else if (menu1 == '5')
            {
                ChamarOp5();
            }
            else
            {
                Console.WriteLine("OPÇÃO INVÁLIDA!");
            }
            Console.Read();
        }
        static void ChamarOp1()
        {
            XmlDocument document = new XmlDocument();
            document.Load("MEGASENA.xml");
            string opçao;
            Console.WriteLine("OPÇÃO 1\n\t---PROCURAR RESULTADOS POR NÚMERO DE SORTEIO---", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("DIGITE O NÚMERO DO SORTEIO: ");
            opçao = Convert.ToString(Console.ReadLine());
            XmlNodeList sorteio = document.SelectNodes("Megasena/Sorteio");
            foreach (XmlNode itens in sorteio)
            {
                string concurso = itens["Concurso"].InnerText;
                string data = itens["Data"].InnerText;
                string b1 = itens["B1"].InnerText;
                string b2 = itens["B2"].InnerText;
                string b3 = itens["B3"].InnerText;
                string b4 = itens["B4"].InnerText;
                string b5 = itens["B5"].InnerText;
                string b6 = itens["B6"].InnerText;
                if (opçao == concurso) Console.WriteLine($"Concurso: {concurso} Data: {data}\nNúmeros sorteados: {b1} {b2} {b3} {b4} {b5} {b6}", Console.ForegroundColor = ConsoleColor.White);
            }
        }
        static void ChamarOp2()
        {
            XmlDocument document = new XmlDocument();
            document.Load("MEGASENA.xml");
            string opçao;
            Console.WriteLine("OPÇÃO 2\n\t---PROCURAR RESULTADOS POR DATA---", Console.ForegroundColor = ConsoleColor.Green);
            Console.Write("DIGITE A DATA: ");
            opçao = Convert.ToString(Console.ReadLine());
            XmlNodeList sorteio = document.SelectNodes("Megasena/Sorteio");
            foreach (XmlNode itens in sorteio)
            {
                string concurso = itens["Concurso"].InnerText;
                string data = itens["Data"].InnerText;
                string b1 = itens["B1"].InnerText;
                string b2 = itens["B2"].InnerText;
                string b3 = itens["B3"].InnerText;
                string b4 = itens["B4"].InnerText;
                string b5 = itens["B5"].InnerText;
                string b6 = itens["B6"].InnerText;
                if (opçao == data) Console.WriteLine($"Concurso: {concurso} Data: {data}\nNúmeros sorteados: {b1} {b2} {b3} {b4} {b5} {b6}", Console.ForegroundColor = ConsoleColor.White);
            }
        }
        static void ChamarOp3()
        {
            XmlDocument document = new XmlDocument();
            document.Load("MEGASENA.xml");
            XmlNodeList sorteio = document.SelectNodes("Megasena/Sorteio");
            Console.WriteLine("OPÇÃO 3\n\t---QUANTIDADE DE VEZES QUE CADA NÚMERO FOI SORTEADO---", Console.ForegroundColor = ConsoleColor.Green);
            int[] numeros = new int[61];
            for (int i = 1; i < 61; i++)
            {
                foreach (XmlNode itens in sorteio)
                {
                    string b1 = itens["B1"].InnerText;
                    string b2 = itens["B2"].InnerText;
                    string b3 = itens["B3"].InnerText;
                    string b4 = itens["B4"].InnerText;
                    string b5 = itens["B5"].InnerText;
                    string b6 = itens["B6"].InnerText;
                    string n = $"{b1} {b2} {b3} {b4} {b5} {b6}";
                    string[] palavras = n.Split(' ');
                    if (palavras.Contains(i.ToString())) numeros[i]++;
                }
                Console.WriteLine($"O número: [{i}] caiu {numeros[i]} vezes.", Console.ForegroundColor = ConsoleColor.White);
            }
        }
        static void ChamarOp4()
        {
            XmlDocument document = new XmlDocument();
            document.Load("MEGASENA.xml");
            XmlNodeList sorteio = document.SelectNodes("Megasena/Sorteio");
            Console.WriteLine("OPÇÃO 4\n\t---OS 20 NÚMEROS QUE MAIS FORAM SORTEADOS---", Console.ForegroundColor = ConsoleColor.Green);
            int[] numeros = new int[61];
            int[] maiores = new int[61];
            int limitador = 0;
            for (int i = 1; i < 61; i++)
            {
                foreach (XmlNode itens in sorteio)
                {
                    string b1 = itens["B1"].InnerText;
                    string b2 = itens["B2"].InnerText;
                    string b3 = itens["B3"].InnerText;
                    string b4 = itens["B4"].InnerText;
                    string b5 = itens["B5"].InnerText;
                    string b6 = itens["B6"].InnerText;
                    string n = $"{b1} {b2} {b3} {b4} {b5} {b6}";
                    string[] palavras = n.Split(' ');
                    if (palavras.Contains(i.ToString())) numeros[i]++;
                }
            }
            Array.Copy(numeros, maiores, 61); Array.Sort(maiores); Array.Reverse(maiores);
            foreach (var item in maiores.Distinct())
            {
                limitador++;
                var index = Array.IndexOf(numeros, item);
                if (item > 0) Console.WriteLine($"O número: [{index}] caiu {item} vezes.", Console.ForegroundColor = ConsoleColor.White);
                if (limitador == 20) break;
            }
        }
        static void ChamarOp5()
        {
            XmlDocument document = new XmlDocument();
            document.Load("MEGASENA.xml");
            XmlNodeList sorteio = document.SelectNodes("Megasena/Sorteio");
            Console.WriteLine("OPÇÃO 4\n\t---OS 20 NÚMEROS QUE MAIS FORAM SORTEADOS---", Console.ForegroundColor = ConsoleColor.Green);
            int[] numeros = new int[61];
            int[] menores = new int[61];
            int limitador = 0;
            for (int i = 1; i < 61; i++)
            {
                foreach (XmlNode itens in sorteio)
                {
                    string b1 = itens["B1"].InnerText;
                    string b2 = itens["B2"].InnerText;
                    string b3 = itens["B3"].InnerText;
                    string b4 = itens["B4"].InnerText;
                    string b5 = itens["B5"].InnerText;
                    string b6 = itens["B6"].InnerText;
                    string n = $"{b1} {b2} {b3} {b4} {b5} {b6}";
                    string[] palavras = n.Split(' ');
                    if (palavras.Contains(i.ToString())) numeros[i]++;
                }

            }
            Array.Copy(numeros, menores, 61); Array.Sort(menores); //Array.Reverse(menores); Inversor
            foreach (var item in menores.Distinct())
            {
                limitador++;
                var index = Array.IndexOf(numeros, item);
                if (item > 0) Console.WriteLine($"O número: [{index}] caiu {item} vezes.", Console.ForegroundColor = ConsoleColor.White);
                if (limitador > 20) break;
            }
        }
    }
}