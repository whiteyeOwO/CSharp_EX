namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 99;
            Random rn = new Random();
            int bingo = rn.Next(min , max + 1);

            while (true)
            {
                Console.WriteLine("({0}, {1})?",min,max);
                int ans = int.Parse(Console.ReadLine());
                if (ans > max || ans < min)
                {
                    Console.WriteLine("Out of range. Try again?");
                    continue;
                }
                else if (ans < bingo) 
                { 
                    min = ans + 1;
                    if (max - min == 0)
                    {
                       Console.WriteLine("GG.");
                        break;
                    }
                    else
                    {
                       continue;
                    }
                }
                else if (ans > bingo)
                {
                    max = ans - 1;
                    if (max - min == 0)
                    {
                        Console.WriteLine("GG.");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (ans == bingo)
                {
                    Console.WriteLine("Bingo!!");
                    break;
                }
            }
        }
    }
}
