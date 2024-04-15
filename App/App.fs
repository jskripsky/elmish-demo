module Elmish.Demo.App

open Fable.Core
open Elmish
open Elmish.Debug
open Elmish.HMR

open Demo.WebUI.History

JsInterop.importSideEffects "./index.css"

Program.mkSimple
    (Update.init Counter.init)
    (Update.update Counter.update )
    (View.render Counter.render)
|> Program.withReactSynchronous "app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run
