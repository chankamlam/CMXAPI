

### luanch project
install git
```
```
after pull the code to local
```
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
after modified connection string of mysql (better use docker to setup the mysql db)
```
dotnet restore && dotnet run
```
visit http://localhost:5062/swagger
