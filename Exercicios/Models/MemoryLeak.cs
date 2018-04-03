using System;
using System.Diagnostics;
using System.Text;

namespace Exercicios.Models
{
    public class MemoryLeak
    {
        public static readonly string[] ArrayDeString = {
        "Aqui vai uma sting",
        "Aqui vai outra string um pouco maior", 
        "Aqui vai uma outra string que santa mae de Deus, é maior ainda que a outra"
         };

        static readonly int TamanhoEsperado = string.Join("", ArrayDeString).Length;

        static void Main()
        {
            Time(StringBuilderTest);
            Time(ConcatenateTest);
        }

        static void Time(Action action)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // Eu vou varrendo vou varrendo vou varrendo
            action();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}: {1} millisegundos", action.Method.Name,
                              (long)sw.Elapsed.TotalMilliseconds);
        }

        static void ConcatenateTest()
        {
            string x = "";
            foreach (string @string in ArrayDeString)
            {
                x = string.Concat(x,@string);
            }
            // Ouvi dizer que quando o metodo é simples, o Framework usa sua magica para
            // otimizar o codigo, entao coloquei essa "validacao" burra aqui pra nao ter chances
            if (x.Length != TamanhoEsperado)
            {
                throw new Exception("Vish");
            }
        }

        static void StringBuilderTest()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string @string in ArrayDeString)
            {
                sb.Append(@string);
            }
            string x = sb.ToString();
            // Ouvi dizer que quando o metodo é simples, o Framework usa sua magica para
            // otimizar o codigo, entao coloquei essa "validacao" burra aqui pra nao ter chances
            if (x.Length != TamanhoEsperado)
            {
                throw new Exception("Vish");
            }
        }
    }
}
}