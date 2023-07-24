# TV Shows Application

This is a sample solution for a TV Shows application that allows users to interact with a list of TV shows, mark shows as favorites, and view the list of favorite shows.

###Solution Structure

The solution consists of several projects organized as follows:

- **TVShows.Application:**  Contains the application logic, including MediatR handlers and other service classes.
- **TVShows.Domain:** Contains domain classes and repository interfaces.
- **TVShows.Infrastructure:** Implements the application infrastructure, including repositories and any other data access logic.
- **TVShows.-Console:** Project that exposes access points for clients to interact with the application.
- **TVShows.Tests:** Contains unit tests for different components of the application

###Dependencies

The solution uses the following main dependencies:

- **.NET 6 SDK:** .
- **MediatR:** Used to implement the Command-Query Responsibility Segregation (CQRS) pattern and manage interactions between controllers and handlers.
- **Entity Framework Core: **Used for database access and entity-to-table mapping.
- **NUnit and JustMock:** Used for unit testing.

###Database Configuration

The application uses a local SQL Server database to store TV show data and user favorites. To set up the local database, follow these steps:

1. Make sure you have SQL Server installed on your machine or have access to a SQL Server instance.
2. Open the appSettings.json file of the TVShows.Infrastructure project.
3. In the DefaultConnection section, update the ConnectionString with the correct information for your SQL Server instance. For example:

    	"ConnectionStrings": {
			"DefaultConnection": "Data Source={Host};Initial Catalog={DatabaseName};Integrated Security=True;TrustServerCertificate=True
		}
	
- Once the connection string is updated, you can proceed with running the migration command-line.

###Running Migration
To create the database and apply the migrations, you can use the Entity Framework Core command-line tools. Here is how to do it:

1. Open a command prompt or terminal.
2. Change the working directory to the TVShows.Infrastructure project folder:

    	cd path/to/TVShows.Infrastructure

3. Run the migration command:

 		dotnet ef database update

This will apply the pending migrations and create the TVShows database on your SQL Server instance.

###Running the Application

To run the application, follow these steps:

1. Open the solution in Visual Studio or your preferred IDE.
2. Set the TVShows.Console project as the startup project.
3. Press F5 or click the "Start" button to run the application. Or by command line:

 		cd path/to/TVShows.Console
then:
 		dotnet run

- The application will start and be accessible at the specified URL (e.g., https://localhost:1443).

###Unit Testing

The **TVShows.Tests** project contains unit tests for different functionalities of the application. The tests are written using the NUnit testing framework, and JustMock are used to simulate external dependencies.

To run the tests, simply go to the root folder in your terminal.

 		cd ..

then:

 		dotnet run test
Or click "Run Tests" in your IDE.
