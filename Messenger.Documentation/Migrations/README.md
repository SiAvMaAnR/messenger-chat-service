### Migration: add (./Messenger.Persistence)

`dotnet ef --startup-project ../Messenger.WebApi/ migrations add <MIGRATION_NAME>`

### Migration: apply (./Messenger.Persistence)

`dotnet ef database update --startup-project ../Messenger.WebApi --verbose`

### Migration: list (./Messenger.Persistence)

`dotnet ef migrations list --startup-project ../Messenger.WebApi`

### Migration: behavior rules 

```
Database.EnsureDeleted();
Database.EnsureCreated();
Database.Migrate();
```
