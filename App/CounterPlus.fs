module Extension =
    type State = {
        Counter: int
        Name: string
    }

    // A message triggered by UI
    // (type with multiple alternatives)
    type Msg =
        | Increment
        | Decrement
        | ChangeName of string

    let update (msg: Msg) (s: State): State =
        match msg with
        | Increment -> { s with Counter = s.Counter + 1 }
        | Decrement -> { s with Counter = s.Counter - 1 }
        | ChangeName name -> { s with Name = name }
