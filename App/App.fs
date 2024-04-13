module Elmish.Demo.App

open Fable.Core
open Elmish
open Elmish.Debug
open Elmish.HMR

JsInterop.importSideEffects "./index.css"

Program.mkSimple Counter.init Counter.update Counter.render
|> Program.withReactSynchronous "app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run
