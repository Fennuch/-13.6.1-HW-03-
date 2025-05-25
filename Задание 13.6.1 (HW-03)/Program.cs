namespace Задание_13._6._1__HW_03_
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main()
        {
            // Чтение текста из файла
            string filePath = "input.txt"; 
            string text = File.ReadAllText(filePath);

            // Разделение текста на слова
            char[] separators = new char[] { ' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Всего слов для вставки: {words.Length}");

            // Тестирование List<string>
            TestCollectionInsertion<List<string>>(words, "List<string>");

            // Тестирование LinkedList<string>
            TestCollectionInsertion<LinkedList<string>>(words, "LinkedList<string>");
        }

        static void TestCollectionInsertion<T>(string[] words, string collectionName) where T : ICollection<string>, new()
        {
            var stopwatch = Stopwatch.StartNew();
            T collection = new T();

            foreach (string word in words)
            {
                collection.Add(word);
            }

            stopwatch.Stop();
            Console.WriteLine($"Вставка в {collectionName} заняла: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
