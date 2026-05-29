namespace SpaceMission2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            string[,] matrix = new string[rows, cols];

            // all astronauts with their starting point
            Dictionary<string, (int row, int col)> astronauts = new Dictionary<string, (int row, int col)>();

            //
            int count = 0;

            // fill the matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col].StartsWith('S'))
                    {
                        if (astronauts.ContainsKey(matrix[row, col]))
                        {
                            astronauts[matrix[row, col]] = (row, col);
                        }
                        else
                        {
                            astronauts.Add(matrix[row, col], (row, col));
                        }
                    }
                }
            }

            Queue<(int row, int col, int count)> queue = new();
            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            int newRow = 0;
            int newCol = 0;

            //Space travel logic

            foreach (var astronaut in astronauts)
            {
                (int row, int col)[,] path = new (int row, int col)[matrix.GetLength(0), matrix.GetLength(1)];
                bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
                string[,] newMatrix = (string[,] )matrix.Clone();

                int currentRow = astronaut.Value.row;
                int currentCol = astronaut.Value.col;
                int startRow = astronaut.Value.row;
                int startCol = astronaut.Value.col;
                visited[currentRow, currentCol] = true;

                queue.Enqueue((currentRow, currentCol, 0));

                while (queue.Count > 0)
                {
                    (int row, int col, int count) current = queue.Dequeue();
                    currentRow = current.row;
                    currentCol = current.col;
                    count = current.count;

                    for (int i = 0; i < 4; i++)
                    {
                        if (currentRow + dRow[i] >= 0 && currentRow + dRow[i] < matrix.GetLength(0) &&
                            currentCol + dCol[i] >= 0 && currentCol + dCol[i] < matrix.GetLength(1) &&
                            !visited[currentRow + dRow[i], currentCol + dCol[i]] &&
                            matrix[currentRow + dRow[i], currentCol + dCol[i]] != "X")
                        {
                            if (matrix[currentRow + dRow[i], currentCol + dCol[i]] == "F")
                            {
                                newRow = currentRow + dRow[i];
                                newCol = currentCol + dCol[i];
                                path[newRow, newCol] = (currentRow, currentCol);

                                int row = newRow;
                                int col = newCol;

                                while (!(row == startRow && col == startCol))
                                {
                                    if (newMatrix[row, col] != "F")
                                    {
                                        newMatrix[row, col] = "*";
                                    }

                                    (int row, int col) previous = path[row, col];

                                    row = previous.row;
                                    col = previous.col;
                                }
                                break;
                            }
                            if (matrix[currentRow + dRow[i], currentCol + dCol[i]] == "O")
                            {
                                newRow = currentRow + dRow[i];
                                newCol = currentCol + dCol[i];
                                visited[newRow, newCol] = true;
                                path[newRow, newCol] = (currentRow, currentCol);
                                queue.Enqueue((newRow, newCol, count + 1));
                            }
                        }
                    }
                }
            }
        }
    }
}
