namespace TicTacToe.Logic

type Common =
    static member Flip(value : int, mask : int) = (value ^^^ (0xFFFFFFFF)) &&& mask
    static member BitCount(value : int) =
        [ 0..31 ]
        |> Seq.map (fun idx -> 1 <<< idx)
        |> Seq.map (fun mask -> (value &&& mask) > 0)
        |> Seq.filter (fun bitSet -> bitSet)
        |> Seq.length
