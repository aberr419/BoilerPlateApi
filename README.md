
# A multi tenant .Net Core API

Multitenancy within the same data store is achieved by extracting a tenantId from the request by use of middleware, 
and setting that value in a scoped service. The value is then used within ApplicationDbContext as a global query filter. 
This form of multi tenancy does not achieve database isolation, which could be needed in situations where 
multi-tenant clients need to ensure privacy on protected data.

Ways in which isloation may be achieve might include managing environment variables that define the connection string per
instance of the application. Or by including multiple connection strings in the appsettings and resolving which one to use 
per request.

Migrations:
	initial migration command: add-migration InitialApp -context ApplicationDbContext -o Migrations/AppDb

	These commands need to be run in package manager console once per addition/modification of entities. This should happen with ApplicationDbContext as follows:
		add-migration <MigrationName> -context ApplicationDbContext -o Migrations/AppDb
		update-database -Context ApplicationDbContext

	

