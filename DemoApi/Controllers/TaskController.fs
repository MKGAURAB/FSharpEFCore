namespace FSharpEFCore.Controllers

open System.Net
open System.Net.Http
open Database.Access
open Database.Entities
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type TaskController(logger: ILogger<TaskController>, taskRepository: TaskRepository) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get(): List<Task> option = taskRepository.getAllTasks

    [<HttpPost>]
    member __.Post(entity: Task): HttpResponseMessage =
        taskRepository.addTask (entity)
        new HttpResponseMessage(HttpStatusCode.OK)
