# Super Car Booking System

This project demonstrates how to use the MongoDB Provider for Entity Framework (EF) Core.

## Table of Contents

- Introduction
- Features
- Prerequisites
- Installation
- Usage

## Introduction

This project is a sample application that showcases how to integrate MongoDB with EF Core. It provides a basic setup and examples of CRUD operations.

## Features

- Integration of MongoDB with EF Core
- Basic CRUD operations
- Configuration and setup instructions

## Prerequisites

- .NET 8.0 SDK

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/vnhdangdev/SuperCarBookingSystem.git
    ```

2. Install the required packages:
    ```sh
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package MongoDB.EntityFrameworkCore
    ```

## Usage

1. Update the `appsettings.json` file with your MongoDB connection string:
    ```json
    {
      "MongoDbSettings": {
        "AtlasUri": "[CONNECTION_STRING_TO_YOUR_ATLAS_CLUSTER]",
		"DatabaseName": "[YOUR_DATABASE_NAME]"
      }
    }
    ```

2. Run the application:
    ```sh
    dotnet run
    ```