using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace TestConsole
{
    class Program
    {
        static IRepository<Book> bookRepo;
        static IRepository<User> userRepo;
        static void Main(string[] args)
        {
            bookRepo = new BookRepository();
            var t = bookRepo.GetById("583498563c1bc62554f87301");
             if (t != null)
            {
                t.Title = "new Title";
                bookRepo.Update(t);
            }
            //var a = bookRepo.GetAll();
            //foreach(var t in a)
            //{
            //   Console.WriteLine(t.Title);
            //  bookRepo.Delete(t);
            //}
            //bookRepo.Save(new Book { Author = "a", CopiesAvailable = 2, Pages = 700, Title = "t", YearPublication = 2002 , Image = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 } });
        }
    }
}
