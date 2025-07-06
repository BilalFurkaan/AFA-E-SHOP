# AFA Shop - E-Commerce Web Application

A modern e-commerce web application built with ASP.NET Core MVC, featuring a clean and responsive design.

## 🚀 Features

- **Modern UI/UX**: Blue-themed responsive design with glassmorphism effects
- **Product Management**: Browse, search, and filter products
- **Shopping Cart**: Add/remove items with quantity management
- **User Authentication**: Login/Register system with Identity
- **Order Management**: Complete order processing
- **Responsive Design**: Mobile-first approach
- **Image Optimization**: Automatic image resizing and optimization

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 7.0 MVC
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Image Processing**: Image optimization with external service

## 📋 Prerequisites

- .NET 7.0 SDK
- PostgreSQL Database
- Visual Studio 2022 or VS Code

## 🔧 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/afa-shop.git
cd afa-shop
```

### 2. Database Setup
1. Install PostgreSQL
2. Create a new database named `Shoper`
3. Set up your connection strings

### 3. Configure Database Contexts
**IMPORTANT**: The database context files with connection strings are not included in the repository for security reasons.

1. **Create AppDbContext.cs**:
   - Copy `Shoper.Persistence/Context/AppDbContext.template.cs`
   - Rename it to `AppDbContext.cs`
   - Replace the connection string with your actual database credentials

2. **Create AppIdentityDbContext.cs**:
   - Copy `Shoper.Persistence/Context/Identity/AppIdentityDbContext.template.cs`
   - Rename it to `AppIdentityDbContext.cs`
   - Replace the connection string with your actual database credentials

Example connection string:
```
Host=localhost;Port=5432;Database=Shoper;Username=your_username;Password=your_password
```

### 4. Run Database Migrations
```bash
cd Presentation/Shoper.WebApp
dotnet ef database update
```

### 5. Run the Application
```bash
dotnet run
```

The application will be available at `https://localhost:7000`

## 🔒 Security

- Database connection strings are not committed to the repository
- Template files are provided for easy setup
- Authentication and authorization implemented
- Input validation and sanitization

## 📁 Project Structure

```
Shoper/
├── Presentation/
│   └── Shoper.WebApp/          # Main web application
├── Shoper.Application/         # Application layer (services, DTOs)
├── Shoper.Domain/             # Domain entities
└── Shoper.Persistence/        # Data access layer
    └── Context/
        ├── AppDbContext.template.cs        # Template for AppDbContext
        └── Identity/
            └── AppIdentityDbContext.template.cs  # Template for AppIdentityDbContext
```

## 🎨 UI Features

- **Modern Design**: Blue gradient theme with glassmorphism
- **Responsive Layout**: Works on all device sizes
- **Interactive Elements**: Hover effects, animations, and transitions
- **Image Optimization**: Automatic resizing and WebP conversion
- **Loading States**: Smooth user experience with loading indicators

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Bootstrap for the responsive framework
- FontAwesome for icons
- Images.weserv.nl for image optimization service

## 📞 Support

For support and questions, please open an issue in the GitHub repository. 