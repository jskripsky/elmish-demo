module Elmish.Demo.Counter

open Feliz
open Feliz.DaisyUI

type View = ReactElement

// The state of our app
// (type with multiple fields)
type State = {
   Counter: int
}

// A message triggered by UI
// (type with multiple alternatives)
type Msg =
    | Increment
    | Decrement

// Create the initial state
let init (): State =
   { Counter = 0 }

// Update the state according to the given message
let update (msg: Msg) (s: State): State =
    match msg with
    | Increment -> { s with Counter = s.Counter + 1 }
    | Decrement -> { s with Counter = s.Counter - 1 }

let render (s: State) (dispatch: Msg -> unit): View =
    Daisy.card [
        prop.className "card-bordered card-compact bg-base-100 shadow-xl w-48"

        prop.children [
            Daisy.cardBody [
                Daisy.cardTitle "Counter"

                Html.div [
                    prop.className "flex gap-2 items-center space-between"
                    prop.children [
                        Daisy.button.button [
                            prop.text "-"
                            prop.onClick (fun _ -> dispatch Decrement)
                        ]

                        Daisy.badge [
                            prop.className "w-12 badge-secondary"
                            prop.text $" {s.Counter} "
                        ]

                        Daisy.button.button [
                            prop.text "+"
                            prop.onClick (fun _ -> dispatch Increment)
                        ]
                    ]
                ]
            ]
        ]
    ]

(*
let renderButton label msg =
    Html.button [
        prop.text label
        prop.onClick (fun _ -> dispatch msg)
    ]

let render (s: State) =
    Html.div [
        renderButton "-" Decrement
        Html.text (string s.Counter)
        renderButton "+" Increment
    ]
*)
