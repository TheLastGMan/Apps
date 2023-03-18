namespace TicTacToe.Logic.BoardInfo

type BoardVal =
    struct
        val Board: BoardLayout
        val Move: MoveInfo
        val Eval: int
        new(board, move, eval) = { Board = board; Move = move; Eval = eval}
    end
