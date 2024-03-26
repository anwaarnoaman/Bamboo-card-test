# Bamboo Card Test Project

This project is developed using .NET Core 6 Web API.

## System Requirements

- Operating System: macOS Ventura 13.5.2
- .NET Core 6

## Cloning the Project

To clone the project, run the following command in your terminal:

<!-- ```bash
git clone https://github.com/anwaarnoaman/Bamboo-card-test.git
  -->

## Opening the Project in Visual Studio Code

To open the project in Visual Studio Code, follow these steps:

    1.Open Visual Studio Code.
    2.Go to File > Open...
    3.Navigate to the directory where you cloned the project (Bamboo-card-test) and select it.
    3.Click "Open".

## Running the Project in Visual Studio Code

To run the project in Visual Studio Code, open the terminal and execute the following commands:
1.dotnet restore
2.dotnet run

You can access the API at: http://localhost:5000

## Opening the Project in Visual Studio

To open the project in Visual Studio, double-click on the Api.sln file.

Running the Project in Visual Studio

To run the project in Visual Studio, open the terminal and execute the following commands:

    1.dotnet restore
    2.dotnet run

Or run the project from the toolbar.

You can access the API at: http://localhost:5000

## Running with Docker

The Docker image can be found here: anwaarnoaman/bambooapi

To run the Docker image, open the terminal and execute the following commands:

cd Bamboo-card-test
docker run -p 44319:80 anwaarnoaman/bambooapi:1.0.0

You can access the API via http://localhost:44319.

## Running with Docker Compose

To run with Docker Compose, open the terminal and navigate to the project directory (Bamboo-card-test). Then, run the following command:

    1.docker-compose up

You can access the API via http://localhost:44319.
