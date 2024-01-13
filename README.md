# DOTNET-CORE POKEMON REVIEW API

This is the mini dotnet-core api development practice project.

## Tech Stacks

- Dotnet Core
- EntityFramework Core
- MySql

## UML Diagram

![UML](examples/UML.png)
Credit [Teddy Smith](https://www.youtube.com/watch?v=_8nLSsK5NDo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0&index=2)

## NuGet Packags

- Microsoft.EntityFrameworkCore.Design
- MySql.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- MySql.Data

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
