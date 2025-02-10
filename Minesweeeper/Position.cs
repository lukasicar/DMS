namespace Minesweeeper
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Override Equals to compare positions correctly
        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   x == position.x &&
                   y == position.y;
        }

        // Override GetHashCode to ensure correct hash code generation
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        // To represent the position as a human-readable string (e.g., A1, B2)
        public string ToPositionString()
        {
            char column = (char)('A' + x);  // Convert x to a column letter
            int row = y + 1;  // Convert y to a row number (1-indexed)
            return $"{column}{row}";
        }
    }
}
