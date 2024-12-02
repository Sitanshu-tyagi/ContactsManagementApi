
using ContactsManagementApi.Middlewares;
using ContactsManagementApplication.CommandsHandler;
using ContactsManagementDomain.ContactsFluentValidator;
using ContactsManagementInfra.JsonDataStore;
using FluentValidation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<ContactsValidator>();

// Register MediatR for handling commands and queries
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddContactsCommandHandler).Assembly));

// Add a singleton instance of the JSON data store
builder.Services.AddSingleton<ContactsJsonDataStore>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Register the custom error handling middleware globally
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
