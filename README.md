# AkvelonTestTask

### Migration
If you want to use your own migrations or you want
to test migration mechanism follow next steps:

* Set the connection string of the following form:

```
"ConnectionStrings": {
    Server=(localdb)\\mssqllocaldb;Database=<your_database_name>;Trusted_Connection=True;Integrated Security=True;User Instance=False;
}
```

> note that you have to do next steps from your working directory!

* install the ```ef``` utility:

```PS> dotnet tool install --global dotnet-ef```

* If you have migrations files delete them:

```PS> dotnet ef migrations remove```

* Create new migrations:

```PS> dotnet ef migrations add <migration_name>```

* Update SqlLocalDb by your migrations:

```PS> dotnet ef database update```

### Sorters documentation

you can use following sorting mechanisms

| method name     |                   result                          |
|-----------------|---------------------------------------------------|
| priority_asc    | projects sorted by priority in ascending order    |
| priority_desc   | projects sorted by priority in descending order   |
| status_asc      | projects sorted by status in ascending order      |
| status_desc     | projects sorted by status in descending order     |
| start_date_asc  | projects sorted by start date in ascending order  |
| start_date_desc | projects sorted by start date in descending order |

Example:

sortingString: ```priority_asc```

### Paging documentation

use int number to limit project results range

Example:

Limit: ```1```

### Filters documentation
you can use following filtering mechanisms

| method name     | val      |              result                      |
|-----------------|----------|------------------------------------------|
| priority        | int      | projects filtered by selected priority   |
| status          | int      | projects filtered by selected status     |
| startAt         | DateTime | projects filtered by selected start date |

Example:

filterString: ```startAt_16.12.2022```

filterString: ```priority_1```

filterString: ```status_1```

### TO-DO and problems
due to the size of the project, I decided not to add a Dto, but this should be done in normal projects.
Please note that I am not doing this because of ignorance, but because of the lack of meaning in this particular project
