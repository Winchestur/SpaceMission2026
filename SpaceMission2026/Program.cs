namespace SpaceMission2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            string[,] matrix = new string[rows, cols];

            List<Astronaut> astronauts = new();

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col].StartsWith('S'))
                    {
                        astronauts.Add(new Astronaut(matrix[row, col], row, col));
                    }
                }
            }

            PathFinder pathFinder = new PathFinder(matrix);

            foreach (Astronaut astronaut in astronauts)
            {
                string[,] resultMatrix = pathFinder.FindPath(astronaut);

                Console.WriteLine($"Path for {astronaut.Name}:");
                PrintMatrix(resultMatrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);

                    if (col < matrix.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}