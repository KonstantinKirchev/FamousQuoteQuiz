Famous Quote Quiz - Full Stack Solution

Project Overview

This repository contains a full-stack implementation of the Famous Quote Quiz, developed as a technical task. 
The application is designed to be an interactive game where users guess the authors of famous quotes through two different gameplay modes.  

Core Features

Part 1: Front-End Game Experience
The user-facing part of the application consists of two primary pages:  

Quiz Page: An interactive game interface where users are presented with famous quotes.  

Binary Mode (Default): Users answer "Yes" or "No" to whether a specific author said a given quote. 
Multiple Choice Mode: Users choose the correct author from three possible options.  

Instant Feedback: The system provides immediate validation for answers, displaying "Correct! The right answer is: ...." or "Sorry, you are wrong! The right answer is: ....".  
Progression: Upon answering, options disappear to reveal the correct author and a "Next" button to proceed to the next quote.  
Settings Page: Allows users to seamlessly switch between Binary and Multiple Choice modes.  

Part 2: Administrative Management
A comprehensive management suite designed for administrators to maintain the platform:  

User Management: Full CRUD (Create, Read, Update, Delete) capabilities for user accounts, including the ability to disable or enable users.  
Quote Management: Dedicated interface to list, create, update, and delete quotes and their associated authors.  
User Achievements Review: A reporting tool to review game history, showing which questions were presented to specific users and how they responded.  
Data Organization: All management lists include appropriate sorting and filtering for efficient data handling.  

Tech Stack

Frontend: React.js
Utilizes a modern JS framework for an interactive, single-page application (SPA) experience.  
Proposes a custom UI/UX design for administrative pages that aligns with the established visual style of the game.  

Backend: ASP.NET Core Web API
Provides a robust and scalable RESTful API to handle game logic and management features.  

Data Access: Entity Framework Core
Used for Object-Relational Mapping (ORM) to manage the database efficiently.  
Database: SQL ServerA backup of the database is included in the deliverables to ensure easy environment setup.  

Deliverables

Project Solution: Complete source code for both the React frontend and ASP.NET Core backend.  
Database Backup: SQL Server database backup for local restoration.  
Description of the solution: This comprehensive overview of the implementation. 
