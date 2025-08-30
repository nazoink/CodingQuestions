# Copilot Instructions

These instructions define how GitHub Copilot should assist with this project. The goal is to ensure consistent, high-quality code generation aligned with our conventions, stack, and best practices.

## 🧠 Context

- **Project Type**: Console applications
- **Purpose**: This project is a series of applications to support personal coding projects and learning.
- **Language**: C#
- **Development Environment**: Visual Studio / VS Code
- **Testing Framework**: nUnit, NSubstitute
- **Version Control**: GitHub
- **Framework / Libraries**: .NET 8+ / ASP.NET Core / nUnit / NSubstitute
- **Architecture**: Clean Architecture / Onion, Services, Factory patterns, Repository patterns

## 🔧 General Guidelines

- Make only high confidence suggestions when reviewing code changes.
- Format using `dotnet format` or IDE auto-formatting tools.
- Prioritize readability, testability, and SOLID principles.s
- Use `CONTRIBUTING.md` for contribution guidelines.
- C# class properties should be PascalCase. The JSON serializer will convert them to camelCase for the API, and the Blazor app will use camelCase as it receives the data from the API.
- Use requirement files found `docs/requirements.md` for project context and requirements.
- Use the `docs/*` directory for project documentation.


## 📁 Folder Structure

Use this structure as a guide when creating or updating files:

```text
/
    Archive/
    packages/
    UnitTesting/
    src/
        Project01/
            Calc/
        Project02/
            LinkedList/
```

## 🧶 C# .NET Patterns

### ✅ Patterns to Follow
- Use `.editorconfig` for consistent code style. (If present, see root directory.)
- Always use the latest version C# and .NET.
- Use Clean Architecture with layered separation.
- Use Dependency Injection for services and repositories.
- Map DTOs to domain models using manual mapping extension classes and methods.
- Use C#-idiomatic patterns and follow .NET coding conventions.
- Use named methods instead of anonymous lambdas in business logic.
- Use constructor injection for dependencies.
- Register dependencies in the respective dependency injection file for Services, Repositories, and Factories.
- Avoid magic strings. Use constants as can be found in the `Constants` folder.
- A file can only contain one class declaration.
- Use `IOptions<T>` for configuration settings.
- Prefer using Task async/await whenever possible.
- Use `ILogger<T>` for structured logging.
  - Add logging in the constructor of classes and use it to log important events.

### Services
- Services should be focused on a single conceptual need and should not be too large.
- The general pattern for a loading service call is to load data via one or more repositories, then use a factory to convert the results into a model to return.
- The general pattern for a saving service call is to use the factory to convert the submitted model into a repository model, then call the repository to save the data.
- Services can contain business logic, though the logic is usually determining what repository to call and what factory to use.

### Data and Repositories
- Always use the repository pattern to abstract data access for all data sources, including:
  - HttpClient REST calls: Encapsulate all external API interactions within repository classes to ensure separation of concerns and testability.
  - SQL Data: Use repositories to manage all database queries and commands, keeping data access logic isolated from business logic.
  - CosmosDb data calls: Implement repository classes to handle all interactions with CosmosDb, maintaining a consistent abstraction layer for data access.
- Repositories should center around outputs that deal with a single entity type.
- Repositories are very simple. For REST, they make an HTTP Client request using the http client wrapper on the expected client name and return the result. For SQL or CosmosDb, they encapsulate the query and data mapping logic.
- Repositories to load data that rarely change (countries, permissions, languages etc.) should have a companion cache that implements IAbstractedCache and is registered in the DI container.

### Factories
- Methods to convert a data model to a UI model used for rendering should be called ToUi or something similar.
- Methods that convert a UI model to a data model should be called ToSubmit or something similar.
- Factories often use business logic in assembling a model based on data passed in, so they can be larger than a repository or service.
- Factories can load data sparingly. It is appropriate to convert an id to an object (e.g., countryId to a country object). Factory load calls should favor repositories that use caching whenever possible.

### 🚫 Patterns to Avoid
- Don’t use static state or service locators.
- Avoid logic in controllers—delegate to services/handlers.
- Don’t hardcode config—use appsettings.json and IOptions.
- Don’t expose entities directly in API responses.
- Avoid fat controllers and God classes.

### Nullable Reference Types

- Declare variables non-nullable, and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.

### 🧪 .NET Testing Guidelines
- Use the AAA pattern (Arrange, Act, Assert).
  - When creating tests add the single comment for each section:
    ```csharp
    // Arrange
    // Act
    // Assert
    ```
- Use nUnit for unit testing.
- Use NSubstitute for mocking.
- Categorize tests with the TestFixture attribute on the test class definition.
- Avoid infrastructure dependencies.
- Name tests clearly.
- Write the simplest test that fully validates the intended behavior, avoiding unnecessary assertions or setup.
- Avoid logic in tests.
- Prefer helper methods for setup and teardown.
- Avoid multiple acts in a single test.
- When a class has public virtual methods, use the partial mock pattern to test the class. This allows you to test the class without needing to mock the entire class.
- Make sure to declare DoNotCallBase when testing methods that use the virtual methods, and mock a return value for the virtual method.
- Verify that the virtual method was called with the correct parameters just like an injected dependency.
- Prefer TDD for critical business logic and application services.

## 🧩 Example Prompts
- `Copilot, generate an ASP.NET Core controller with CRUD endpoints for Product.`
- `Copilot, create an Entity Framework Core DbContext for a blog application.`
- `Copilot, write an nUnit test for the CalculateInvoiceTotal method.`
- `Copilot, generate a Blazor component for coach profile display.`

## Running tests

(1) Build from the root with `dotnet build Ai.Coach.sln`.
(2) If that produces errors, fix those errors and build again. Repeat until the build is successful.
(3) Run tests with `dotnet test **/*.tests.csproj`.
(4) Tests are run with `dotnet test **/*tests.csproj`.
(5) If any tests fail, fix those tests and re-run the tests until they all pass.

## 🔁 Iteration & Review
- Copilot output should be reviewed and modified before committing.
- If code isn’t following these instructions, regenerate with more context or split the task.
- Use /// XML documentation comments to clarify intent for Copilot and future devs.
- Use Rider or Visual Studio code inspections to catch violations early.

## 📚 References
- [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [Entity Framework Core Docs](https://learn.microsoft.com/en-us/ef/core/)
- [nUnit Documentation](https://nunit.org/)
- [Clean Architecture in .NET (by Jason Taylor)](https://github.com/jasontaylordev/CleanArchitecture)