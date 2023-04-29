public class GameBoard<TPlayerType, TPieceType> : Board<TPieceType> 
where TPlayerType : Enum
where TPieceType : Enum {
    private Dictionary<TPieceType, TPlayerType> playerPieceMap;

    public GameBoard(Dictionary<TPieceType, TPlayerType> piecePlayerMap, Board<TPieceType> board) : base(board) {
        if(piecePlayerMap == null) {
            throw new InvalidOperationException("Player piece map is not set");
        }
        this.playerPieceMap = piecePlayerMap;
    }

    public TPlayerType GetPlayerType(BoardPosition boardPosition) {
        var pieceType = GetBoardPositionPieceType(boardPosition);
        if(pieceType.Equals(default(TPieceType))) {
            return default(TPlayerType);
        }
        if(playerPieceMap.TryGetValue(pieceType, out var playerType)) {
            return playerType;
        }
        throw new ArgumentException($"Piece type {pieceType} is not mapped to a player type");
    }
}