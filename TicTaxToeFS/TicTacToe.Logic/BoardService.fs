namespace TicTacToe.Logic

open TicTacToe.Data.BoardInfo
open TicTacToe.Logic.BoardInfo

type BoardService() =
    let HasColumnWin(board : BoardPositions) =
        [ 0..2 ]
        |> Seq.map (fun idx -> enum<BoardPositions> ((int) BoardMasks.COL <<< idx))
        |> Seq.map (fun mask -> (board &&& mask) = mask)
        |> Seq.contains (true)

    let HasRowWin(board : BoardPositions) =
        [ 0..2 ]
        |> Seq.map (fun idx -> enum<BoardPositions> ((int) BoardMasks.ROW <<< (idx * 3)))
        |> Seq.map (fun mask -> (board &&& mask) = mask)
        |> Seq.contains (true)

    let HasDiagULLR(board : BoardPositions) =
        ((int) board &&& (int) BoardMasks.DIAG_ULLR) = (int) BoardMasks.DIAG_ULLR

    let HasDiagURLL(board : BoardPositions) =
        ((int) board &&& (int) BoardMasks.DIAG_URLL) = (int) BoardMasks.DIAG_URLL

    let HasDiagWin(board : BoardPositions) =
        HasDiagULLR(board) || HasDiagURLL(board)

    let HasWin(board : BoardPositions) =
        HasColumnWin(board) || HasRowWin(board) || HasDiagWin(board)

    let DoesRowBlock(playerPieces : BoardPositions, oppPieces : BoardPositions, activeMove : BoardPositions) =
        [ 0..2 ]
        |> Seq.map (fun idx -> (int) BoardMasks.ROW <<< (idx * 3))
        |> Seq.filter (fun row -> (row &&& (int) activeMove) > 0)
        |> Seq.map
               (fun mask ->
               Common.BitCount((int) oppPieces &&& mask) = 2 && Common.BitCount((int) playerPieces &&& mask) = 1)
        |> Seq.exists (fun itm -> itm)

    let DoesColumnBlock(playerPieces : BoardPositions, oppPieces : BoardPositions, activeMove : BoardPositions) =
        [ 0..2 ]
        |> Seq.map (fun idx -> (int) BoardMasks.COL <<< idx)
        |> Seq.filter (fun col -> (col &&& (int) activeMove) > 0)
        |> Seq.map
               (fun mask ->
               Common.BitCount((int) oppPieces &&& mask) = 2 && Common.BitCount((int) playerPieces &&& mask) = 1)
        |> Seq.exists (fun itm -> itm)

    let DoesDiagULLRBlock(playerPieces : BoardPositions, oppPieces : BoardPositions, activeMove : BoardPositions) =
        ((int) activeMove &&& (int) BoardMasks.DIAG_ULLR) > 0
        && Common.BitCount((int) playerPieces &&& (int) BoardMasks.DIAG_ULLR) = 1
        && Common.BitCount((int) oppPieces &&& (int) BoardMasks.DIAG_ULLR) = 2

    let DoesDiagURLLBlock(playerPieces : BoardPositions, oppPieces : BoardPositions, activeMove : BoardPositions) =
        ((int) activeMove &&& (int) BoardMasks.DIAG_URLL) > 0
        && Common.BitCount((int) playerPieces &&& (int) BoardMasks.DIAG_URLL) = 1
        && Common.BitCount((int) oppPieces &&& (int) BoardMasks.DIAG_URLL) = 2

    let HasDiagBlock(playerPieces : BoardPositions, oppPieces : BoardPositions, activeMove : BoardPositions) =
        DoesDiagULLRBlock(playerPieces, oppPieces, activeMove) || DoesDiagURLLBlock(playerPieces, oppPieces, activeMove)

    let HasBlock(playerPieces : BoardPositions, boardPositions : BoardPositions, activeMove : BoardPositions) =
        DoesRowBlock(playerPieces, boardPositions, activeMove)
        || DoesColumnBlock(playerPieces, boardPositions, activeMove)
        || HasDiagBlock(playerPieces, boardPositions, activeMove)

    member public this.OpenPositions(layout : BoardLayout) =
        enum<BoardPositions> ((int) layout.PieceMask ^^^ (int) BoardMasks.TABLE)

    member public this.OpenPositionsSplit(layout : BoardLayout) =
        let positions = this.OpenPositions(layout)
        [ 0..31 ]
        |> Seq.map (fun idx -> (int) BoardMasks.TABLE &&& (1 <<< idx))
        |> Seq.filter (fun mask -> (mask &&& (int) positions) > 0)

    member public this.MakeMove(layout : BoardLayout, move : MoveInfo) =
        let newMask = (layout.PieceMask ||| move.Position)
        let newPlacement =
            enum<BoardPositions> ((int) layout.PiecePlacement ||| ((int) move.Piece * (int) move.Position))
        new BoardLayout(newMask, newPlacement)

    member public this.UndoMove(layout : BoardLayout, move : MoveInfo) =
        let newMask =
            layout.PieceMask &&& enum<BoardPositions> (Common.Flip((int) move.Position, (int) layout.PieceMask))
        let newPlacement =
            layout.PiecePlacement
            &&& enum<BoardPositions> (Common.Flip((int) move.Piece * (int) move.Position, (int) layout.PieceMask))
        new BoardLayout(newMask, newPlacement)

    member public this.PositionValue(layout : BoardLayout, player : PieceType, activeMove : BoardPositions) =
        //player's pieces
        let playerBoard =
            if (player = PieceType.X) then layout.PiecePlacement
            else enum<BoardPositions> (Common.Flip((int) layout.PiecePlacement, (int) layout.PieceMask))

        let oppBoard = playerBoard ^^^ layout.PieceMask
        //check conditions
        if HasWin(playerBoard) then 100
        else if HasBlock(playerBoard, oppBoard, activeMove) then 50
        else 10

    member public this.IsWin(layout : BoardLayout, player : PieceType) =
        //player's pieces
        let playerBoard =
            if (player = PieceType.X) then layout.PiecePlacement
            else enum<BoardPositions> (Common.Flip((int) layout.PiecePlacement, (int) layout.PieceMask))
        //check for win
        HasWin(playerBoard)
