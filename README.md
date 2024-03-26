# Bamboo Card Test Project

This project is developed using .NET Core 6 Web API.

## Development Environment

- Operating System: macOS Ventura 13.5.2
- .NET Core (version 7.0.308)

## System Requirements

- Operating System: MacOS , Windows, Linux
- .NET Core 6 or above

## Cloning the Project

To clone the project, run the following command in your terminal:

git clone https://github.com/anwaarnoaman/Bamboo-card-test.git

## Opening the Project in Visual Studio Code

To open the project in Visual Studio Code, follow these steps:

    Open Visual Studio Code.
    Go to File > Open...
    Navigate to the directory where you cloned the project (Bamboo-card-test) and select it.
    Click "Open".

## Running the Project in Visual Studio Code

To run the project in Visual Studio Code, open the terminal and execute the following commands:

    dotnet restore
    dotnet run

You can access the API at: http://localhost:5000

## Opening the Project in Visual Studio

To open the project in Visual Studio, double-click on the Api.sln file.

Running the Project in Visual Studio

To run the project in Visual Studio, open the terminal and execute the following commands:

    dotnet restore
    dotnet run

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

## How to use

for (vscode and visual studio) open http://localhost:5000
for (docker and docker compose) open http://localhost:44319

app will be opend in swagger UI

<img width="1429" alt="Screenshot 2024-03-26 at 12 22 04 PM" src="https://github.com/anwaarnoaman/Bamboo-card-test/assets/37085691/78ea83d6-a1b3-4ae3-a893-1d1ec65c6b0e">

Click on "Try it out" and in Parameters enter N number of news to fetch.

in responce body section retrieved data can be found in data object

{
  "id": null,
  "message": "Best stories retrieved successfully",
  "success": true,
  "status": "success",
  "data": [
    {
      "id": 39799755,
      "deleted": false,
      "type": "story",
      "by": "surprisetalk",
      "time": 1711200242,
      "text": null,
      "dead": false,
      "parent": 0,
      "poll": 0,
      "kids": [39800657],
      "url": "https://oimo.io/works/life/",
      "score": 1491,
      "title": "Game of Life, simulating itself, infinitely zoomable",
      "parts": null,
      "descendants": 243
    }
  ],
  "stackTrace": null
}






