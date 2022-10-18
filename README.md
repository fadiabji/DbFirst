# DbFirst

// install 3 backages using nuget manager:
Microsoft.EntityFrameworkCore, 
Microsoft.EntityFrameworkCore.Tools, 
Microsoft.EntityFrameworkCore.SqlServer

// Connection string to my database on my local server
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movie_DB;Integrated Security=True

// open nuget console and write this command 
Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=Movie_DB;Trusted_Connection=true"  Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models


// if the previous one didn't work so add -Force at the end of the command like this
Scaffold-DbContext "Server=DESKTOP-8FGUNU9;Database=DatabaseFirstAssignment;Trusted_Connection=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force


// Add this lins  to appsettings.json
"ConnectionStrings": { },

// Add thos to program.cs file:

builder.Services.AddDbContext<Movie_DBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MovieDatatbase")
    ));

// add this constracture if it was doesn't exist already to file was generated called MovieDBContext.cs :
public Movie_DBContext(DbContextOptions<Movie_DBContext> options)
            : base(options)
        {
        }



