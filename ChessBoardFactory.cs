public class ChessBoardFactory : IFactory<Board<PieceType>> {
    public Board<PieceType> Create() {
        Board<PieceType> board = new Board<PieceType>();
        board[0, 0] = PieceType.RookWhite;
        board[1, 0] = PieceType.KnightWhite;
        board[2, 0] = PieceType.BishopWhite;
        board[3, 0] = PieceType.QueenWhite;
        board[4, 0] = PieceType.KingWhite;
        board[5, 0] = PieceType.BishopWhite;
        board[6, 0] = PieceType.KnightWhite;
        board[7, 0] = PieceType.RookWhite;
        for (int i = 0; i < 8; i++)
        {
            board[i, 1] = PieceType.PawnWhite;
        }
        board[0, 7] = PieceType.RookBlack;
        board[1, 7] = PieceType.KnightBlack;
        board[2, 7] = PieceType.BishopBlack;
        board[3, 7] = PieceType.QueenBlack;
        board[4, 7] = PieceType.KingBlack;
        board[5, 7] = PieceType.BishopBlack;
        board[6, 7] = PieceType.KnightBlack;
        board[7, 7] = PieceType.RookBlack;
        for (int i = 0; i < 8; i++)
        {
            board[i, 6] = PieceType.PawnBlack;
        }
        return board;
    }
}