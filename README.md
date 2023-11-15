# GWVACB_HFT_2023241

## Introduction

> The projects goal was to show a small layered applications structure, from the frontend to the backend.

This repository consists of several layers, each serving a specific role in the overall functionality of the application. The layers include Repository, Logic, Test, Endpoint, Client, and Model.

## Layers

### 1. Repository

The Repository layer is built on ASP Core and serves as the REST API for the project. It handles data storage and retrieval, providing a seamless interface for interacting with the underlying database.

### 2. Logic

[Provide a brief description of the Logic layer and its role in the project. This could include any business logic, data processing, or other essential functionalities.]

### 3. Test

The Test layer is crucial for ensuring the reliability and robustness of the application. It covers all create and non-CRUD methods, validating that each component performs as expected.

### 4. Endpoint

The Endpoint layer is responsible for exposing the functionalities of the system to external entities. It uses HTTP communication and JSON-based data exchange to facilitate seamless integration with other services.

### 5. Client

The Client layer offers a Simple Console Menu interface, providing users with access to CRUD and non-CRUD methods exposed by the Endpoint. Communication between the client and the endpoint is JSON-based and occurs over HTTP.

### 6. Model

The Model layer defines the structure of the data within the system. It includes entities such as Author, Quote, and Comment, each with specific attributes to capture relevant information.

## Database Structure

The database utilized by the application comprises three main tables:

1. **Author**
    - Fields: id (int), name (string), age (int), country (string)

2. **Quote**
    - Fields: id (int), authorId (int), title (string), content (string)

3. **Comment**
    - Fields: id (int), content (string), quoteId (int)

---
Made by: **Tánczos János** (GWVACB) for HFT