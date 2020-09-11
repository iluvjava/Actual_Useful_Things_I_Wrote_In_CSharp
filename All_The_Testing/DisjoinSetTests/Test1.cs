using NUnit.Framework;
using DataStructure.UnionFind;
using static System.Console;
using System.Linq;

namespace All_The_Testing.DisjoinSetTests
{
    class TheTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            ArrayDisjointSet<int> Disj = new ArrayDisjointSet<int>();
            Disj.CreateSet(3); Disj.CreateSet(4);
            Disj.Join(4, 3);
            WriteLine($"{Disj.GetRepresentative(3)}; {Disj.GetRepresentative(4)}");

        }

        [Test]
        public void Test2()
        {
            DictionaryUnionFind<int> duf = new DictionaryUnionFind<int>();
            for (int I = 0; I < 5; I++)
            {
                duf.get(I);
            }
            duf.join(0, 1);
            Assert.True(duf.get(0) == 1);
            duf.join(1, 2);
            Assert.True(duf.get(0) == 2);
            duf.join(3, 4);
            duf.join(2, 3);
            foreach (int I in Enumerable.Range(0, 5))
            {
                Assert.True(duf.get(I) == 4);
            }

        }
    }
}
