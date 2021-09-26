# NFL Stats Loader
.NET Core CLI NFL Statistics and Roster Entry Loader

## Description

.NET CLI application(s) that handle converting the payloads from the NodeJS scraper application to the Data Access Objects to save to a SQL Server Database.

There are three projects contained:

* __NflStats.Data__: Data Access Objects that represent the database.  Also contains Entity Framework classes for interacting with the database.
* __NflStats.Loader__: CLI Application that transforms the NodeJS scraper application payloads to the Data Access Objects and saves to the SQL Server Database.
* __NflStats.Roster.Loader__: CLI Application that transforms Roster Entries from the NodeJS Scraper application to the Database Objects.

## Configuration

The following configuration items are set in the __appsettings.json__ file:

* __ConnectionString__: Connection string to the SQL Server Database.
* __SourceFolder__: Directory where JSON files are located to be processed.
