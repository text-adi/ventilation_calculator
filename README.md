1. Для створення моделі БД по БД, яка вже пристуння, потрібно виконати команду

```
dotnet ef dbcontext scaffold "Data Source=mydatabase.db" Microsoft.EntityFrameworkCore.Sqlite -o Models
```

## Міграція

1. Ініціація файла міграції
```
dotnet ef migrations add <Name migration>

Add-Migration
```
2. Виконуємо міграцію
```
dotnet ef database update

Update-Database
```