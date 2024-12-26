# Building Web API that supports for Shopee Management

- Timeline: 15 days
- Start Date: 2023-03-20

### Practice Scenarios

- Admin can:

  - Register/Login: By email/pass
  - Product management
    - Get all products: Pagination, Filter, Order
    - Create product
    - Update product
    - Delete product

- User can:

  - Register/Login: By email/pass
  - Get all products: Pagination, Filter, Order
  - Add/Delete products in his/her carts
  - Buy all products on carts (cash on delivery)
  - Get the purchase history

- The user will receive an email notification (text only) after the order (optional)

### Tech-stack

- [x] Architecture: N-Tier Architecture
- [x] Database: PostgreSql
- [x] EF Core for data access
  - [x] Generic Repository Pattern
  - [x] Unit of work patterns
- [x] Dependency Injection
- [x] API versioning
- [x] Using a mapper package For mapping (Mapster or AutoMapper)
- [x] Swashbuckle For API documentation
- [x] FluentValidation For Model validations
- [x] Using Serilog for logging capabilities
- [x] Custom middleware to show the request and response with the timeline
- [x] XUnit & MOQ for Unit Testing
- [ ] Integration Test With Docker
- [x] Source code analysis
  - [x] Using .Net Analyzer
- [x] Test app by Postman / Visual studio .http files
- [x] Deploy Using Docker

### Break Down Tasks and Estimation (Total: 15 Days)

1. Init Application Following N-Tier Architecture (4 day)
   - Init folder structure
   - Init Unit test with XUnit & MOQ
   - Define SQL server configuration
   - Init API versioning
   - Init Swagger & Swashbukle for API Documentation
   - Install .Net Analyzer
   - Init Serilog
2. Define Application Schemas (1 day)
   - Admin
   - User
   - Product
   - Order
   - Order Item
   - Cart Item
3. Implement Authentication & Authorization (2 day)
   - Register Admin
   - Register User
   - Login
4. Implement CRUD (6 days)
   - User CRUD (1 day)
   - Assign User Role
   - Product CRUD (2 day)
   - Cart CRUD (1 day)
   - Order API (1 day)
   - Purchase History CRUD (1 day)
5. Deploy Application Using Docker (2 days)

### How To Run

1. Open solution: Shopee.sln
2. Run Docker Compose

### How To Run TestCase

1. Open Test Explore
2. Run All TestCase

### Common Issues & Solutions

1. Migration Database in Shopee

- When you have a solution with 3 projects API, Application and Infrastructure, in project you can pass in the options on the command line.

  ```
    Shopee
       | Shopee.API
       |-- Programs.cs
       | Shopee.Infrastructure
       |-- ShopeeDbContext.cs
       |-- ShopeeAuthDbContext.cs
  ```

- Change into the solution directory

  ```
  - cd Shopee

  - dotnet ef migrations add InitialCreate --project Shopee.Infrastructure --startup-project Shopee.API --context ShopeeDBContext
  - dotnet ef database update --project Shopee.Infrastructure --startup-project Shopee.API --context ShopeeDbContext

  - dotnet ef migrations add InitialCreate --project Shopee.Infrastructure --startup-project Shopee.API --context ShopeeAuthDBContext
  - dotnet ef database update --project Shopee.Infrastructure --startup-project Shopee.API --context ShopeeDbContext
  ```

  Reference: https://stackoverflow.com/a/69207083
