namespace SpiderAndFly
{
    internal class Program
    {
        const int X = 0;
        const int Y = 1;
        const int Z = 2;
        static void Main()
        {
            string path = @"input.txt";

            int[] size = new int[3];
            int[] spider_XYZ = new int[3];
            int[] fly_XYZ = new int[3];

            using (var sr = new StreamReader(path))
            {
                size = Array.ConvertAll(sr.ReadLine().Split(' ').ToArray(), int.Parse);
                spider_XYZ = Array.ConvertAll(sr.ReadLine().Split(' ').ToArray(), int.Parse);
                fly_XYZ = Array.ConvertAll(sr.ReadLine().Split(' ').ToArray(), int.Parse);
            }

            bool just_Line = false;
            double answer = 0;

            for (int i = 0; i < 3; i++)
            {

                if ((spider_XYZ[i] == 0 && fly_XYZ[i] == 0) || (spider_XYZ[i] == size[i] && fly_XYZ[i] == size[i]))
                {
                    answer = EWay(spider_XYZ, fly_XYZ, just_Line);
                    break;
                }
                else if ((spider_XYZ[i] == 0 && fly_XYZ[i] == size[i]) || (spider_XYZ[i] == size[i] && fly_XYZ[i] == 0))
                {
                    answer = HWay(size, spider_XYZ, fly_XYZ);
                }

                if (spider_XYZ[i] == fly_XYZ[i] && spider_XYZ[i] != 0 && spider_XYZ[i] != size[i])
                {
                    just_Line = true;
                }

            }

            answer = NWay(size, spider_XYZ, fly_XYZ, just_Line);

            Console.WriteLine(Math.Round(answer, 3));

            Console.ReadKey();
        }

        private static double HWay(int[] size, int[] spider_XYZ, int[] fly_XYZ)
        {
            double answer;
            bool just_HARDLine = false;

            int common_Side = -1;
            int[] other_Side = new int[2];

            for (int i = 0, n = 0; i < 3; i++)
            {
                if (((spider_XYZ[i] == 0 && fly_XYZ[i] == size[i]) || (spider_XYZ[i] == size[i] && fly_XYZ[i] == 0)) && common_Side == -1)
                {
                    common_Side = i;
                }
                else
                {
                    other_Side[n++] = i;
                }
            }

            if (spider_XYZ[other_Side[0]] == fly_XYZ[other_Side[0]] && spider_XYZ[other_Side[1]] == fly_XYZ[other_Side[1]]) just_HARDLine = true;

            double[] ways = new double[4];
            ways[0] = size[common_Side] + (size[other_Side[0]] - spider_XYZ[other_Side[0]]) + (size[other_Side[0]] - fly_XYZ[other_Side[0]]);
            ways[1] = size[common_Side] + spider_XYZ[other_Side[0]] + fly_XYZ[other_Side[0]];
            ways[2] = size[common_Side] + (size[other_Side[1]] - spider_XYZ[other_Side[1]]) + (size[other_Side[1]] - fly_XYZ[other_Side[1]]);
            ways[3] = size[common_Side] + spider_XYZ[other_Side[1]] + fly_XYZ[other_Side[1]];

            if (just_HARDLine)
            {
                answer = ways[0];

                for (int i = 1; i < 4; i++)
                {
                    answer = Math.Min(answer, ways[i]);
                }
            }
            else
            {
                ways[0] = Math.Sqrt(Math.Pow(ways[0], 2) + Math.Pow(Math.Abs(spider_XYZ[other_Side[1]] - fly_XYZ[other_Side[1]]), 2));
                ways[1] = Math.Sqrt(Math.Pow(ways[1], 2) + Math.Pow(Math.Abs(spider_XYZ[other_Side[1]] - fly_XYZ[other_Side[1]]), 2));
                ways[2] = Math.Sqrt(Math.Pow(ways[2], 2) + Math.Pow(Math.Abs(spider_XYZ[other_Side[0]] - fly_XYZ[other_Side[0]]), 2));
                ways[3] = Math.Sqrt(Math.Pow(ways[3], 2) + Math.Pow(Math.Abs(spider_XYZ[other_Side[0]] - fly_XYZ[other_Side[0]]), 2));

                answer = ways[0];

                for (int i = 1; i < 4; i++)
                {
                    answer = Math.Min(answer, ways[i]);
                }
            }

            return answer;
        }

        private static double NWay(int[] size, int[] spider_XYZ, int[] fly_XYZ, bool just_Line)
        {
            double answer;
            if (just_Line)
            {
                answer = Math.Abs(spider_XYZ[X] - fly_XYZ[X]) + Math.Abs(spider_XYZ[Y] - fly_XYZ[Y]) + Math.Abs(spider_XYZ[Z] - fly_XYZ[Z]);
            }
            else
            {
                int spider_Side = -1;
                int fly_Side = -1;
                int other_Side = -1;

                for (int i = 0; i < 3; i++)
                {
                    if ((spider_XYZ[i] == 0 || spider_XYZ[i] == size[i]) && spider_Side == -1)
                    {
                        spider_Side = i;
                    }
                    else if ((fly_XYZ[i] == 0 || fly_XYZ[i] == size[i]) && fly_Side == -1)
                    {
                        fly_Side = i;
                    }
                    else
                    {
                        other_Side = i;
                    }
                }

                answer = Math.Sqrt(Math.Pow(Math.Abs(spider_XYZ[fly_Side] - fly_XYZ[fly_Side]) + Math.Abs(spider_XYZ[spider_Side] - fly_XYZ[spider_Side]), 2) + Math.Pow(Math.Abs(spider_XYZ[other_Side] - fly_XYZ[other_Side]), 2));

            }

            return answer;
        }

        private static double EWay(int[] spider_XYZ, int[] fly_XYZ, bool just_Line)
        {
            double answer;
            if (just_Line)
            {
                answer = Math.Abs(spider_XYZ[X] - fly_XYZ[X]) + Math.Abs(spider_XYZ[Y] - fly_XYZ[Y]) + Math.Abs(spider_XYZ[Z] - fly_XYZ[Z]);
            }
            else
            {
                answer = Math.Sqrt(Math.Pow(Math.Abs(spider_XYZ[X] - fly_XYZ[X]), 2) + Math.Pow(Math.Abs(spider_XYZ[Y] - fly_XYZ[Y]), 2) + Math.Pow(Math.Abs(spider_XYZ[Z] - fly_XYZ[Z]), 2));
            }

            return answer;
        }
    }
}
