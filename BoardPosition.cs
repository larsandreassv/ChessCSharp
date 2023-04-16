public class BoardPosition
{
    public BoardPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public BoardPosition OffsetX(int x)
    {
        return new BoardPosition(X + x, Y);
    }

    public BoardPosition OffsetY(int y)
    {
        return new BoardPosition(X, Y + y);
    }

    public bool Valid()
    {
        return X < 8 && Y < 8 && X >= 0 && Y >= 0;
    }

    public override bool Equals(object obj)
    {
        if (obj is BoardPosition other)
        {
            return X == other.X && Y == other.Y;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
}
