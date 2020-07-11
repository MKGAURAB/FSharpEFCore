namespace Database.Access

open System
open Database.Entities
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Storage.ValueConversion

type TaskContext =
    inherit DbContext
    new() = { inherit DbContext() }
    new(options: DbContextOptions<TaskContext>) = { inherit DbContext(options) }
    
    override __.OnModelCreating modelBuilder =
        let taskConvert = ValueConverter<TaskStatus, int> ((fun v -> int v),
                                                           (fun v -> Enum.Parse(typedefof<TaskStatus>, v.ToString()):?>TaskStatus))
        modelBuilder.Entity<Task>().Property(fun e -> e.Status).HasConversion(taskConvert) |> ignore
    
    [<DefaultValue>]
    val mutable tasks: DbSet<Task>
    member x.Tasks
        with get() = x.tasks
        and set v = x.tasks <- v