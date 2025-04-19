# Account Management System

This is a simple ASP.NET Core Web API application for managing customer accounts. It provides basic CRUD operations (Create, Read, Update, Delete) for customer data using Entity Framework Core with a SQL Server database.

## 🚀 Features

- Retrieve all customers
- Get a customer by ID or email
- Add a new customer
- Update customer details
- Delete a customer
- API documentation with Swagger UI


## 📁 Structure

```
AccountManagementSystem/
│
├── Controllers/
│   └── CustomerController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   └── Customer.cs
│   └── AddCustomerDto.cs
├── Program.cs
├── appsettings.json
```

### Setup Instructions

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/AccountManagementSystem.git
    cd AccountManagementSystem
    ```

2. Update your connection string in `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=AccountDB;Trusted_Connection=True;"
    }
    ```

3. Run EF Core migrations (if applicable):
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

4. Build and run the application:
    ```bash
    dotnet run
    ```

5. Navigate to Swagger UI:
    ```
    https://localhost:<port>/swagger
    ```

## 📬 API Endpoints

| Method | Endpoint               | Description                   |
|--------|------------------------|-------------------------------|
| GET    | `/customer`            | Get all customers             |
| GET    | `/customer/{id}`       | Get customer by ID            |
| GET    | `/customer/{email}`    | Get customer by email         |
| POST   | `/customer`            | Add a new customer            |
| PUT    | `/customer/{id}`       | Update an existing customer   |
| DELETE | `/customer/{id}`       | Delete a customer             |

## Models

Customer

public class Customer

{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

## AddCustomerDto

public class AddCustomerDto

{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

