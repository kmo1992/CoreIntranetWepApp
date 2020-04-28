# .NET Core Web APIs for Company Intranets
This solution contains two Web API projects.

The **_WindowsAuth_** project is configured to authenticate users with Windows Authentication. 
Role-based authorization is used to control access to controllers and actions. 

The **_KeyAuth_** project uses a shared API Key for authentication,
This authentication will be used to authenticate services on servers that are not on the same domain controller.

## Database First
This solution does not cover database development but does assume a Database First approach.

#### Provision Database

1. Create a database called **_Sample_** on your local SQL Server instance.
2. Execute **_sample-model.sql_** on **_Sample_** database. 
3. Execute **_sample-data.sql_** on **_Sample_** database.
4. Replace '_DOMAIN\john.doe_' and '_DOMAIN\jane.doe_' in **_roles.sql_** with your AD credentials and one other user account.
5. Execute modified **_roles.sql_** on **_Sample_** database.

## Entity Framework Core
Data access is achieved using Entity Framework Core. 
EF classes were placed in the **_Shared_** project for use by both Web APIs.

#### DB Context and Models
I always generate these items from tools that Microsoft provides.

From command prompt in the **_Shared_** directory I ran the following commands.
``` 
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef dbcontext scaffold "Server=localhost;Database=Sample;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models
```
#### Data Transformation Objects 
To generate the DTOs, I did the following.

1. Copied all Models into DTOs directory (except AdUser, Role, and RoleMember).
2. Renamed classes with DTO suffix.
3. Removed all HashSet and ICollection from DTO classes.
4. Changed all Id (identity) fields to read-only (private set).
5. Validation attributes are added to DTO properties.

#### Automapper
Mapping of DTOs to Models and back is done using AutoMapper.

The configuration of all classes is done in _MappingProfile.cs_.

Two things to remember when writing controllers:
1. Controller actions **NEVER** expose Models directly! 
2. Inputs and outputs will **ALWAYS** be DTOs!

## Authentication

#### Windows
<a href="https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-3.1" target="_blank">Configure Windows Authentication in ASP.NET Core</a>

##### Role Based Authorization
Role-based lookups by authenticated users are implemented in _ClaimsTransformer.cs_.

Add **[Authorize]** to controllers and actions to lock down to authenticated users.

To further restrict access to Admins, add **[Authorize(Roles = Shared.Roles.Admin)]**.

I'm referencing a common set of role constants instead of using a raw string. The Roles must be kept up-to-date in the code and database.

#### API Key
<a href="https://medium.com/@zarkopafilis/asp-net-core-2-2-3-resti-api-24-setting-up-apikey-based-authentication-94169a051a5c" target="_blank">Setting up ApiKey-Based Authentication</a>

## API Responses
Let the framework build responses instead of rolling your own.

Error responses are handled with Validation Attributes and _ErrorController.cs_.

<a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1" target="_blank">Handle errors in ASP.NET Core web APIs</a>

## Logging
All logging will be written to Event logs. IT will use third party tools to trigger error emails and consolidate reporting.

TODO: Code to Event Log. 



