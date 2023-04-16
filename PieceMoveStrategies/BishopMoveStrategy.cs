public class BishopMoveStrategy : IPieceMoveStrategy {
    private readonly PlayerType playerType;

    public BishopMoveStrategy(PlayerType playerType) {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddDiagonalMove();
        return possibleMoveBuilder.Build();
    }
}
