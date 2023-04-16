public class ChessGameBoardFactory : IFactory<GameBoard<PlayerType, PieceType>>
{
    private readonly ChessBoardFactory chessBoardFactory;
    private readonly Dictionary<PieceType, PlayerType> piecePlayerMap;

    public ChessGameBoardFactory() {
        this.chessBoardFactory = new ChessBoardFactory();
        this.piecePlayerMap = new Dictionary<PieceType, PlayerType> {
            { PieceType.RookWhite, PlayerType.White },
            { PieceType.KnightWhite, PlayerType.White },
            { PieceType.BishopWhite, PlayerType.White },
            { PieceType.QueenWhite, PlayerType.White },
            { PieceType.KingWhite, PlayerType.White },
            { PieceType.PawnWhite, PlayerType.White },
            { PieceType.RookBlack, PlayerType.Black },
            { PieceType.KnightBlack, PlayerType.Black },
            { PieceType.BishopBlack, PlayerType.Black },
            { PieceType.QueenBlack, PlayerType.Black },
            { PieceType.KingBlack, PlayerType.Black },
            { PieceType.PawnBlack, PlayerType.Black },
        };
    }

    public GameBoard<PlayerType, PieceType> Create()
    {
        var board = chessBoardFactory.Create();
        var gameBoard = new GameBoard<PlayerType, PieceType>(piecePlayerMap, board);
        return gameBoard;
    }
}