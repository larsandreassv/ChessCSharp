public class KingMoveStrategy : IPieceMoveStrategy {
    private readonly PlayerType playerType;

    public KingMoveStrategy(PlayerType playerType) {
        this.playerType = playerType;
    }

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var possibleMoveBuilder = new PossibleMoveBuilder(board, position, playerType);
        possibleMoveBuilder.AddJumpMove(-1, -1);
        possibleMoveBuilder.AddJumpMove(-1, 0);
        possibleMoveBuilder.AddJumpMove(-1, 1);
        possibleMoveBuilder.AddJumpMove(0, -1);
        possibleMoveBuilder.AddJumpMove(0, 1);
        possibleMoveBuilder.AddJumpMove(1, -1);
        possibleMoveBuilder.AddJumpMove(1, 0);
        possibleMoveBuilder.AddJumpMove(1, 1);
        return possibleMoveBuilder.Build();
    }
}