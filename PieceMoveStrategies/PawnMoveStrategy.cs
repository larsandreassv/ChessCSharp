public class PawnMoveStrategy : IPieceMoveStrategy
{
    private readonly PlayerType playerType;

    public PawnMoveStrategy(PlayerType playerType)
    {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position)
    {
        if (playerType == PlayerType.White)
        {
            return GetWhitePawnMoves(board, position);
        }
        else
        {
            return GetBlackPawnMoves(board, position);
        }
    }

    private ICollection<BoardPosition> GetWhitePawnMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position)
    {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddJumpMove(0, 1);
        if (position.Y == 1)
        {
            possibleMoveBuilder.AddJumpMove(0, 2);
        }
        if (board[position.X - 1, position.Y + 1] != PieceType.Empty)
        {
            possibleMoveBuilder.AddJumpMove(-1, 1);
        }
        if (board[position.X + 1, position.Y + 1] != PieceType.Empty)
        {
            possibleMoveBuilder.AddJumpMove(1, 1);
        }
        return possibleMoveBuilder.Build();
    }

    private ICollection<BoardPosition> GetBlackPawnMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position)
    {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddJumpMove(0, -1);
        if (position.Y == 6)
        {
            possibleMoveBuilder.AddJumpMove(0, -2);
        }
        if (board[position.X - 1, position.Y - 1] != PieceType.Empty)
        {
            possibleMoveBuilder.AddJumpMove(-1, -1);
        }
        if (board[position.X + 1, position.Y - 1] != PieceType.Empty)
        {
            possibleMoveBuilder.AddJumpMove(1, -1);
        }
        return possibleMoveBuilder.Build();
    }
}
