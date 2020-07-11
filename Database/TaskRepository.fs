namespace Database.Access

open Database.Entities

type TaskRepository (context: TaskContext) =
    member __.getTaskById (id: int) : Task option=
        query {
            for task in context.tasks do
                where (task.Id = id)
                select task
                exactlyOne
        } |> (fun x -> if box x = null then None else Some x)
        
    member __.getAllTasks : List<Task> option =
        query {
            for task in context.tasks do
                select task
                
        } |> (fun x -> if box x = null then None else Some ( x |> Seq.toList))
    
    member __.addTask (entity: Task) =
        context.tasks.Add entity |> ignore
        context.SaveChanges true |> ignore