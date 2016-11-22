using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace TestConsole
{
    class Program
    {
        static IBL bl_adapter;
        static void Main(string[] args)
        {
            bl_adapter = BL_imp.Insatnce;
            var coll = bl_adapter.GetBooksByAuthor("a");
            Console.WriteLine(coll[0].Author);
        }
    }
}
