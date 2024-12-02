using ContactsManagementApplication.Commands;
using ContactsManagementApplication.CommandsHandler;
using ContactsManagementDomain.Entities;
using ContactsManagementInfra.JsonDataStore;
using Moq;

public class AddContactsCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldAddContactAndReturnNewId()
    {
        // Arrange
        var stubDataStore = new ContactsJsonDataStore();
        stubDataStore.SaveAll(new List<Contacts>
    {
        new Contacts { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
        new Contacts { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
    });

        var commandHandler = new AddContactsCommandHandler(stubDataStore);
        var command = new AddContactsCommand
        {
            FirstName = "Bob",
            LastName = "Brown",
            Email = "bob.brown@example.com"
        };

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(3, result);
    }
}
