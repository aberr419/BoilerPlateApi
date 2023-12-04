
A .Net Core API with multi tenancy

Multitenancy -
This achieved by extracting a tenantId from the request by use of middleware, and setting that 
value in a scoped service. The value is then used within the DbContext as a global query filter. This 
form of multi tenancy does not achieve database isolation, which could be needed in situations where 
multi-tenant clients need to ensure privacy on protected data.



Migrations:

	Need to be run when adding/modifying entities this should happen in ApplicationDbContext as follows

		add-migration -Context ApplicationDbContext
		update-database -Context ApplicationDbContext

	new DbSets should be added to ApplicationDbContext.
