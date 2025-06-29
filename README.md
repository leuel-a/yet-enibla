# YetEnibla – Restaurant Review Website

A simple restaurant review website built with Razor Pages and Tailwind CSS. The app is containerized with Docker and deployed on an Azure Ubuntu server.

## Tech Stack

- ASP.NET Core (Razor Pages)
- Tailwind CSS
- Postgres (Entity Framework Core)
- Docker
- Azure (Ubuntu Server)

## Features

- Add and list restaurants
- Form validation with Data Annotations
- Responsive UI using Tailwind CSS

## Running Locally

```bash
git clone https://github.com/yourusername/your-repo-name.git
cd your-repo-name
docker build -t yetenibla .
docker run -d -p 5000:80 yetenibla
```

Then open httP//localhost:3000 in your browser.
