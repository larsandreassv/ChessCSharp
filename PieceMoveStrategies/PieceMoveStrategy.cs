public class PieceMoveStrategy : IPieceMoveStrategy {
    private static readonly IPieceMoveStrategyFactory pieceMoveStrategyFactory = new PieceMoveStrategyFactory();

    public ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position) {
        var pieceType = board[position.X, position.Y];
        var moveStrategy = pieceMoveStrategyFactory.CreatePieceMoveStrategy(pieceType);
        return moveStrategy.GetPossibleMoves(board, position);
    }
}