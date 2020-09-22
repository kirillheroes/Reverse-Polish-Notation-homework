using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Reverse_Polish_Notation
{
    class RPN
    {
        static public double Calculate(string str)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    string str_temp = string.Empty;
                    str_temp += str[i];
                    temp.Push(double.Parse(str_temp));
                }
                else if (("+-*/").IndexOf(str[i]) != -1)
                {
                    double fst = temp.Pop();
                    double snd = temp.Pop();

                    switch (str[i])
                    {
                        case '+': result = snd + fst; break;
                        case '-': result = snd - fst; break;
                        case '*': result = snd * fst; break;
                        case '/': result = snd / fst; break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }
    }

    class Program
    {
        static string[] tests = new string[4] { "12+4*3+", "725*-", "14-23+/" , "32+8*6-1-22*2+2/-" };

        static void Main(string[] args)
        {
            double result = 0;
            Stopwatch stop_watch = new Stopwatch();
            stop_watch.Reset();
            foreach (string input in tests)
            {
                stop_watch.Start();
                Console.WriteLine("{0}", input);
                for (int i = 0; i < 1000; i++)
                    result = RPN.Calculate(input);
                Console.WriteLine(result);
                stop_watch.Stop();
                Console.WriteLine("Время исполнения: {0} msec", stop_watch.ElapsedMilliseconds);
                Console.WriteLine();
                stop_watch.Reset();
            }
        }
    }
}
