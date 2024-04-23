# GWVACB_HFT_2023241

## Introduction

> The project's goal is to showcase a small, layered full-stack application structure, from front to back end.

This repository contains several distinct layers, each playing a specific role in the functionality of the full-stack application. These layers include Frontend, Backend (Repository, Logic, Test, Endpoint, Model), and Database Structure.

## Backend Layers

### 1. Repository

The Repository layer, developed on ASP Core, functions as the REST API for the project. It manages data storage and retrieval, offering a seamless interface for interacting with the database.

### 2. Logic

The Logic layer implements the business rules and data processing essential to the application. It manipulates data retrieved via the Repository layer and enforces business policies ensuring data consistency and logic validation throughout the application.

### 3. Test

This layer is vital for maintaining the application's reliability and robustness. It tests both CRUD and non-CRUD methods, ensuring each component operates correctly under various scenarios.

### 4. Endpoint

Responsible for making the system's functionalities accessible externally, the Endpoint layer handles HTTP communications and JSON data exchanges, enabling smooth integration with other systems or services.

### 5. Model

The Model layer organizes the data structure within the application. It defines entities such as Author, Quote, and Comment, each designed to capture specific information accurately.

## Frontend Layers

### 1. ASP Web Frontend

This layer provides a web-based user interface, enabling users to interact with the application through a browser. It integrates seamlessly with the backend, facilitating data operations through a clean and intuitive graphical interface.

### 2. WPF Frontend

A Windows Presentation Foundation (WPF) frontend is also part of the project, offering a rich client application that runs on Windows. It provides a robust, user-friendly interface for accessing and managing the application's data functions.

### 3. Console Client

The Console Client offers a Simple Console Menu interface, providing users with straightforward access to CRUD and non-CRUD methods exposed by the Endpoint. Communication between the client and the endpoint is JSON-based and occurs over HTTP, enabling efficient data operations directly from the console.

## Database Structure

The database supporting the application includes three main tables:

1. **Author**
   - Fields: id (int), name (string), age (int), country (string)

2. **Quote**
   - Fields: id (int), authorId (int), title (string), content (string)

3. **Comment**
   - Fields: id (int), content (string), quoteId (int)

---

**Developer:** Tánczos János (GWVACB) for HFT