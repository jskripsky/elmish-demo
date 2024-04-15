module Demo.WebUI.History.View

open Feliz
open Demo.WebUI.History

/// Render the state as a ReactElement.
/// renderToWrap: 'render' function to wrap
let render renderToWrap (state: State<_>) dispatch =
    // history length, current index, current inner state
    let length = state.History.Length
    let current = state.Current
    let innerState = state.History[current]

    // wrap the inner view element in a HTML div
    Html.div [
        // render the history control panel at the top
        Panel.renderHistoryPanel length current (TimeTravel >> dispatch)

        // generate the wrapped inner view
        renderToWrap innerState (InnerMsg >> dispatch)
    ]
