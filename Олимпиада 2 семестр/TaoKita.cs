namespace TaoKita
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(NormalizeText(Console.ReadLine().Split(' ')));
            Console.ReadKey();
        }

        static string NormalizeText(string[] text)
        {
            string[] tmp = new string[text.Length];
            int count = text.Length / 2;
            for (int i = 0; i < text.Length; i++)
            {
                count += Convert.ToInt32(Math.Pow(-1.0, i) * i);
                tmp[i] = NormalizeWord(text[count]);
            }
            return String.Join(" ", tmp);
        }

        static string NormalizeWord(string word)
        {
            char[] tmp = new char[word.Length];
            int count = word.Length / 2;
            for (int i = 0; i < word.Length; i++)
            {
                count += Convert.ToInt32(Math.Pow(-1.0, i) * i);
                tmp[i] = word[count];
            }
            return new string(tmp);
        }
    }
}
