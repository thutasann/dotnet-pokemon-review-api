# DOTNET-CORE POKEMON REVIEW API

This is the mini dotnet-core api development practice project.

## Tech Stacks

- Dotnet Core
- EntityFramework Core
- MySql

## UML Diagram

![UML](examples/UML.png)
Credit [Teddy Smith](https://github.com/teddysmithdev)

## NuGet Packags

- Microsoft.EntityFrameworkCore.Design
- MySql.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- MySql.Data
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.Extensions.Caching.StackExchangeRedis
- Newtonsoft.Json

## Scripts

### Create Dotnet project

```bash
dotnet new webapi -o api
```

### Dotnet Watch Run

```bash
cd api
```

```bash
dotnet watch run
```

### EF Database Migration

```bash
dotnet tool install --global dotnet-ef --version 7.*
```

```bash
dotnet ef migrations add init
```

```bash
dotnet ef database update
```
