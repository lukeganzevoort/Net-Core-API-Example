# Car and Starship API

This project is a .NET Core Web API for managing car data and retrieving Star Wars starship pilots' names. It's built using .NET 8, Entity Framework Core, and integrates with the Star Wars API (SWAPI).

## Features

- CRUD operations for `Car` objects.
- Retrieve the list of pilot names for a given Star Wars starship.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 8 SDK
- SQL Server
- Postman for testing API endpoints

### Installing

1. Clone the repository to your local machine.
2. Open the solution in your IDE.
3. Restore NuGet packages.
4. Set up the database connection string in `appsettings.json`.
5. Run the application.

### Temporary Database

A temporary database can be created on localhost for debugging.

Prerequisites:

- Docker

Run:

- Run the sql_start.sh file to start the docker container `$ ./sql_start.sh`

## Usage

### Car Endpoints

- `GET /cars`: Retrieves all cars.
- `GET /cars/{id}`: Retrieves a car by its ID.
- `POST /cars`: Creates a new car.
- `PUT /cars/{id}`: Updates an existing car.

### Starship Pilots Endpoint

- `GET /starships/pilots/{starshipName}`: Retrieves a list of pilot names for the specified starship.

## Running the tests

1.  GET All Cars:

    - URL: http://localhost:5164/cars
    - Method: GET
    - Test Criteria: You should receive a list of cars in JSON format. Success is indicated by a 200 OK status code.

2.  GET Car by ID:

    - URL: http://localhost:5164/cars/{id} (Replace {id} with a specific car ID, e.g., http://localhost:5164/cars/1).
    - Method: GET
    - Test Criteria: If a car with the given ID exists, you should receive the details of that car in JSON format with a 200 OK status. If the car does not exist, you should receive a 404 Not Found status.

3.  POST Create a New Car:

    - URL: http://localhost:5164/cars
    - Method: POST
    - Body (raw JSON in Postman):
      ```json
      {
        "Make": "Toyota",
        "Model": "Corolla",
        "Year": 2021,
        "Color": "Red",
        "Price": 20000
      }
      ```
    - Test Criteria: Upon success, you should receive the created car object in the response with a 201 Created status. Check for the presence of the car's ID in the response to confirm it was successfully created.

4.  PUT Update an Existing Car:

    - URL: http://localhost:5164/cars/{id} (Replace {id} with the ID of the car you want to update, e.g., http://localhost:5164/cars/1).
    - Method: PUT
    - Body (raw JSON in Postman):
      ```json
      {
        "Id": 1, // Ensure this matches the ID in the URL
        "Make": "Toyota",
        "Model": "Corolla",
        "Year": 2022, // Change some details for the update
        "Color": "Blue",
        "Price": 21000
      }
      ```
    - Test Criteria: A successful update will result in a 204 No Content status. To confirm the update, you can perform a GET request for the same car and check if the details have been updated.

5.  GET Starship Pilots:

    - URL: http://localhost:5164/starships/pilots/{starship} Replace {starship} with the name of the starship you're interested in, such as "Millennium Falcon" or "Death Star".
      For example, http://localhost:5164/starships/pilots/MillenniumFalcon.
    - Method: GET
    - Test Criteria: You should receive a list of pilot names for the specified starship in JSON format. Success is indicated by a 200 OK status code.
      Example of a Successful Response:
      ```json
      ["Chewbacca", "Han Solo", "Lando Calrissian", "Nien Nunb"]
      ```
