### Migration: add

`dotnet ef --project ./Messenger.Persistence/ --startup-project ./Messenger.WebApi/ migrations add <MIGRATION_NAME>`

### Migration: apply

`dotnet ef database update --project ./Messenger.Persistence/ --startup-project ./Messenger.WebApi --verbose`

### Migration: list

`dotnet ef migrations list --project ./Messenger.Persistence/ --startup-project ./Messenger.WebApi`

### Migration: behavior rules 

```
Database.EnsureDeleted();
Database.EnsureCreated();
Database.Migrate();
```
