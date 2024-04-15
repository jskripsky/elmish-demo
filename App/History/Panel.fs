module Demo.WebUI.History.Panel

open Feliz
open Demo.WebUI.History

/// render the history panel title and buttons
/// length: length of history
/// current: index of current state (in history)
let renderHistoryPanel (length: int) (current: Index) dispatch =
    // panel
    Html.div [
        prop.className "mb-4 p-2 bg-base-300"
        prop.children [
            // undo button
            Html.button [
                prop.className "btn"
                prop.text "Undo"
                prop.onClick (fun _ -> Undo |> dispatch)
                // disable when we're at the very starting state
                if current = length - 1 then
                    prop.disabled true
            ]

            // button for direct jump to state at index 'index'
            let renderJumpButton index =
                Html.button [
                    prop.className "btn m-1"
                    prop.text (string (length - index))
                    prop.onClick (fun _ -> JumpTo index |> dispatch)

                    // disable and highlight the currently selected state
                    if index = current then
                        prop.disabled true
                ]

            // all jump buttons
            yield! (
                [0..(length - 1)]
                |> List.map renderJumpButton
                |> List.rev
            )

            // redo button
            Html.button [
                prop.className "btn"
                prop.text "Redo"
                prop.onClick (fun _ -> Redo |> dispatch)
                if current = 0 then
                    prop.disabled true
            ]
        ]
    ]