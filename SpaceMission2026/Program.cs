namespace SpaceMission2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Map rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Map columns: ");
            int cols = int.Parse(Console.ReadLine());
            Console.WriteLine("Cosmic map: ");

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

            List<MissionResult> results = new();
            List<string> failedAstronauts = new();

            foreach (Astronaut astronaut in astronauts)
            {
                MissionResult? result = pathFinder.FindPath(astronaut);

                if (result == null)
                {
                    failedAstronauts.Add(astronaut.Name!);
                }
                else
                {
                    results.Add(result);
                }
            }

            foreach (string astronautName in failedAstronauts)
            {
                Console.WriteLine($"Mission failed — Astronaut {astronautName} lost in space!");
            }

            foreach (MissionResult result in results.OrderBy(r => r.Steps))
            {
                Console.WriteLine($"Astronaut {result.AstronautName} - Shortest path: {result.Steps} steps");

                PrintMatrix(result.Map!);
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