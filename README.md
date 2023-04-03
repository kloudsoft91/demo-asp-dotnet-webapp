# Introduction 
This is an extension of a project based a C# tutorial course. The tutorial was extended to connect to a mysql database and store / retrieve some data. Due to this being a learning / sample project, the documentation is limited / a work in progress. The mysql db dockerfile is not part of this project.

# Authors

- Name: Karan Nayak
  email: nayakaran@gmail.com

# Getting Started
1.	[Build and Test](#build-and-test)
2.	[Environment Variables](#environment-variables)
3.	[API Reference](#api-reference)

# Build and Test
To build and run this project, run a docker image build and run the container with the following env vars.

# Environment Variables

To run this project, you will need to add the following environment variables to your docker container

`DBHOST` - The fqdn of the mysql db host / container

`DBPORT` - The port to use the db connection, note: this project uses the MYSQLX plugin to interact with mysql, which defaults on 33060 (not 3306)

`DBUSER` - The username to use for the db connection

`DBPASS` - The password for the database user

`DBNAME` - The name of the database to connect to

# API Reference

## Get all items

```http
  GET /api/booking
```

## Post item

```http
  POST /api/booking
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `ParkingStart`      | `DateTime` | **Required**. Start date/time of parking |
| `ParkingEnd`      | `DateTime` | **Required**. End date/time of parking |
| `Type`      | `string` | **Required**. Type of booking: Staff / General |
| `Rego`      | `string` | **Required**. Registration of car |


If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)
