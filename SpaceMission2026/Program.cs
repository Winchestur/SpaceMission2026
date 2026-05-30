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

            if (rows < 2 || rows > 100 || cols < 2 || cols > 100)
            {
                Console.WriteLine("Invalid map size. Rows and columns must be between 2 and 100.");
                return;
            }

            Console.WriteLine("Cosmic map: ");

            string[,] matrix = new string[rows, cols];

            List<Astronaut> astronauts = new();

            int checkForSpaceStation = 0;

            // Read the cosmic map and identify astronauts
            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length != cols)
                {
                    Console.WriteLine(
                        $"Expected {cols} columns but got {input.Length}.");
                    return;
                }

                if (input.Any(x =>
                     x != "0" &&
                     x != "X" &&
                     x != "F" &&
                     !x.StartsWith("S")))
                {
                    Console.WriteLine("Invalid map symbol.");
                    return;
                }

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col].StartsWith('S'))
                    {
                        astronauts.Add(new Astronaut(matrix[row, col], row, col));
                    }
                    
                    else if (matrix[row, col] == "F")
                    {
                        checkForSpaceStation++;
                    }
                }
            }

            if (checkForSpaceStation != 1)
            {
                Console.WriteLine("The map must contain exactly one space station.");
                return;
            }

            if (astronauts.Count == 0 || astronauts.Count > 3)
            {
                Console.WriteLine("Invalid number of astronauts. There must be between 1 and 3 astronauts on the map.");
                return;
            }



            // Create a PathFinder instance and find paths for each astronaut
            PathFinder pathFinder = new PathFinder(matrix);

            List<MissionResult> results = new();
            List<string> failedAstronauts = new();

            // Find paths for each astronaut and store results
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