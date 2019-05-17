using problema_mochila.pgm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_mochila
{
    class Program
    {
        static void Main(string[] args)
        {
            Mochila mochila = new Mochila(20);
            List<Item> listaDeItens = new List<Item>();
            listaDeItens.Add(new Item(5, 10));
            listaDeItens.Add(new Item(3, 5));
            listaDeItens.Add(new Item(8, 1));

            ISolver solver = new SolverProgramacaoDinamica(mochila, listaDeItens);
            Console.WriteLine(solver.Solucionar());

            Console.ReadKey();
        }
    }
}
