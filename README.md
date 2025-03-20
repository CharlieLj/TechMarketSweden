# How to Open and Run the Project

Follow these steps to open and run the project locally:

## 1. Download the Project
- Download the project as a ZIP file from the repository.

## 2. Open the Project in Visual Studio Community
- Extract the ZIP file and open the project in **Visual Studio Community**.

## 3. Install Required NuGet Packages
- Go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.
- Install the following NuGet packages (version 8):
  - **Microsoft.EntityFrameworkCore.SqlServer**
  - **Microsoft.EntityFrameworkCore.Tools**

## 4. Update the Database
- Open the **Package Manager Console** (under **Tools** > **NuGet Package Manager** > **Package Manager Console**).
- Run the following commands to update the database:
  Add-Migration UpdateData
  Update-Database
