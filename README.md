# Hero Management API

## Introduction

This project is an API for managing heroes and their superpowers, using ASP.NET Core with Entity Framework Core for backend and Angular for frontend. The application allows for CRUD (Create, Read, Update, Delete) operations on heroes and their superpowers.

## Architecture

The application is organized into the following layers:
- **Controllers:** Contains the API controllers that handle HTTP requests and return the appropriate responses.
- **Domain:** Contains the domain entities and repository interfaces.
- **Infrastructure:** Contains the repository implementations and the database context.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper

## Features

### HeroController

The `HeroController` handles operations related to heroes.

- **PostHero:** Adds a new hero and their associated superpowers to the database.
- **GetHeroes:** Returns a list of all heroes.
- **GetHero:** Returns a specific hero based on the ID.
- **PutHero:** Updates the information of an existing hero.
- **DeleteHero:** Removes a hero from the database.

### SuperpowerController

The `SuperpowerController` handles operations related to superpowers.

- **PostSuperpower:** Adds a new superpower to the database.
- **GetSuperpowers:** Returns a list of all superpowers.
- **GetSuperpower:** Returns a specific superpower based on the ID.

## Entities

### Hero

The `Hero` entity represents a hero in the system.

- **Id:** Unique identifier of the hero.
- **Name:** Real name of the hero.
- **HeroName:** Hero name.
- **BirthDate:** Date of birth.
- **Height:** Height.
- **Weight:** Weight.
- **HeroSuperpowers:** List of hero's superpower associations.

### Superpower

The `Superpower` entity represents a superpower in the system.

- **Id:** Unique identifier of the superpower.
- **Name:** Superpower name.
- **Description:** Description of the superpower.
- **HeroSuperpowers:** List of heroes associated with this superpower.

## Repositories

### HeroRepository

The `HeroRepository` is responsible for performing database operations for the `Hero` entity.

- **GetAllHeroesAsync:** Returns all heroes.
- **GetHeroByIdAsync:** Returns a specific hero based on the ID.
- **AddHeroAsync:** Adds a new hero to the database.
- **UpdateHeroAsync:** Updates the information of an existing hero.
- **DeleteHeroAsync:** Removes a hero from the database.

### SuperpowerRepository

The `SuperpowerRepository` is responsible for performing database operations for the `Superpower` entity.

- **GetAllSuperpowersAsync:** Returns all superpowers.
- **GetSuperpowerByIdAsync:** Returns a specific superpower based on the ID.
- **AddSuperpowerAsync:** Adds a new superpower to the database.

## How It Works

1. **Adding a Hero:**
   - In the `POST /api/hero` endpoint, a new hero is created along with their superpower associations.

2. **Listing Heroes:**
   - In the `GET /api/hero` endpoint, all registered heroes are returned.

3. **Getting a Hero by ID:**
   - In the `GET /api/hero/{id}` endpoint, a specific hero is returned based on the provided ID.

4. **Updating a Hero:**
   - In the `PUT /api/hero/{id}` endpoint, the information of an existing hero is updated, including their superpower associations.

5. **Removing a Hero:**
   - In the `DELETE /api/hero/{id}` endpoint, a hero is removed from the database.

6. **Adding a Superpower:**
   - In the `POST /api/superpower` endpoint, a new superpower is created.

7. **Listing Superpowers:**
   - In the `GET /api/superpower` endpoint, all registered superpowers are returned.

8. **Getting a Superpower by ID:**
   - In the `GET /api/superpower/{id}` endpoint, a specific superpower is returned based on the provided ID.

