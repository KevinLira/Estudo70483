using System;
using System.IO;

namespace EstudoCertificacaoExame70483
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("You are developing an application. The application includes a method" + 
                             " a method named ReadFile");
            Console.WriteLine("The ReadFile Method must meet the following requirements: ");
            Console.WriteLine(" * it must not make changes to the data file");
            Console.WriteLine(" * it must allow other processes to access the data file");
            Console.WriteLine(" * it must not throw an exception if the application attempts to open"+ 
                              " a data file that does no exist");
            string fn = "/Users/kevinlira/Projects/EstudoCertificacaoExame70483/EstudoCertificacaoExame70483/Program.cs";
            ReadFile(fn);
        }


        public static void ReadFile(string FileName){

            var fs = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
//            var fs1 = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fs.Dispose();
        }
    }
}
