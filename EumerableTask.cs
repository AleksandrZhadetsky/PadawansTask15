using System;
using System.Collections.Generic;
using System.Linq;

namespace PadawansTask15
{
    public class EnumerableTask
    {
        /// <summary> Transforms all strings to upper case.</summary>
        /// <param name="data">Source string sequence.</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase.
        /// </returns>
        /// <example>
        ///    {"a", "b", "c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            var result = data.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == null || result[i] == "")
                {
                    continue;
                }
                else
                {
                    var temp = result[i];
                    result[i] = null;
                    result[i] = temp.ToUpper();
                }
            }
            return result;
        }

        /// <summary> Transforms an each string from sequence to its length.</summary>
        /// <param name="data">Source strings sequence.</param>
        /// <returns>
        ///   Returns sequence of strings length.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a", "aa", "aaa" } => { 1, 2, 3 }
        ///   {"aa", "bb", "cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            var list = data.ToList();
            var result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null || list[i] == "")
                {
                    result.Add(0);
                }
                else
                {
                    result.Add(list[i].Length);
                }
            }
            return result;
        }

        /// <summary>Transforms integer sequence to its square sequence, f(x) = x * x. </summary>
        /// <param name="data">Source int sequence.</param>
        /// <returns>
        ///   Returns sequence of squared items.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            var list = data.ToList();
            var result = new List<long>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == 0)
                {
                    result.Add(0);
                }
                else
                {
                    result.Add(list[i] * list[i]);  //можно через метод Select(IEnumerable<TSource>, Func<TSource, TResult>)
                }
            }
            return result;
        }

        /// <summary> Filters a string sequence by a prefix value (case insensitive).</summary>
        /// <param name="data">Source string sequence.</param>
        /// <param name="prefix">Prefix value to filter.</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive).
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when prefix is null.</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix = "D"  => { }
        ///  { "a","b","c" }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix = null => ArgumentNullException
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            if (data == null | prefix == null)
            {
                throw new ArgumentNullException();
            }
            var source = data.ToList();
            var result = new List<string>();
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] == null || source[i].Length == 0)
                {
                    continue;
                }
                if (prefix.Length == 0)
                {
                    result.Add(source[i]);
                    continue;
                }
                else if (source[i].ToLower().Contains(prefix.ToLower()))
                {
                    if (source[i].ToLower()[0] == prefix.ToLower()[0])
                    {
                        result.Add(source[i]);
                    }
                }
            }
            return result;
        }

        /// <summary> Finds the 3 largest numbers from a sequence.</summary>
        /// <param name="data">Source sequence.</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3LargestItems(IEnumerable<int> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            var array = data.ToList<int>();
            var result = new List<int>();
            if (array.Count == 0)
            {
                return array;
            }
            array.Sort();  //чекнуть как этот метод сортирует, обязательно!
            if (array.Count < 3)
            {
                for (int i = array.Count - 1; i > -1; i--)
                {
                    result.Add(array[i]);
                }
            }
            else
            {
                for (int i = array.Count - 1; i > array.Count - 4; i--)
                {
                    result.Add(array[i]);
                }
            }
            return result;
        }

        /// <summary> Calculates sum of all integers from object array.</summary>
        /// <param name="data">Source array.</param>
        /// <returns>
        ///    Returns the sum of all integers from object array.
        /// </returns>
        /// <example>
        ///    { 1, true, "a", "b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllIntegers(object[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            int counter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null)
                {
                    counter++;
                }
            }
            if (counter == data.Length)
            {
                return 0;
            }
            int result = 0;
            var array = data.ToString().ToCharArray();
            foreach (var item in data)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.GetType() == typeof(int))
                {
                    result += int.Parse(item.ToString());
                }
            }
            return result;
        }
    }
}