
public class PossibleMoveBuilder
{
    private GameBoard<PlayerType, PieceType> board;
    private BoardPosition position;
    private PlayerType playerType;

    private readonly LinkedList<BoardPosition> possibleMoves = new LinkedList<BoardPosition>();

    public PossibleMoveBuilder(GameBoard<PlayerType, PieceType> board, BoardPosition position, PlayerType playerType)
    {
        this.board = board;
        this.position = position;
        this.playerType = playerType;
    }

    public PossibleMoveBuilder AddJumpMove(int x, int y)
    {
        var possibleMove = position.OffsetX(x).OffsetY(y);
        if (board.GetPlayerType(possibleMove) != playerType)
        {
            possibleMoves.AddLast(possibleMove);
        }
        return this;
    }

    private PossibleMoveBuilder AddDirectionMove(int dy, int dx)
    {
        var possibleMove = position
                .OffsetX(dx)
                .OffsetY(dy);

        while (possibleMove.Valid())
        {
            var playerType = board.GetPlayerType(possibleMove);
            var isCurrentPlayer = playerType == this.playerType;
            var isEmpty = board.IsEmpty(possibleMove);
            if (isEmpty)
            {
                possibleMoves.AddLast(possibleMove);
            }
            else if(!isCurrentPlayer)
            {
                possibleMoves.AddLast(possibleMove);
                break;
            }
            else if (isCurrentPlayer)
            {
                break;
            }

            possibleMove = possibleMove
                .OffsetX(dx)
                .OffsetY(dy);
        }

        return this;
    }

    public PossibleMoveBuilder AddRightMove()
    {
        return AddDirectionMove(1, 0);
    }

    public PossibleMoveBuilder AddLeftMove()
    {
        return AddDirectionMove(-1, 0);
    }

    public PossibleMoveBuilder AddUpMove()
    {
        return AddDirectionMove(0, 1);
    }

    public PossibleMoveBuilder AddDownMove()
    {
        return AddDirectionMove(0, -1);
    }

    public PossibleMoveBuilder AddUpRightMove()
    {
        return AddDirectionMove(1, 1);
    }

    public PossibleMoveBuilder AddUpLeftMove()
    {
        return AddDirectionMove(-1, 1);
    }

    public PossibleMoveBuilder AddDownRightMove()
    {
        return AddDirectionMove(1, -1);
    }

    public PossibleMoveBuilder AddDownLeftMove()
    {
        return AddDirectionMove(-1, -1);
    }

    public PossibleMoveBuilder AddHorizontalMove()
    {
        AddRightMove();
        AddLeftMove();
        return this;
    }

    public PossibleMoveBuilder AddVerticalMove()
    {
        AddUpMove();
        AddDownMove();
        return this;
    }

    public PossibleMoveBuilder AddDiagonalMove()
    {
        AddUpRightMove();
        AddUpLeftMove();
        AddDownRightMove();
        AddDownLeftMove();
        return this;
    }

    public ICollection<BoardPosition> Build()
    {
        return possibleMoves;
    }
}