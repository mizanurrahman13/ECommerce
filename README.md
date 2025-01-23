
# ECommerce MVC Project with .NET 7, Repository and UnitOfWork, MSSQL, Autofac, AutoMapper, Serilog, MailTrap and NUnit Testing

This repository showcases a sample MVC Project built with .NET 7 that demonstrates a simple E-Commerce presentation. The application utilizes Repository, UnitOfWork Design Pattern. Together, these components provide a robust foundation for structured web Project.

## Table of Contents

- [Getting Started](#getting-started)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/mizanurrahman13/ECommerce.git
   ```
2. Navigate to the project directory
   ```sh
   cd ECommerce
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Migrations:
   Follow ECommerce_Migration_Runner file.

## Architecture Overview

This template follows the 3-Tier Architecture, here Repository UnitOfWork Design Pattern organizes code by Layered, promoting high cohesion, low coupling and Separation of concern.

## Features

- **Built with .NET 7**: Utilizes the latest features for efficient development.
- **Repository and UnitOfWork** : Provides abstraction, transaction management, and simplifies data access logic.
- **Autofac**: Streamlines dependency injection, improves code maintainability, and enhances testability.
- **AutoMapper**: Streamlines object-to-object mapping, reduces boilerplate code, and enhances maintainability.
- **Serilog**: Enhances logging capabilities, provides structured logs, and simplifies troubleshooting..
- **Stored Procedure**: Enhances performance, security, and code reusability in databases.
- **MSSQL**: Powerful relational database for data storage.
- **EF Core**: Popular .NET ORM.
- **NUnit Testing**: Ensures code reliability, supports TDD, and automates unit tests..

## Technologies Used

- **.NET 7**
- **Repository and UnitOfWork**
- **Stored Procedure**
- **Autofac**
- **AutoMapper**
- **Serilog**
- **MailTrap**
- **MSSQL**
- **EF Core**
- **NUnit Testing**

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Create a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.
