# ClassMaster

ClassMaster is a powerful ASP.NET Core MVC project designed to streamline the management of educational institutions. It provides a smooth and efficient way to handle courses, instructors, trainees, departments, and course results. Built with ASP.NET Core, it uses Entity Framework Core with Code-First approach for database management, and LINQ for CRUD operations.

## Features

- **Course Management**: Add, edit, delete, and view courses.
- **Instructor Management**: Manage instructor data with full CRUD functionality.
- **Trainee Management**: Register, update, and remove trainees.
- **Department Management**: Organize departments for better structure.
- **Course Results**: Keep track of course results for each trainee.
- **Role-Based Access Control**: Uses ASP.NET Core Identity to grant full control to admins and restrict access for normal users.
- **Routing Security**: Secure routing to protect paths of controllers and restrict unauthorized access.
- **Dependency Injection**: Efficiently manage controller code with ASP.NET Core's built-in Dependency Injection.
- **Code-First Database Management**: Database created using the Code-First approach with migrations.

## Technologies Used

- **ASP.NET Core MVC** for building the web application.
- **Entity Framework Core** with Code-First approach for database management.
- **LINQ** for efficient data queries and CRUD operations.
- **ASP.NET Core Identity** for user authentication and role management.
- **Dependency Injection** to manage service dependencies.
- **Bootstrap** for responsive UI design.

## Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Youssef18118/ClassMaster.git
2. **Navigate to the project directory**:
   ```bash
   cd ClassMaster
3. **Install dependencies:**:
   - Ensure you have the latest version of the .NET SDK installed.
   - Run the following command to restore NuGet packages:
     ```bash
     dotnet restore
4. **Set up the database:**
   - The project uses Entity Framework Core with a Code-First approach.
   - Apply the migrations to create the database:
     ```bash
     dotnet ef database update
5. **Run the project:**:
   - Run it using Visual Studio.           

       
