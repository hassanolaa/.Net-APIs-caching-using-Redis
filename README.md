# .Net APIs Caching using Redis

This project demonstrates simple API endpoints caching using Redis and ASP.NET.

## Features

- Caching API responses using Redis.
- Efficient data retrieval and reduced database load.
- Easy integration with ASP.NET applications.

## Prerequisites

- .NET SDK
- Redis server

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/hassanolaa/.Net-APIs-caching-using-Redis.git
   cd .Net-APIs-caching-using-Redis
   
2. **Install dependencies**:
    ```bash
   dotnet restore
3. **Configure Redis**:
    Ensure that your Redis server is running and update the connection string in appsettings.json if necessary.
   ```json
   {
   "Redis": {
    "ConnectionString": "localhost:6379"
   }
    }
## Example
  ``` c#
[HttpGet]
[Route("api/data")]
public async Task<IActionResult> GetData()
{
    var cacheKey = "cachedData";
    var cachedData = await _cache.GetStringAsync(cacheKey);

    if (cachedData != null)
    {
        return Ok(cachedData);
    }

    var data = await _dataService.GetDataAsync();
    await _cache.SetStringAsync(cacheKey, data);

    return Ok(data);
}
```
## Contributing
Contributions are welcome! Please fork this repository and submit a pull request.

## License
This project is licensed under the MIT License.
You can use this template as a starting point and customize it further based on your specific project requirements.
   
