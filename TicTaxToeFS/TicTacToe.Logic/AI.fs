namespace TicTacToe.Logic

open TicTacToe.Data.BoardInfo
open TicTacToe.Logic.BoardInfo

type AI() =

    let NextPlayer(player) =
        if player = PieceType.X then PieceType.O
        else PieceType.X

    let RandomMove(moves) =
        moves |> Seq.item (System.Random().Next(Seq.length (moves)))

    let BoardValToMove(bestMove : BoardVal) =
        new MoveInfoEval(bestMove.Move, bestMove.Eval)

    let EvalBoardPosition(currentBoard, opnPos, player, offset) =
        let movePos = new MoveInfo(enum<BoardPositions> (opnPos), player)
        let moved = BoardService().MakeMove(currentBoard, movePos)
        let value = BoardService().PositionValue(moved, player, enum<BoardPositions> (opnPos)) * (if offset % 2 = 0 then 1 else -1)
        new BoardVal(moved, movePos, value)

    let rec MakeDepthMove(currentBoard : BoardLayout, player : PieceType, depth : int, iteration : int) =
        let openPositions =
            BoardService().OpenPositionsSplit(currentBoard)
            |> Seq.map (fun f -> EvalBoardPosition(currentBoard, f, player, iteration))
        //check for empty set
        if (Seq.isEmpty (openPositions)) then
            //draw
            new MoveInfoEval(new MoveInfo(BoardPositions.NONE, player), 0)
        else if (depth = 0) then
            //random position
            BoardValToMove(RandomMove(openPositions))
        else
            //current best evaluation
            let bestMoveGroup =
                openPositions
                |> Seq.groupBy (fun f -> abs f.Eval)
                |> Seq.sortByDescending (fun f -> fst f)
                |> Seq.head
            if ((fst bestMoveGroup) >= 50 || depth = iteration) then
                BoardValToMove(RandomMove(snd bestMoveGroup))
            else
                let candidateMoves =
                    openPositions
                    |> Seq.map (fun pos -> (pos, MakeDepthMove(pos.Board, NextPlayer(player), depth, iteration + 1)))
                    |> Seq.map (fun res -> new MoveInfoEval((fst res).Move, (snd res).Eval))
                    |> Seq.groupBy (fun gp -> gp.Eval)
                if (iteration % 2 = 0) then
                    //current player, max the value
                    let ourBestGroup =
                        snd (candidateMoves
                             |> Seq.sortBy (fun f -> fst f)
                             |> Seq.head)
                    RandomMove(ourBestGroup)
                else
                    //opponent, min it
                    let oppBestGroup =
                        snd (candidateMoves
                             |> Seq.sortByDescending (fun f -> fst f)
                             |> Seq.head)
                    RandomMove(oppBestGroup)

    member this.MakeMove(currentBoard : BoardLayout, player : PieceType, depth : int) =
        MakeDepthMove(currentBoard, player, depth, 0)
