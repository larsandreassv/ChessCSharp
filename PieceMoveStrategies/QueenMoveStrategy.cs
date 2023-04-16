public class QueenMoveStrategy : IPieceMoveStrategy {
    private readonly PlayerType playerType;

    public QueenMoveStrategy(PlayerType playerType) {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddHorizontalMove();
        possibleMoveBuilder.AddVerticalMove();
        possibleMoveBuilder.AddDiagonalMove();
        return possibleMoveBuilder.Build();
    }
}
