using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        public (PointClass PointOne, PointClass PointTwo) GenerateClass()
        {
            var rand = new Random();
            var num = new int[4];
            for (int i = 0; i < 4; i++)
                num[i] = rand.Next(101);
            var pointOne = new PointClass();
            var pointTwo = new PointClass();
            pointOne.X = num[0];
            pointOne.Y = num[1];
            pointTwo.X = num[2];
            pointTwo.Y = num[3];
            var result = (PointOne: pointOne, PointTwo: pointTwo);
            return result;
        }
        public (PointStruct PointOne, PointStruct PointTwo) GenerateStruct()
        {
            var rand = new Random();
            var num = new int[4];
            for (int i = 0; i < 4; i++)
                num[i] = rand.Next(101);
            var pointOne = new PointStruct();
            var pointTwo = new PointStruct();
            pointOne.X = num[0];
            pointOne.Y = num[1];
            pointTwo.X = num[2];
            pointTwo.Y = num[3];
            var result = (PointOne: pointOne, PointTwo: pointTwo);
            return result;
        }
        [Benchmark]
        public void PointClassDistanceBench()
        {
            PointClassDistance(GenerateClass().PointOne, GenerateClass().PointTwo);
        }
        public static float PointClassDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointStructDistanceFloatBench()
        {
            PointStructDistanceFloat(GenerateStruct().PointOne, GenerateStruct().PointTwo);
        }
        public static float PointStructDistanceFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointStructDistanceDoubleBench()
        {
            PointStructDistanceDouble(GenerateStruct().PointOne, GenerateStruct().PointTwo);
        }
        public static double PointStructDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointDistanceShortBench()
        {
            PointDistanceShort(GenerateStruct().PointOne, GenerateStruct().PointTwo);
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        public class PointClass
        {
            public int X;
            public int Y;
        }
        public struct PointStruct
        {
            public int X;
            public int Y;
        }
    }
}
