namespace SpaceMission2026
{
    public class Astronaut
    {
        public string? Name { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Astronaut(string name, int row, int col)
        {
            Name = name;
            Row = row;
            Col = col;
        }
    }
}
