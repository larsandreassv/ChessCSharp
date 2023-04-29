public class Program
{
    private static void Main(string[] args)
    {
        IFactory<ChessGame> chessGameFactory = new ChessGameFactory();
        var game = chessGameFactory.Create();

        while(true)
        {
            game.Draw();
            game.Update();
        }
    }
}
