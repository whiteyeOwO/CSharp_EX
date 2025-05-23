namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] A = new int[N];
            for (int i = 0; i < N; i++)
                A[i] = i;

            Random rng = new Random();
            for (int i = 0; i < N; i++)
            {
                int j = rng.Next(i, N);
                (A[i], A[j]) = (A[j], A[i]);
            }

            Console.Write($"{"ID",10}");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
            Console.Write($"{"Contactee",10}");
            foreach (var value in A)
                Console.Write($"{value,3}");
            Console.WriteLine();

            int target = 0;

            int current = target;
            do
            {
                Console.Write($"{current} ");
                current = A[current];
            }
            while (current != target);

        }
    }
}
