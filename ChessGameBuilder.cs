public class ChessGameBuilder {
    private GameBoard<PlayerType, PieceType> board;
    private PlayerType currentPlayer;

    public ChessGameBuilder() {
        var chessGameBoardFactory = new ChessGameBoardFactory();
        this.board = chessGameBoardFactory.Create();
    }

    public ChessGameBuilder WithCurrentPlayer(PlayerType currentPlayer) {
        this.currentPlayer = currentPlayer;
        return this;
    }

    public ChessGameBuilder WithBoard(GameBoard<PlayerType, PieceType> board) {
        this.board = board;
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
