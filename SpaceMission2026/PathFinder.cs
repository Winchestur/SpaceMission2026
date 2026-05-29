namespace SpaceMission2026
{
    public class PathFinder
    {
        private readonly string[,] matrix;
        private readonly int[] dRow = { -1, 1, 0, 0 };
        private readonly int[] dCol = { 0, 0, -1, 1 };

        public PathFinder(string[,] matrix)
        {
            this.matrix = matrix;
        }

        public string[,] FindPath(Astronaut astronaut)
        {
            Queue<(int row, int col, int count)> queue = new();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            (int row, int col)[,] path = new (int row, int col)[rows, cols];
            bool[,] visited = new bool[rows, cols];

            string[,] newMatrix = (string[,])matrix.Clone();

            int startRow = astronaut.Row;
            int startCol = astronaut.Col;

            visited[startRow, startCol] = true;
            queue.Enqueue((startRow, startCol, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                int currentRow = current.row;
                int currentCol = current.col;
                int count = current.count;

                for (int i = 0; i < 4; i++)
                {
                    int newRow = currentRow + dRow[i];
                    int newCol = currentCol + dCol[i];

                    if (newRow >= 0 && newRow < rows &&
                        newCol >= 0 && newCol < cols &&
                        !visited[newRow, newCol] &&
                        matrix[newRow, newCol] != "X")
                    {
                        if (matrix[newRow, newCol] == "F")
                        {
                            path[newRow, newCol] = (currentRow, currentCol);

                            DrawPath(
                                newMatrix,
                                path,
                                startRow,
                                startCol,
                                newRow,
                                newCol);

                            return newMatrix;
                        }

                        if (matrix[newRow, newCol] == "O")
                        {
                            visited[newRow, newCol] = true;
                            path[newRow, newCol] = (currentRow, currentCol);

                            queue.Enqueue((newRow, newCol, count + 1));
                        }
                    }
                }
            }

            return newMatrix;
        }

        private void DrawPath(
            string[,] newMatrix,
            (int row, int col)[,] path,
            int startRow,
            int startCol,
            int finishRow,
            int finishCol)
        {
            int row = finishRow;
            int col = finishCol;

            while (!(row == startRow && col == startCol))
            {
                if (newMatrix[row, col] != "F")
                {
                    newMatrix[row, col] = "*";
                }

                var previous = path[row, col];

                row = previous.row;
                col = previous.col;
            }
        }
    }
}