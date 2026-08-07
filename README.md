# Jwt
# JWT Authentication - Clean Architecture

## Overview

## Architecture

## Technologies

## Project Structure

## Authentication Flow

## Database

## JWT

## Angular Client

## Getting Started

## Configuration

## Running the Project

## API Endpoints

## Future Improvements





                    Angular
                       │
                       │ HTTP
                       ▼
              ┌─────────────────┐
              │       API       │
              └────────┬────────┘
                       │
                       ▼
              ┌─────────────────┐
              │   Application   │
              └────────┬────────┘
                       │
                       ▼
              ┌─────────────────┐
              │     Domain      │
              └─────────────────┘
                       ▲
                       │
              ┌────────┴────────┐
              │  Infrastructure │
              │                 │
              │ EF Core         │
              │ Identity        │
              │ SQL Server      │
              │ JWT             │
              └─────────────────┘
