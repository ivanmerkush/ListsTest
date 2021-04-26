using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ListsTest
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class TestMethods
    {
        private readonly Random rnd = new();
        private bool[] differentValues;
        private bool[] randomValues;
        
        public TestMethods()
        {
            differentValues = new bool[1000000];
            randomValues = new bool[1000000];

            for(int i = 0; i < 1000000; i++)
            {
                differentValues[i] = i % 2 == 0;
                randomValues[i] = rnd.Next(1, 10001) % 2 == 0;
            }
        }

        //Generating new values for each test

        [Benchmark(Description = "ArrayList with Same Value")]
        public void FillListWithSameValue()
        {
            List<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(true);
            }
        }

        [Benchmark(Description = "ArrayList with New Different Value")]
        public void FillListWithDifferentValue()
        {
            List<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(i % 2 == 0);
            }
        }

        [Benchmark(Description = "ArrayList with New Random Value")]
        public void FillListWithRandomValue()
        {
            List<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(rnd.Next(1, 10001) % 2 == 0);
            }
        }

        [Benchmark(Description = "LinkedList with Same value")]
        public void FillLinkedListWithSameValue()
        {
            LinkedList<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.AddFirst(true);
            }
        }

        [Benchmark(Description = "LinkedList with New Different Value")]
        public void FillLinkedListWithDifferentValue()
        {
            LinkedList<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.AddFirst(i % 2 == 0);
            }
        }

        [Benchmark(Description = "LinkedList with New Random Value")]
        public void FillLinkedListWithRandomValue()
        {
            LinkedList<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.AddFirst(rnd.Next(1, 10001) % 2 == 0);
            }
        }

        //Using already generated values

        [Benchmark(Description = "ArrayList with Preinitialized Different Value")]
        public void FillListWithInitializedDifferentValue()
        {
            List<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(differentValues[i]);
            }
        }

        [Benchmark(Description = "ArrayList with Preinitialized Random Value")]
        public void FillListWithInitializedRandomValue()
        {
            List<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(randomValues[i]);
            }
        }

        [Benchmark(Description = "LinkedList with Preinitialized Different Value")]
        public void FillLinkedListWithInitializedDifferentValue()
        {
            LinkedList<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.AddFirst(differentValues[i]);
            }
        }

        [Benchmark(Description = "LinkedList with Preinitialized Random Value")]
        public void FillLinkedListWithInitializedRandomValue()
        {
            LinkedList<bool> list = new();
            for (int i = 0; i < 1000000; i++)
            {
                list.AddFirst(randomValues[i]);
            }
        }
    }
}
