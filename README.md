# 🛍️ Shoper - E-Commerce Platform

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-green.svg)](https://dotnet.microsoft.com/apps/aspnet)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-8.0-orange.svg)](https://docs.microsoft.com/en-us/ef/)

Modern e-commerce platform built with Clean Architecture principles using ASP.NET Core 8.0.

## ✨ Features

- **User Authentication**: Secure login/register system
- **Product Catalog**: Browse and search products
- **Shopping Cart**: Add/remove items with AJAX
- **Order Management**: Complete checkout process
- **User Profile**: Update personal info and password
- **Price Filtering**: Dynamic price range filters
- **Responsive Design**: Mobile-friendly UI

## 🏗️ Architecture

```
shoper/
├── 📁 Shoper.Domain/          # Entities & Interfaces
├── 📁 Shoper.Application/     # Services & DTOs
├── 📁 Shoper.Persistence/     # DbContext & Repositories
└── 📁 Presentation/           # Web App & API
    ├── 📁 Shoper.WebApp/      # MVC Application
    └── 📁 Shoper.WebApi/      # REST API
```

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core 8.0** - ORM
- **PostgreSQL Server** - Database
- **Identity Framework** - Authentication

### Frontend
- **Bootstrap 5.3** - CSS framework
- **jQuery 3.6** - JavaScript library
- **Font Awesome** - Icons
- **Toastr.js** - Notifications

### Development
- **JetBrains Rider** - IDE
- **Git** - Version control
- **NuGet** - Package manager

## 🚀 Quick Start

### Prerequisites
- .NET 8.0 SDK
- PostgreSQL 17
- JetBrains Rider (recommended)

### Setup

1. **Clone repository**
```bash
git clone https://github.com/yourusername/shoper.git
cd shoper
```

2. **Create database**
```sql
CREATE DATABASE ShoperDB;
```

3. **Update connection string**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ShoperDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

4. **Run migrations**
```bash
cd Shoper.Persistence
dotnet ef database update
```

5. **Run application**
```bash
cd Presentation/Shoper.WebApp
dotnet run
```

## 📊 Database Schema

### Main Tables
- **Products** - Product information
- **Customers** - User data
- **Orders** - Order details
- **Carts** - Shopping cart
- **Categories** - Product categories
- **Cities/Towns** - Address data

### Environment Variables
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_string"
  }
}
```

## 🔗 API Endpoints

### Products
- `GET /api/products` - List all products
- `GET /api/products/{id}` - Get product details
- `POST /api/products` - Create new product
- `PUT /api/products` - Update product
- `DELETE /api/products` - Delete product

### Categories
- `GET /api/categories` - List all categories
- `GET /api/categories/{id}` - Get category details
- `POST /api/categories` - Create new category
- `PUT /api/categories` - Update category
- `DELETE /api/categories` - Delete category

### Carts
- `GET /api/carts` - List all carts
- `GET /api/carts/{id}` - Get cart details
- `POST /api/carts` - Create new cart
- `PUT /api/carts` - Update cart
- `DELETE /api/carts` - Delete cart

### CartItems
- `GET /api/cartitems` - List all cart items
- `GET /api/cartitems/{id}` - Get cart item details
- `POST /api/cartitems` - Create new cart item
- `PUT /api/cartitems` - Update cart item
- `DELETE /api/cartitems` - Delete cart item

### Orders
- `GET /api/orders` - List all orders
- `GET /api/orders/{id}` - Get order details
- `POST /api/orders` - Create new order
- `PUT /api/orders` - Update order
- `DELETE /api/orders` - Delete order

### OrderItems
- `GET /api/orderitems` - List all order items
- `GET /api/orderitems/{id}` - Get order item details
- `POST /api/orderitems` - Create new order item
- `PUT /api/orderitems` - Update order item
- `DELETE /api/orderitems` - Delete order item

### Customers
- `GET /api/customers` - List all customers
- `GET /api/customers/{id}` - Get customer details
- `POST /api/customers` - Create new customer
- `PUT /api/customers` - Update customer
- `DELETE /api/customers` - Delete customer

## 💻 Developer

**Bilal Furkan Karaca**
- GitHub: [@bilalfurkankaraca](https://github.com/bilalfurkankaraca)

---
    
⭐ Star this repository if you found it helpful!
