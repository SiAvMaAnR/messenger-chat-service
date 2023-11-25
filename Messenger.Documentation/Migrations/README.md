### Migration: add (./Messenger.Persistence)

`dotnet ef --startup-project ../Messenger.WebApi/ migrations add <MIGRATION_NAME>`

### Migration: apply (./Messenger.Persistence)

`dotnet ef database update --startup-project ../Messenger.WebApi --verbose`

### Migration: disable ensure created

```
// Database.EnsureCreated();
// Database.EnsureDeleted();
```
