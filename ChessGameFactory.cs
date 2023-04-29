public class ChessGameFactory : IFactory<ChessGame>
{
    private readonly IFactory<GameBoard<PlayerType, PieceType>> gameBoardFactory = new ChessGameBoardFactory();

    public ChessGame Create()
    {
        var board = gameBoardFactory.Create();
        
        var chessGameBuilder = new ChessGameBuilder();
        var game = chessGameBuilder
            .WithBoard(board)
            .WithCurrentPlayer(PlayerType.White)
            .Build();
        return game;
    }
}