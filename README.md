# AssetManagement

A .NET Core application to manage and display asset information.

## Features

This application provides an API to manage asset information and prices. It allows you to:
- Retrieve all assets or a specific asset.
- Create a new asset or update an existing asset.
- Retrieve the price of one or more assets for a given date, optionally from a specific source. Results include the timestamp for when each price was last updated (or created).
- Add a price for a given asset, source, and date, or update an existing price.

---
## Design Decisions

### Separation of Concerns
The application separates concerns by using different repositories for assets and prices. This modularity enhances maintainability and scalability.

### Test-First Approach
The application is developed using a test-first approach, ensuring functionality is verified before implementation, resulting in more robust and reliable code.

### In-Memory Storage
For simplicity and demonstration purposes, the application uses in-memory lists to store data. In a production environment, these would be replaced by database calls.

## Running the Application

1. **Clone the Repository**:
    ```sh
    git clone <https://github.com/FK-Library/AssetManagement.git>
    ```

2. **Restore Dependencies**:
    ```sh
    dotnet restore
    ```

3. **Run Tests**:
    ```sh
    dotnet test
    ```

4. **Run the Application**:
    ```sh
    dotnet run
    ```

## API Endpoints

### Asset Endpoints
- **GET /api/asset**: Retrieve all assets.
- **GET /api/asset/{id}**: Retrieve a specific asset.
- **POST /api/asset**: Create a new asset.
- **PUT /api/asset/{id}**: Update an existing asset.
- **DELETE /api/asset/{id}**: Delete an existing asset.

### Price Endpoints
- **GET /api/price/{assetId}/{date}**: Retrieve prices for a specific asset on a specific date.
- **GET /api/price/{assetId}**: Retrieve all prices for a specific asset.
- **POST /api/price**: Add or update a price for a given asset, source, and date.

## Project Structure

- **AssetManagement**: Contains the main application code.
   - Controllers
   - Models
   - Repositories
- **AssetManagement.Test**: Contains the test project.
   - Test cases for the controllers and other components.


## Alternative Designs Considered

### Database Integration
Integrating a database such as SQL Server or MongoDB for persistent storage would provide a more scalable and robust solution. This was not implemented in the current solution for simplicity and to focus on demonstrating the core functionality.

### Repository Pattern
Implementing a more complex repository pattern with dependency injection and multiple layers for data access was considered. This would enhance testability and separation of concerns.

## Assumptions

- Each asset can have only one price per source per date.
- The application uses in-memory storage for simplicity.

## Further Improvements

- **Database Integration**: Replacing in-memory storage with a database for persistent storage.
- **Authentication and Authorization**: Implementing authentication and authorization mechanisms to secure the API.
- **Logging and Error Handling**: Adding comprehensive logging and error handling for better maintainability and troubleshooting.
- **SOLID Principles**: Refactoring code to adhere more closely to SOLID principles, such as using dependency inversion to inject repositories.
