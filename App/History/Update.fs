module Demo.WebUI.History.Update

open Elmish
open Demo.WebUI.History

/// Create the initial state.
/// initToWrap: 'init' function to wrap
let init initToWrap () =
    // run the wrapped 'init' function
    let innerState = initToWrap ()

    // create state with initial inner state
    let state = {
        History = [innerState]
        Current = 0
    }

    // initial state
    state

/// Update state in reaction to a message.
/// updateToWrap: 'update' function to wrap
let update updateToWrap msg state =
    // short-hand
    let cur = state.Current

    // handle the message
    match msg with
    // time travel command
    | TimeTravel dir ->
        // calculate new index depending on direction
        let newIndex =
            match dir with
            | Undo -> cur + 1 // move to the back
            | Redo -> cur - 1 // move back to the front
            | JumpTo idx -> idx // jump directly to the given index

        { state with Current = newIndex }

    // (inner) message of the inner wrapped message type
    | InnerMsg innerMsg ->
        // get current state
        let curInner = state.History[cur]

        // run the inner 'update' function to get new state (and command)
        let newInner = updateToWrap innerMsg curInner

        if newInner = curInner then
            // if the inner state is unchanged, history stays the same
            state
        else
            // state has changed

            // if we're in the past, we throw away the state we have undone, we're about to "overwrite" it
            let history = state.History |> List.skip state.Current

            // prepend new state to history
            let newHistory = newInner::history

            // 'Current' points to the head again
            { History = newHistory; Current = 0 }
