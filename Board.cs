
public class Board<TPieceType> where TPieceType : Enum {

    protected readonly TPieceType[] board = new TPieceType[8 * 8];

    public Board(Board<TPieceType> board) {
        this.board = board.board;
    }

    public Board() {
        for(int i = 0; i < board.Length; i++) {
            board[i] = default(TPieceType);
        }
    }

    public TPieceType this[int x, int y] {
        get {
            return board[x + y * 8];
        }
        set {
            board[x + y * 8] = value;
        }
    } 

    public TPieceType GetBoardPositionPieceType(BoardPosition position) {
        if(!position.Valid()) {
            throw new ArgumentException("Invalid board position");
        }
        return this[position.X, position.Y];
    }

    public bool IsEmpty(BoardPosition position) {
        return this[position.X, position.Y].Equals(default(TPieceType));
    }
    
    public bool IsEmpty(int x, int y) {
        return this[x, y].Equals(default(TPieceType));
    }
}
