using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _1.HashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
        }
    }
    public class BechmarkClass
    {
        static int arrLength = 10000;
        static int stringLength = 3;

        static string[] array = new string[arrLength];
        static HashSet<string> HashStr = new HashSet<string>();
        static string searchHash;
        static string searchStr;

        static Random rd = new Random();
        static BechmarkClass()
        {
            for (int i = 0; i < arrLength; i++)
            {
                array[i] = CreateString();
                HashStr.Add(CreateString());
            }
            searchStr = CreateString();
            searchHash = CreateString();
        }
        public static string CreateString()
        {
            string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            return new string(chars);
        }
        [Benchmark]
        public bool SearchStr()
        {
            for (int i = 0; i < arrLength; i++)
            {
                if (array[i] == searchStr)
                    return true;
            }
            return false;
        }
        [Benchmark]
        public bool SearchHash()
        {
            if (HashStr.Contains(searchHash))
            {
                return true;
            }
            return false;
        }
    }
}
