# huzcodes.Persistence

huzcodes.Persistence is a C# .NET 8 package designed to simplify data persistence operations for SQL and Oracle databases. It provides a set of functions for reading and inserting data, with support for both **synchronous** and **asynchronous** operations.
### Installation

To install huzcodes.Persistence, use the following command in the Package Manager Console:

```bash

dotnet add package huzcodes.Persistence --version 1.0.0
```
### Usage

To use **huzcodes.Persistence**, first inject the '**IDataProvider**' interface into your class constructor. Then, you can use the provided functions to interact with your database.
And to use **huzcodes.Persistence** Repository, first inject the '**IRepository<your entity model>**' interface into your class constructor. Then, you can use the provided functions to interact with your database.


#### Registering the Package

```csharp

// Add the registration of persistence from inside huzcodes persistence plugin
builder.Services.AddPersistenceServices();

// Add the registration of persistence using repository inside huzcodes persistence plugin.
// Before this step you need to create a class that inject your AppDbContext and inherits from 'HuzcodesRepository',
// then register it. For example let's call this class 'DbRepository'.
builder.Services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(DbRepository<>));

```
#### Reading Data Examples
SQL Reading Async Without Parameters

```csharp

var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, storageProvider: DataStorageProvider.Sql);
return Ok(data);
```
SQL Reading Async Without Parameters Using Repository

```csharp

var oData = await _repository.ListAsync();
return Ok(oData);
```

SQL Reading Async With Parameters

```csharp

var parameter = new { Id = id };
var data = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName, connectionStringKey, parameter);
return Ok(data.FirstOrDefault());
```

SQL Reading Async With Parameters Using Repository

```csharp

var oResult = await _repository.GetByIdAsync(id);
return Ok(oResult);
```

SQL Reading Async With Parameters Using Repository and Specifications

```csharp

var readByIdSpecification = new ReadByIdSpecifications(id);
var oResult = await _repository.FirstOrDefaultAsync(readByIdSpecification);
return Ok(oResult);
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

SQL Inserting Async Using Repository

```csharp

var oData = new DataModel()
{
    Id = dataModel.Id,
    Date = dataModel.Date,
    PriceWithoutTax = dataModel.PriceWithoutTax,
    ProductName = dataModel.ProductName
};

await _repository.AddAsync(oData);
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
