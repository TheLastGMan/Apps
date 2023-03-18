namespace TicTacToe.Logic.BoardInfo
open TicTacToe.Data.BoardInfo

type BoardLayout =
    struct
        val PieceMask: BoardPositions
        val PiecePlacement: BoardPositions
        new(mask, pieces) = { PieceMask = mask; PiecePlacement = pieces }
    end
