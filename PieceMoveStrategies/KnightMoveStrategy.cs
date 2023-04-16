public class KnightMoveStrategy : IPieceMoveStrategy {
    private readonly PlayerType playerType;

    public KnightMoveStrategy(PlayerType playerType) {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddJumpMove(-2, -1);
        possibleMoveBuilder.AddJumpMove(-2, 1);
        possibleMoveBuilder.AddJumpMove(-1, -2);
        possibleMoveBuilder.AddJumpMove(-1, 2);
        possibleMoveBuilder.AddJumpMove(1, -2);
        possibleMoveBuilder.AddJumpMove(1, 2);
        possibleMoveBuilder.AddJumpMove(2, -1);
        possibleMoveBuilder.AddJumpMove(2, 1);
        return possibleMoveBuilder.Build();
    }
}
