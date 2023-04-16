public interface IPieceMoveStrategy
{
    ICollection<BoardPosition> GetPossibleMoves(GameBoard<PlayerType, PieceType> board, BoardPosition position);
}
