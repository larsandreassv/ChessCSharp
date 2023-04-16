public class ChessGameBuilder {
    private GameBoard<PlayerType, PieceType> board;
    private PlayerType currentPlayer;

    public ChessGameBuilder() {
        this.board = new GameBoard<PlayerType, PieceType>();
        var chessGameBoardFactory = new ChessGameBoardFactory();
        this.board = chessGameBoardFactory.Create();
    }

    public ChessGameBuilder WithBoard(Board<PieceType> board) {
        this.board.SetBoard(board);
        return this;
    }

    public ChessGameBuilder WithBoard(string board) {
        //TODO: Implement this
        return this;
    }

    public ChessGameBuilder WithCurrentPlayer(PlayerType currentPlayer) {
        this.currentPlayer = currentPlayer;
        return this;
    }

    public ChessGame Build() {
        if(board == null)
            throw new InvalidOperationException("Board cannot be null");
        if(currentPlayer == null)
            throw new InvalidOperationException("Current player cannot be null");
        return new ChessGame(board, currentPlayer);
    }
}
