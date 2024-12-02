# ContactsManagementApi
**Contacts Management Application** - Backend (Web API)
This is the .NET Core Web API for the Contacts Management Application.
The API provides endpoints to manage contacts with features such as adding, editing, deleting, and retrieving contacts.

**Restore dependencies:**
dotnet restore

**Build the application:**
dotnet build

**Run the API:**
dotnet run

**Application Features**
CRUD Operations: Allows creating, updating, and deleting contacts. 
Error Handling: Built-in error handling for graceful responses to client requests.
Unit Tests: Done one sample unit testing(Xunit) over one module.

**API Endpoints**
GET /api/ContactsManagement: Get all contacts with pagination.
GET /api/ContactsManagement/{id}: Get a contact by ID. 
POST /api/ContactsManagement: Create a new contact. 
PUT /api/ContactsManagement/{id}: Update an existing contact. 
DELETE /api/ContactsManagement/{id}: Delete a contact by ID.

**Folder Structure**
Controllers: Contains ContactsController which defines the API endpoints.
Models: Defines the Contact model. 
Interfaces: Defines interfaces for the queries and commands.
Commands: Defines handlers for the commands handlers.
Queries: Defines handlers for the queries handlers.

**Design Decisions**
Architecture : Clean architecture is used to define layers for the application.
Application Layer: Encapsulates business logic for ease of testing and separation of concerns. 
CQRS Pattern with MediatR: Manages data persistence, enabling flexibility in data storage. 
Mock Database: Stores contacts in a JSON file (contacts.json) for simplified data management.
Unit Tests: Xunit is used to do unit testing.
 
