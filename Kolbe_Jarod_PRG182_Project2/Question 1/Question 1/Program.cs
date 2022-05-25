using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            int option;
            bool done = false;

            words = InitList();

            while (done == false)
            {
                option = GetMenu(words);
                if(option == words.Count)
                {
                    done = true;
                }
                else
                {
                    GetVowels(words, option);
                }
            }
        }
        static public List<string> InitList()
        {
            List<string> words = new List<string>();
            Console.WriteLine("Insert 10 words:\n");

            for (int i = 0; i < 10; i++)
            {
                words.Add(Console.ReadLine());
            }

            words.Sort();
            return words;
        }
        static public int GetMenu(List<string> words)
        {
            Console.WriteLine("\nSelect a word:\n");

            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, words[i]);
            }
            Console.WriteLine("{0}. to exit", words.Count + 1);

            return int.Parse(Console.ReadLine()) - 1;
        }
        static public void GetVowels(List<string> words, int option)
        {
            string word = words[option];
            int a = 0, e = 0, i = 0, o = 0, u = 0;

            foreach(var item in word.ToLower())
            {
                switch (item)
                {
                    case 'a':
                        a++;
                        break;
                    case 'e':
                        e++;
                        break;
                    case 'i':
                        i++;
                        break;
                    case 'o':
                        o++;
                        break;
                    case 'u':
                        u++;
                        break;
                }
            }

            Console.WriteLine("\nWord chosen is {0}\na = {1}\ne = {2}\ni = {3}\no = {4}\nu = {5}", word, a, e, i, o, u);
        }
    }
}
