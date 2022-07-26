using FEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("TareasDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});


//obtener datos desde EF
app.MapGet("/api/task", async ([FromServices] TasksContext dbContext) => 
{
    //retornamos toda la coleccion de Task
    // return Results.Ok(dbContext.Tasks);

    //retornamos la coleccion completo de task filtrando por la prioridad de la tarea
    // return Results.Ok(dbContext.Tasks.Where( t => t.PriorityTask == FEF.Priority.Baja));


    //retornamos la coleccion completo de task filtrando(donde) por la prioridad de la tarea e incluyendo los datos de categoria
    // var data = dbContext.Tasks.Include(t => t.Category).Where( t => t.PriorityTask == FEF.Priority.Baja);
    // return Results.Ok(data);

     var data = dbContext.Tasks.Include(t => t.Category);
    return Results.Ok(data);

});

//guardar datos desde EF
app.MapPost("/api/task", async ([FromServices] TasksContext dbContext, [FromBody] FEF.Task task) =>
{
    //le agregamos un guid 
    task.TaskId = Guid.NewGuid();
    //agregamos fecha actual de creacion
    task.Creation = DateTime.Now;
    //agregamos a la coleccion tasks el objeto que creamos
    await dbContext.Tasks.AddAsync(task);

    //guardamos los cambios
    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

//actualizar con EF
app.MapPut("/api/task/{id}", async ([FromServices] TasksContext dbContext, [FromBody] FEF.Task task, [FromRoute] Guid id) =>
{
    //buscamos la tarea actual (el metodo Find la busqueda la hace por key)
    var tareaActual = dbContext.Tasks.Find(id);

    if(tareaActual!=null)
    {
        //asignamos a la variable los datos encontrados
        tareaActual.CategoryId = task.CategoryId;
        tareaActual.Title = task.Title;
        tareaActual.PriorityTask = task.PriorityTask;
        tareaActual.Description = task.Description;

        //guardamos 
        await dbContext.SaveChangesAsync();

        return Results.Ok();

    }

    return Results.NotFound();


});


//eliminar con E
app.MapDelete("/api/task/{id}" , async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) => 
{
    //buscamos la tarea actual (el metodo Find la busqueda la hace por key)
    var tareaActual = dbContext.Tasks.Find(id);

    if(tareaActual!=null)
    {
        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();

        return Results.Ok();

    }

    return Results.NotFound();
});

app.Run();
