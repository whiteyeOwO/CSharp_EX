namespace HW4
{
    interface IStrategy
    {
        int Next(int min, int max);
    }

    abstract class Player : IStrategy
    {
        public string id { get; }

        public Player(string id)
        {
            this.id = id;
        }

        public abstract int Next(int min, int max);
    }

    class Human : Player
    {
        public Human(string id) : base(id) { }

        public override int Next(int min, int max)
        {
            Console.WriteLine("({0}, {1})?", min, max);
            int ans = int.Parse(Console.ReadLine());
            return ans;
        }
    }

    class RandomPlayer : Player
    {
        private Random rng = new Random();

        public RandomPlayer(string id) : base(id) { }

        public override int Next(int min, int max)
        {
            return rng.Next(min, max + 1);
        }
    }

    class BinaryPlayer : Player
    {
        public BinaryPlayer(string id) : base(id) { }

        public override int Next(int min, int max)
        {
            return (min + max) / 2;
        }
    }

    class SuperAI : Player
    {
        public SuperAI(string id) : base(id)
        {
        }

        public override int Next(int min, int max)
        {
            return min;
        }
    }

    class Game
    {
        private int bingo;
        private int min, max;
        private bool win;
        private Player player;

        public Game(Player player, int min = 0, int max = 99)
        {
            this.min = min;
            this.max = max;
            Random rn = new Random();
            bingo = rn.Next(min, max + 1);
            this.player = player;
            win = false;
        }

        public bool IsWin()
        {
            return win;
        }

        public void Run()
        {
            while (true)
            {
                int ans = player.Next(min, max);

                if (ans > max || ans < min)
                {
                    continue;
                }
                else if (ans < bingo)
                {
                    min = ans + 1;
                }
                else if (ans > bingo)
                {
                    max = ans - 1;
                }
                else
                {
                    win = true;
                    Console.WriteLine("Bingo.");
                    break;
                }

                if (min == max)
                {
                    Console.WriteLine("Game over.");
                    break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] players =
            {
                //new RandomPlayer("Random Guess"),
                //new BinaryPlayer("Binary Search"),
                new Human("Me")
            };

            foreach (var p in players)
            {
                Benchmark(p, 3);
            }
        }

        static void Benchmark(Player player, int N)
        {
            int success = 0;
            for (int i = 0; i < N; i++)
            {
                Game g = new Game(player);
                g.Run();
                if (g.IsWin()) success++;
            }

            Console.WriteLine("{0}'s win rate = {1,6:F2}%", player.id, 100.0 * success / N);
        }
    }
}
