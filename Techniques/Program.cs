using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Techniques
{
    public static class Program
    {
        private static bool NextCombination(IList<int> num, int n, int k)
        {
            bool finished;

            var changed = finished = false;

            if (k <= 0) return false;

            for (var i = k - 1; !finished && !changed; i--)
            {
                if (num[i] < n - 1 - (k - 1) + i)
                {
                    num[i]++;

                    if (i < k - 1)
                        for (var j = i + 1; j < k; j++)
                            num[j] = num[j - 1] + 1;
                    changed = true;
                }
                finished = i == 0;
            }

            return changed;
        }

        private static IEnumerable Combinations<T>(IEnumerable<T> elements, int k)
        {
            var elem = elements.ToArray();
            var size = elem.Length;

            if (k > size) yield break;

            var numbers = new int[k];

            for (var i = 0; i < k; i++)
                numbers[i] = i;

            do
            {
                yield return numbers.Select(n => elem[n]);
            } while (NextCombination(numbers, size, k));
        }


        private static void Main()
        {
            const int k = 13;
            var n = new[] { "1", "1", "1", "1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "1", "1", "1", "1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "1", "1", "1", "1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            Console.Write("n: ");
            foreach (var item in n)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine("k: {0}", k);
            Console.WriteLine();

            for (int j = 1; j < n.Length; j++)
            {
                foreach (IEnumerable<string> i in Combinations(n, j))
                    Console.WriteLine(string.Join(" ", i));

            }
            Console.ReadLine();
        }
    }
}