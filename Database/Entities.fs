module Database.Entities

open System.ComponentModel.DataAnnotations.Schema

type TaskId = int

type TaskStatus =
    | Todo = 0
    | InProgress = 1
    | Completed = 2

type [<CLIMutable>] Task =
    {
        [<DatabaseGenerated(DatabaseGeneratedOption.Identity)>]Id: TaskId
        Name: string
        Description: string
        Status : TaskStatus
    }