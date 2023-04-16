public class PieceMoveStrategyFactory : IPieceMoveStrategyFactory {
    private readonly PieceType pieceType;
    private readonly Dictionary<PieceType, Func<IPieceMoveStrategy>> _strategyFactories;
    private readonly Dictionary<PieceType, IPieceMoveStrategy> _strategyCache = new Dictionary<PieceType, IPieceMoveStrategy>();

    public PieceMoveStrategyFactory() {
        _strategyFactories = new Dictionary<PieceType, Func<IPieceMoveStrategy>> {
            { PieceType.PawnWhite, () => new PawnMoveStrategy(PlayerType.White) },
            { PieceType.PawnBlack, () => new PawnMoveStrategy(PlayerType.Black) },
            { PieceType.RookWhite, () => new RookMoveStrategy(PlayerType.White) },
            { PieceType.RookBlack, () => new RookMoveStrategy(PlayerType.Black) },
            { PieceType.KnightWhite, () => new KnightMoveStrategy(PlayerType.White) },
            { PieceType.KnightBlack, () => new KnightMoveStrategy(PlayerType.Black) },
            { PieceType.BishopWhite, () => new BishopMoveStrategy(PlayerType.White) },
            { PieceType.BishopBlack, () => new BishopMoveStrategy(PlayerType.Black) },
            { PieceType.QueenWhite, () => new QueenMoveStrategy(PlayerType.White) },
            { PieceType.QueenBlack, () => new QueenMoveStrategy(PlayerType.Black) },
            { PieceType.KingWhite, () => new KingMoveStrategy(PlayerType.White) },
            { PieceType.KingBlack, () => new KingMoveStrategy(PlayerType.Black) },
        };
    }

    public IPieceMoveStrategy CreatePieceMoveStrategy(PieceType pieceType) {
        if (_strategyCache.TryGetValue(pieceType, out var strategy)) {
            return strategy;
        }
        if (_strategyFactories.TryGetValue(pieceType, out var strategyFactory)) {
            _strategyCache[pieceType] = strategyFactory();
            return _strategyCache[pieceType];
        }
        throw new ArgumentException($"No strategy found for piece type {pieceType}");
    }
}
