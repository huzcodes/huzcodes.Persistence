# huzcodes.Persistence

huzcodes.Persistence is a C# .NET 8 package designed to simplify data persistence operations for SQL and Oracle databases. It provides a set of functions for reading and inserting data, with support for both **synchronous** and **asynchronous** operations.
### Installation

To install huzcodes.Persistence, use the following command in the Package Manager Console:

```bash

dotnet add package huzcodes.Persistence --version 1.0.0
```
### Usage

To use **huzcodes.Persistence**, first inject the '**IDataProvider**' interface into your class constructor. Then, you can use the provided functions to interact with your database.


#### Registering the Package

```csharp

// Add the registration of persistence from inside huzcodes persistence plugin
builder.Services.AddPersistenceServices();
```
#### Reading Data Examples
SQL Reading Async Without Parameters

```csharp

var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, storageProvider: DataStorageProvider.Sql);
return Ok(data);
```
SQL Reading Async With Parameters

```csharp

var parameter = new { Id = id };
var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, parameter);
return Ok(data.FirstOrDefault());
```
Oracle Reading Async Without Parameters

```csharp

var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, storageProvider: DataStorageProvider.Oracle);
return Ok(data);
```
Oracle Reading Async With Parameters

```csharp

var parameter = new OracleDynamicParameters();
parameter.Add("Id", id, OracleMappingType.Int32, ParameterDirection.Input);
parameter.Add("DataResult", OracleMappingType.RefCursor, ParameterDirection.Output);

var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, parameter, DataStorageProvider.Oracle);
return Ok(data.FirstOrDefault());
```
#### Inserting Data Examples

SQL Inserting Async

```csharp

var parameter = new
{
    Id = dataModel.Id,
    ProductCreationDate = dataModel.Date,
    PriceWithoutTax = dataModel.PriceWithoutTax,
    ProductName = dataModel.ProductName
};

await _dataProvider.ExecuteDataAsync(createProcedureName, parameter, connectionStringKey);
return Ok();
```
Oracle Inserting Async

```csharp

var parameter = new OracleDynamicParameters();
parameter.Add("Id", dataModel.Id, OracleMappingType.Int32, ParameterDirection.Input);
parameter.Add("ProductCreationDate", dataModel.Date, OracleMappingType.Date, ParameterDirection.Input);
parameter.Add("PriceWithoutTax", dataModel.PriceWithoutTax, OracleMappingType.Decimal, ParameterDirection.Input);
parameter.Add("ProductName", dataModel.ProductName, OracleMappingType.Varchar2, ParameterDirection.Input);

await _dataProvider.ExecuteDataAsync(createProcedureName, parameter, connectionStringKey, storageProvider: DataStorageProvider.Oracle);
return Ok();
```
For more information on how to use **huzcodes.Persistence**, please refer to the [API Package Tests](https://github.com/huzcodes/huzcodes.Persistence/tree/main/huzcodes.Persistence.API).

### Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

### License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/huzcodes/huzcodes.Persistence/blob/main/LICENSE) file for details.
