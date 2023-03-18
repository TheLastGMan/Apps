namespace TicTacToe.Logic.BoardInfo
open TicTacToe.Data.BoardInfo

type MoveInfo =
    struct
        val Position: BoardPositions
        val Piece: PieceType
        new(position, piece) = { Position = position; Piece = piece }
    end
