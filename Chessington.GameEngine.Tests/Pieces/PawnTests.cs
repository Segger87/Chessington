using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class PawnTests
    {
        [Test]
        public void WhitePawns_CanMoveOneSquareUp()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(7, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 0));
        }

        [Test]
        public void BlackPawns_CanMoveOneSquareDown()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Red);
            board.AddPiece(Square.At(1, 0), pawn);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(2, 0));
        }

        [Test]
        public void BlackPawns_CannotCaptureForwards()
        {
            var board = new Board();
            var pawn = new Pawn(Player.Red);
            var pawnInTheWay = new Pawn(Player.Red);
            board.AddPiece(Square.At(1, 0), pawn);
            board.AddPiece(Square.At(2, 0), pawnInTheWay);

            var moves = pawn.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(2, 0));
        }
    }
}