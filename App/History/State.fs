namespace Demo.WebUI.History

/// A type alias for clarity (compile-time only)
type Index = int

/// All time travel commands the user can issue
type TimeTravel =
    | Undo
    | Redo
    | JumpTo of Index // direct jump to given point in the history

/// Our message type, wrapping an inner message type 'M.
/// We support time travel commands.
/// And we must support all messages of the wrapped inner message type.
type Msg<'M> =
    | TimeTravel of TimeTravel
    | InnerMsg of 'M

/// Full History State
/// Invariants: 0 <= Current <= History.Length - 1
[<NoComparison>]
type State<'S> = {
    /// (Linked) List of states, starting with the latest one and ending with the starting state.
    History: 'S list

    /// Index (into History) of currently active state
    Current: Index
}
