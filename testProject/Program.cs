using SRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Lista<int> lista = new Lista<int>
            {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8
            };

            foreach (var element in lista)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
            
        }
    }
}
