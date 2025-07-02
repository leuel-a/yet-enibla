# Yet Enibla

YetEnibla is a lightweight restaurant review web application built using ASP.NET Core Razor Pages and styled with Tailwind CSS. It provides a simple interface for users to add new restaurants and view details including name, description, and location. The project utilizes containerization with Docker and is deployed on an Azure-hosted Ubuntu server for streamlined deployment and scalability.

## Features
- **Add and View Restaurants:** Users can create and review restaurant entries.
- **Responsive Design:** Tailwind CSS delivers a clean, responsive interface.
- **Data Management:** Uses Entity Framework Core with PostgreSQL (via Npgsql) for reliable data operations.
- **Containerized Deployment:** Docker integration simplifies deployment and scaling.
- **Modern Development:** Built with ASP.NET Core (.NET 8) and Razor Pages for a robust web experience.

## Technologies Used
- **Backend:** ASP.NET Core Razor Pages, .NET 8, Entity Framework Core
- **Database:** PostgreSQL (using Npgsql)
- **Frontend:** Tailwind CSS (with PostCSS, autoprefixer, and prettier for formatting)
- **Containerization:** Docker
- **Package Management:** npm for handling Tailwind CSS and related tools

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org)
- PostgreSQL (with a valid connection string)

### Setup and Running Locally

1. **Clone the Repository:**
   ```bash
   git clone <repository-url>
   cd <repository-directory>
   ```

2. **Restore .NET Dependencies:**
   ```bash
   dotnet restore
   ```

3. **Install Node.js Dependencies:**
   ```bash
   npm install
   ```

4. **Build the Tailwind CSS:**
   ```bash
   npm run css:build
   ```
   This command processes your CSS with PostCSS, autoprefixer, and prettier configurations (including the Tailwind plugin).

5. **Database Setup (optional):**
   If using EF Core migrations, update your database:
   ```bash
   dotnet ef database update
   ```

6. **Run the Application:**
   ```bash
   dotnet run
   ```
   Then, navigate to `https://localhost:5001` (or the URL displayed in your terminal) in your browser.

### Docker Deployment

If you prefer to run the application in a container:

1. **Build the Docker Image:**
   ```bash
   docker build -t yetenibla .
   ```

2. **Run the Docker Container:**
   ```bash
   docker run -p 80:80 yetenibla
   ```

## Project Structure

- **Pages/**: Contains all the Razor Page files organized by functionality (e.g., create, detail, edit, list).
- **wwwroot/**: Contains static files including the generated Tailwind CSS.
- **tailwind.config.js**: Configuration for Tailwind CSS.
- **yet-enibla.Web.csproj**: The project file outlining dependencies, build targets, and specific commands (such as the Tailwind CSS build command before each build).

## Deployment Considerations

- The application is optimized for a containerized environment.
- When deploying to production (e.g., on an Azure Ubuntu server), ensure that the environment variables and connection strings are properly configured.

## Troubleshooting

- **CSS Build Issues:** Run `npm run css:build` separately to diagnose Tailwind CSS build errors.
- **Database Connection:** Double-check your PostgreSQL connection string and ensure the database service is running.
- **Node.js Compatibility:** Verify that your Node.js version is compatible with the npm packages specified in the project.

Enjoy using YetEnibla to explore and share reviews of your favorite restaurants!
