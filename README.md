# E-Commerce Platform

A robust and scalable E-Commerce platform built with ASP.NET Core 8, implementing Onion Architecture pattern with separate layers for core business logic, services, and data access.

## 🚀 Features

- Onion Architecture implementation
- Unit of Work pattern for transaction management
- Specification Design Pattern for complex querying
- RESTful API endpoints
- Entity Framework Core for data access
- Identity framework for authentication and authorization
- CORS enabled for cross-origin requests
- Swagger/OpenAPI documentation
- Error handling middleware
- Static files support
- Postman integration for API testing
- Secure payment processing with Stripe integration

## 🏗️ Architecture

The solution follows Onion Architecture and is divided into multiple projects:

- **E_Commerce**: Main API project with controllers and middleware
- **ECommerce.Core**: Core business logic and domain models
- **ECommerce.Services**: Application services and business operations
- **ECommerce.Repository**: Data access layer and Entity Framework implementation with Unit of Work pattern

## 🛠️ Technology Stack

- ASP.NET Core 8
- Entity Framework Core
- Microsoft Identity
- Swagger/OpenAPI
- SQL Server (Database)
- Postman for API testing
- Unit of Work pattern for data access
- Stripe API for payment processing
- Specification Design Pattern for querying

## ⚙️ Prerequisites

- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 or VS Code
- Postman (for API testing)
- Stripe account and API keys

## 🚀 Getting Started

1. Clone the repository
```bash
git clone [your-repository-url]
```

2. Navigate to the project directory
```bash
cd E_Commerce
```

3. Restore dependencies
```bash
dotnet restore
```

4. Update the database connection string in `appsettings.json`

5. Apply database migrations
```bash
dotnet ef database update
```

6. Run the application
```bash
dotnet run
```

The API will be available at `https://localhost:5001` (or the port specified in your configuration)

## 🔒 API Security

The API uses JWT Bearer token authentication. Make sure to:
1. Register a new user
2. Login to obtain the JWT token
3. Include the token in the Authorization header for protected endpoints

## 📚 API Documentation

When running in development mode, you can access the Swagger UI at:
```
https://localhost:5001/swagger
```

For API testing, you can use the provided Postman collection which includes:
- Authentication endpoints
- Product management
- Order processing
- User management

## 🤝 Contributing

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details

## 📧 Contact

[ahmedsanad880@gmail.com]


## 💳 Payment Processing

The platform integrates with Stripe for secure payment processing. To set up payments:

1. Create a Stripe account and obtain your API keys
2. Add your Stripe keys to the configuration:
   ```json
   "StripeSettings": {
     "PublishableKey": "your_publishable_key",
     "SecretKey": "your_secret_key"
   }
   ```
3. The system supports:
   - Credit/Debit card payments
   - Payment intents
   - Payment confirmation
   - Refund processing

## 🔍 Querying with Specifications

The project implements the Specification Design Pattern for complex querying scenarios:

```csharp
// Example of a product specification
public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
{
    public ProductWithBrandAndTypeSpecification()
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }

    public ProductWithBrandAndTypeSpecification(int id) 
        : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}
```

Benefits of using Specifications:
- Encapsulates complex query logic
- Promotes code reusability
- Improves maintainability
- Separates query logic from business logic
- Makes testing easier

---
⭐️ If you found this project helpful, please give it a star on GitHub! 
