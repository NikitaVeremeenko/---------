namespace Cube
{
    internal class Program
    {
        static void Main()
        {
            string path = @"input.txt";
            int dim;
            int count;
            int s_X;
            int s_Y;
            int s_Z;

            using (var sr = new StreamReader(path))
            {
                int[][] tmp = new int[2][];
                for (int i = 0; i < 2; i++)
                {
                    tmp[i] = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                }

                dim = tmp[0][0];
                count = tmp[0][1];
                s_X = tmp[1][0];
                s_Y = tmp[1][1];
                s_Z = tmp[1][2];
            }

            var rotates = new int[count][];

            using (var sr = new StreamReader(path))
            {
                sr.ReadLine();
                sr.ReadLine();
                for (int i = 0; i < count; i++)
                {
                    string str = sr.ReadLine();

                    string tmpS = ReplaceCoord(str);

                    rotates[i] = Array.ConvertAll(tmpS.Split(' ', '\n').ToArray(), int.Parse);
                }

                Console.WriteLine($"{s_X} {s_Y} {s_Z}");
            }


            for (int gen = 0; gen < count; gen++)
            {
                RotateCu(dim, ref s_X, ref s_Y, ref s_Z, rotates, gen);
            }

            Console.WriteLine($"{s_X} {s_Y} {s_Z}");

            Console.ReadKey();
        }

        private static void RotateCu(int dim, ref int s_X, ref int s_Y, ref int s_Z, int[][] rotates, int gen)
        {
            if (rotates[gen][0] == 1 && rotates[gen][1] == s_X)
            {
                if (rotates[gen][2] == -1)
                {
                    int a = 0;
                    for (int i = dim; i > 0; i--, a++)
                        if (s_Y == i)
                            break;

                    int b = 0;
                    for (int j = dim; j > 0; j--, b++)
                        if (s_Z == j)
                            break;

                    s_Y = 1 + b;
                    s_Z = (dim) - a;
                }
                else if (rotates[gen][2] == 1)
                {
                    int a = 0;
                    for (int i = 1; i <= dim; i++, a++)
                        if (s_Y == i)
                            break;

                    int b = 0;
                    for (int j = 1; j <= dim; j++, b++)
                        if (s_Z == j)
                            break;

                    s_Y = 1 + b;
                    s_Z = (dim) - a;
                }
            }
            else if (rotates[gen][0] == 2 && rotates[gen][1] == s_Y)
            {
                if (rotates[gen][2] == -1)
                {
                    int a = 0;
                    for (int i = dim; i > 0; i--, a++)
                        if (s_X == i)
                            break;

                    int b = 0;
                    for (int j = dim; j > 0; j--, b++)
                        if (s_Z == j)
                            break;

                    s_X = 1 + b;
                    s_Z = (dim) - a;
                }
                else if (rotates[gen][2] == 1)
                {
                    int a = 0;
                    for (int i = 1; i <= dim; i++, a++)
                        if (s_X == i)
                            break;

                    int b = 0;
                    for (int j = 1; j <= dim; j++, b++)
                        if (s_Z == j)
                            break;

                    s_X = 1 + b;
                    s_Z = (dim) - a;
                }
            }
            else if (rotates[gen][0] == 3 && rotates[gen][1] == s_Z)
            {
                if (rotates[gen][2] == -1)
                {
                    int a = 0;
                    for (int i = dim; i > 0; i--, a++)
                        if (s_X == i)
                            break;

                    int b = 0;
                    for (int j = dim; j > 0; j--, b++)
                        if (s_Y == j)
                            break;

                    s_X = 1 + b;
                    s_Y = (dim) - a;
                }
                else if (rotates[gen][2] == 1)
                {
                    int a = 0;
                    for (int i = 1; i <= dim; i++, a++)
                        if (s_X == i)
                            break;

                    int b = 0;
                    for (int j = 1; j <= dim; j++, b++)
                        if (s_Y == j)
                            break;

                    s_X = 1 + b;
                    s_Y = (dim) - a;
                }
            }
        }

        private static string ReplaceCoord(string str)
        {
            if (str[0] == 'Z')
            {
                return str.Replace('Z', '3');
            }
            else if (str[0] == 'Y')
            {
                return str.Replace('Y', '2');
            }
            else if (str[0] == 'X')
            {
                return str.Replace('X', '1');
            }

            return str;
        }
    }
}