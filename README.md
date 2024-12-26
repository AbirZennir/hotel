# Getting Started with Hotel Reservation Application

This project was built using **ASP.Net Core MVC** for the Front-office (Web) and **WPF** for the Back-office (Desktop).

## Available Features

### Front-office (ASP.Net Core MVC)
In this part of the project, clients can:
- Create an account.
- Search and filter available rooms.
- Make reservations.
- Receive email confirmation after booking.
- Download their reservation receipt in PDF format.

### Back-office (WPF)
Administrators can:
- Manage employees, clients, rooms, and reservations.
- Monitor payments and export/import data in CSV or Excel format.
- Generate reservation receipts in PDF format.
- View dashboards with detailed statistics.

## Available Scripts

### ASP.Net Core MVC (Front-office)
#### `dotnet run`
Runs the ASP.Net Core MVC application in development mode.  
Open [http://localhost:5000](http://localhost:5000) to view it in your browser.

#### `dotnet publish`
Builds the application for production to the `publish` folder.  
The build is optimized for performance and ready for deployment.  

### WPF Application (Back-office)
#### Running the Application
You can run the WPF application directly from Visual Studio:
1. Open the solution file.
2. Set the WPF project as the startup project.
3. Press `F5` to run the application in development mode.

### Database Setup
1. Create the SQL Server database using the scripts available in the `/Database` folder.  
2. Update the connection strings in the `appsettings.json` (for Front-office) and `App.config` (for Back-office) files to match your database configuration.

## Learn More

To learn more about the technologies used in this project, visit:
- [ASP.Net Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [WPF Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)

### Common Issues
#### `dotnet run` Fails
If you encounter issues while running the project:
1. Verify that the .NET SDK is correctly installed.
2. Ensure the SQL Server database is properly configured and accessible.

#### WPF Application Does Not Start
1. Check for missing dependencies in Visual Studio.
2. Confirm that the database connection string is correct.

#### Deployment Issues
- Refer to the [ASP.Net Core Deployment Guide](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/).
- For WPF, use [ClickOnce Deployment](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/app-development/deploying-a-wpf-application-clickonce).

---

© 2024 EMSI Marrakech | All rights reserved.
