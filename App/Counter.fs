module Elmish.Demo.Counter

open Feliz
open Feliz.DaisyUI

// The state of our app
// (type with multiple fields)
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

// Create the initial state
let init (): State =
   { Counter = 0; Name = "" }

// Update the state according to the given message
let update (msg: Msg) (s: State): State =
    match msg with
    | Increment -> { s with Counter = s.Counter + 1 }
    | Decrement -> { s with Counter = s.Counter - 1 }
    | ChangeName name -> { s with Name = name }

let render (s: State) (dispatch: Msg -> unit): ReactElement =
    Daisy.card [
        prop.className "card-bordered card-compact bg-base-100 shadow-xl w-48"

        prop.children [
            Daisy.cardBody [
                Daisy.cardTitle "Counter"

                Html.div [
                    prop.className "flex gap-3 items-center space-between"
                    prop.children [
                        Daisy.button.button [
                            prop.text "-"
                            prop.onClick (fun _ -> dispatch Decrement)
                        ]

                        Daisy.badge [
                            prop.className "w-12 badge-lg badge-secondary"
                            prop.text (string s.Counter)
                        ]

                        Daisy.button.button [
                            prop.text "+"
                            prop.onClick (fun _ -> dispatch Increment)
                        ]
                    ]
                ]

                Daisy.input [
                    prop.className "input-bordered"
                    prop.type' "text"
                    prop.valueOrDefault s.Name
                    prop.onTextChange (fun name -> dispatch (ChangeName name))
                ]

                for _ in [1..s.Counter] do
                    Daisy.badge [
                        prop.className "badge-secondary"
                        prop.text $"Hello {s.Name}"
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
