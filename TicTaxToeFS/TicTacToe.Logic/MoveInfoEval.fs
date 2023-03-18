namespace TicTacToe.Logic.BoardInfo
open TicTacToe.Data.BoardInfo

type MoveInfoEval =
    struct
        val Move: MoveInfo
        val Eval: int
        new(move, eval) = { Move = move; Eval = eval }
    end
