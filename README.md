

### luanch project
install git
```
```

after pull the code to local
```
git clone git@github.com:chankamlam/CMXAPI.git
```

installed the dotnet
https://github.com/dotnet/installer/blob/main/README.md

install ef
```
dotnet tool install -g dotnet-ef
```

install docker

install mysql
```
docker run --name some-mysql -e MYSQL_ROOT_PASSWORD=Ken5201314 -d mysql
```

modified connection string of mysql (appsettings.Development.json)
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "MysqlConnectionString": "server=localhost;database=CMX;user=root;password=Ken5201314"
  }
}

```
init the database and table
```
dotnet ef database update
```

luanch 
```
dotnet restore && dotnet run
```
visit http://localhost:5062/swagger
