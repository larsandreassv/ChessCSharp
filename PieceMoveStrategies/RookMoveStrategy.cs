public class RookMoveStrategy : IPieceMoveStrategy {
    private readonly PlayerType playerType;

    public RookMoveStrategy(PlayerType playerType) {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddHorizontalMove();
        possibleMoveBuilder.AddVerticalMove();
        return possibleMoveBuilder.Build();
    }
}
