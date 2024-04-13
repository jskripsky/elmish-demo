namespace Elmish.Demo

open Elmish
open Elmish.Debug
open Elmish.HMR

module App =
    Program.mkSimple Counter.init Counter.update Counter.render
    |> Program.withReactSynchronous "app"
    |> Program.withConsoleTrace
    |> Program.withDebugger
    |> Program.run
