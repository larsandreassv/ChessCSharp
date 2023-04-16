public class ChessGame
{
    private PlayerType currentPlayer = PlayerType.White;
    private readonly GameBoard<PlayerType, PieceType> board;
    private static readonly IPieceMoveStrategy pieceMoveStrategy = new PieceMoveStrategy();


    public ChessGame(GameBoard<PlayerType, PieceType> board, PlayerType currentPlayer)
    {
        this.board = board;
        this.currentPlayer = currentPlayer;
    }

    public void Draw()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Console.Write("{0, 12}", board[x, 7 - y]);
            }
            Console.WriteLine();
        }
    }

    public void Update()
    {
        Console.WriteLine("Current player: " + currentPlayer);
        Console.WriteLine("Enter selected piece position (x, y): ");
        var input = Console.ReadLine();

        var x = int.Parse(input.Split(',')[0]);
        var y = int.Parse(input.Split(',')[1]);
        var boardPosition = new BoardPosition(x, y);

        var possibleMoves = pieceMoveStrategy.GetPossibleMoves(board, boardPosition);

        Console.WriteLine("Possible moves: ");
        foreach (var possibleMove in possibleMoves)
        {
            Console.WriteLine((possibleMove.X, possibleMove.Y));
        }
        Console.WriteLine("Enter move (x, y): ");
        var selectedMove = Console.ReadLine();

        var selectedMoveSplit = selectedMove.Split(',');
        var selectedMoveX = int.Parse(selectedMoveSplit[0]);
        var selectedMoveY = int.Parse(selectedMoveSplit[1]);
        var selectedMovePosition = new BoardPosition(selectedMoveX, selectedMoveY);
        if (possibleMoves.Contains(selectedMovePosition))
        {
            board[selectedMoveX, selectedMoveY] = board[x, y];
            board[x, y] = PieceType.Empty;
            currentPlayer = currentPlayer == PlayerType.White ? PlayerType.Black : PlayerType.White;
        }
        else
        {
            Console.WriteLine("Invalid move");
            return;
        }
    }
}
