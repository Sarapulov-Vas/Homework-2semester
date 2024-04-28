using Microsoft.VisualBasic;

namespace SkipList.Tests
{
    public class Tests
    {
        private SkipList<int> list;

        private int[] testData = [10, 20, 5, 30];

        private int[] expecctedResult = [5, 10, 20, 30];

        [SetUp]
        public void SetUp()
        {
            list = new ();
        }

        [Test]
        public void TestAddAndIndexer ()
        {
            foreach (var i in testData)
            {
                list.Add(i);
            }

            Assert.That(list.Count, Is.EqualTo(expecctedResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(expecctedResult[i]));
            }
        }

        [Test]
        public void TestAddAndEnumerator ()
        {
            foreach (var i in testData)
            {
                list.Add(i);
            }
            
            Assert.That(list.Count, Is.EqualTo(expecctedResult.Length));
            var j = 0;
            foreach (var i in list)
            {
                Assert.That(i, Is.EqualTo(expecctedResult[j]));
                ++j;
            }
        }

        [Test]
        public void TestConstructor ()
        {
            list = new (testData.ToList());
            
            Assert.That(list.Count, Is.EqualTo(expecctedResult.Length));
            var j = 0;
            foreach (var i in list)
            {
                Assert.That(i, Is.EqualTo(expecctedResult[j]));
                ++j;
            }
        }

        [Test]
        public void TestConstructorAndAdd ()
        {
            list = new (testData.ToList());
            Assert.That(list.Count, Is.EqualTo(expecctedResult.Length));
            var j = 0;
            foreach (var i in list)
            {
                Assert.That(i, Is.EqualTo(expecctedResult[j]));
                ++j;
            }

            list.Add(100);
            Assert.That(list[^1], Is.EqualTo(100));
        }

        [Test]
        public void TestIndexerSet ()
        {
            Assert.Throws<NotSupportedException>(() => list[0] = 10);
        }

        [Test]
        public void TestClear ()
        {
            foreach (var i in testData)
            {
                list.Add(i);
            }
            
            Assert.That(list.Count, Is.EqualTo(expecctedResult.Length));
            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));
            int a = 0;
            Assert.Throws<InvalidOperationException>(() => a = list.GetEnumerator().Current);
        }

        [Test]
        public void TestContains ()
        {
            Assert.That(list.Contains(5), Is.False);

            foreach (var i in testData)
            {
                list.Add(i);
            }
            
            foreach (var i in expecctedResult)
            {
                Console.WriteLine(i);
                Assert.That(list.Contains(i), Is.True);
            }

            Assert.That(list.Contains(100), Is.False);
        }

        [Test]
        public void TestCopyTo ()
        {
            foreach (var i in testData)
            {
                list.Add(i);
            }
            int[]? testArray = null;
            Assert.Throws<ArgumentException>(() => list.CopyTo(testArray, 0));
            testArray = new int[3];
            Assert.Throws<ArgumentException>(() => list.CopyTo(testArray, 0));
            testArray = new int[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(testArray, -1));
            list.CopyTo(testArray, 0);
            Assert.That(testArray, Is.EqualTo(expecctedResult));
        }

        [Test]
        public void TestIndexOf ()
        {
            Assert.That(list.IndexOf(5), Is.EqualTo(-1));
            foreach (var i in testData)
            {
                list.Add(i);
            }

            int j = 0;
            foreach (var i in expecctedResult)
            {
                Assert.That(list.IndexOf(i), Is.EqualTo(j));
                j++;
            }

            Assert.That(list.IndexOf(100), Is.EqualTo(-1));
        }

        [Test]
        public void TestInsert ()
        {
            Assert.Throws<NotSupportedException>(() => list.Insert(0, 1));
        }

        [Test]
        public void TestRemove ()
        {
            Assert.That(list.Remove(5), Is.False);
            foreach (var i in testData)
            {
                list.Add(i);
            }

            Assert.That(list.Remove(100), Is.False);
            Assert.That(list.Remove(10), Is.True);
            int[] intermediateResult = [5, 20, 30];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }

            Assert.That(list.Remove(30), Is.True);
            intermediateResult = [5, 20];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }

            Assert.That(list.Remove(5), Is.True);
            intermediateResult = [20];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }
        }

        [Test]
        public void TestRemoveAt ()
        {
            foreach (var i in testData)
            {
                list.Add(i);
            }

            list.RemoveAt(1);
            int[] intermediateResult = [5, 20, 30];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }

            list.RemoveAt(2);
            intermediateResult = [5, 20];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }

            list.RemoveAt(0);
            intermediateResult = [20];
            Assert.That(list.Count, Is.EqualTo(intermediateResult.Length));
            for (int i = 0; i < list.Count; ++i)
            {
                Assert.That(list[i], Is.EqualTo(intermediateResult[i]));
            }
        }
    }
}