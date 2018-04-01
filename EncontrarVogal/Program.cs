using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EncontrarVogal
{
    class Program
    {
        static void Main(string[] args)
        {
            EncontrarVogal vogal = new EncontrarVogal();

            Console.Write("Digite a stream:");
            StringStream str = new StringStream(Console.ReadLine());            
            char? c = vogal.primeiraVogal(str);

            if (c == null)
                Console.WriteLine("Não foi encontrada vogal não repetida após primeira consoante.");
            else
                Console.WriteLine("Vogal encontrada: " + c);

            Console.ReadLine();

        }
    }
}
