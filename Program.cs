public class Program
{
    private static void Main(string[] args)
    {
        IFactory<Board<PieceType>> boardFactory = new ChessBoardFactory();
        Board<PieceType> board = boardFactory.Create();

        ChessGameBuilder builder = new ChessGameBuilder();
        ChessGame game = builder
            .WithBoard(board)
            .WithCurrentPlayer(PlayerType.White)
            .Build();

        while(true)
        {
            game.Draw();
            game.Update();
        }
    }
}
