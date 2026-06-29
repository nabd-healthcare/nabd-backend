# Nabd Healthcare Backend System

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![.NET Version](https://img.shields.io/badge/.NET-10.0-purple)
![Architecture](https://img.shields.io/badge/architecture-Clean%20Architecture-blue)
![License](https://img.shields.io/badge/license-MIT-green)

A comprehensive backend system for the Nabd Healthcare Medical OS, built with .NET 10 following Clean Architecture principles. It provides complete APIs for patient management, doctor scheduling, medical AI diagnostics, payments, and multi-tenant clinic operations.

---

## Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [System Architecture](#system-architecture)
- [Solution Structure](#solution-structure)
- [Folder Structure](#folder-structure)
- [Database Design](#database-design)
- [Authentication & Authorization](#authentication--authorization)
- [AI Module](#ai-module)
- [API Documentation](#api-documentation)
- [Frontend Integration](#frontend-integration)
- [Configuration](#configuration)
- [Database Seeders](#database-seeders)
- [Error Handling](#error-handling)
- [Deployment Guide](#deployment-guide)
- [Performance](#performance)
- [Project Roadmap](#project-roadmap)
- [Known Limitations](#known-limitations)
- [Tech Stack](#tech-stack)
- [How to Run Locally](#how-to-run-locally)
- [Production URLs](#production-urls)
- [Contributing](#contributing)
- [License](#license)

---

## About the Project

The Nabd Healthcare Backend is the core engine powering a next-generation medical operating system.

### Business Idea
The platform bridges the gap between patients, doctors, and clinics. It provides a centralized Medical OS for managing health records, scheduling appointments, performing AI-assisted diagnosis, and handling payments securely.

### The Problem It Solves
Traditional healthcare systems suffer from fragmented patient records, inefficient scheduling, lack of integrated AI diagnostics, and disjointed payment flows. Nabd unifies these features into a robust, high-performance ecosystem.

### Target Users
- **Patients**: To find doctors, book appointments, view medical history, and pay online.
- **Doctors**: To manage schedules, perform sessions, use AI diagnostics, and write prescriptions.
- **Verifiers / Admins**: To verify medical licenses and monitor system statistics.
- **Clinics**: Multi-tenant clinic management for comprehensive facility operations.

### User Roles
- Patient: Standard user role for seeking medical care.
- Doctor: Medical professional requiring verification.
- Verifier: Administrative role responsible for auditing doctor licenses.
- Admin: System administrator with overarching permissions.

### Current Implementation Status
The backend is fully implemented and production-ready, featuring JWT authentication, comprehensive API endpoints, real-time AI diagnosis integration, Entity Framework Core with SQL Server, and robust error handling.

---

## Features

### Authentication & Authorization
- **JWT-based Security**: Access and refresh token flows.
- **Role-based Access Control (RBAC)**: Strict policies for Doctor, Patient, and Verifier endpoints.
- **OTP Verification**: Email verification and password reset flows.

### Patients
- **Profile Management**: Personal details, emergency contacts, and demographic data.
- **Medical Records**: Comprehensive history including allergies, past conditions, and surgeries.
- **Search & Filter**: Advanced doctor search by specialty, rating, and availability.

### Doctors
- **Profile & Verification**: License upload, specialization, and professional bio.
- **Schedule Management**: Availability slots, overrides, and consultation types (online/offline).
- **Dashboard Analytics**: Real-time stats on completed sessions, revenue, and patient flow.

### Appointments & Sessions
- **Booking Engine**: Conflict-free booking with concurrency handling.
- **Session Lifecycle**: Pending -> Confirmed -> CheckedIn -> InProgress -> Completed.
- **Live Session Management**: Medical terminal for documenting chief complaints, HPI, and management plans.

### Medical Records & Prescriptions
- **Digital Prescriptions**: Structured medication data with dosage, frequency, and instructions.
- **Dispensing Records**: Tracking medication fulfillment.
- **Diagnostic Notes**: Centralized consultation records tied to specific appointments.

### Diagnosis AI
- **Python Integration**: Seamless execution of Python-based Machine Learning models.
- **Symptom Mapping**: Translating user-friendly symptoms to standard medical encodings.
- **Predictive Analytics**: Returning top possible conditions with confidence percentages.

### Reviews & Ratings
- **Patient Feedback**: Post-appointment rating system (1-5 stars) and textual reviews.
- **Doctor Aggregation**: Automatic calculation of average ratings and total review counts.

### Payments
- **Transaction Processing**: Handling appointment fees.
- **Status Tracking**: Pending, Completed, Failed, Refunded states.

### Notifications
- **Real-time Alerts**: Push notifications and email triggers for appointment state changes.
- **Actionable Modals**: Prompting patients to review completed appointments.

### Verifier System
- **License Auditing**: Dedicated module for verifiers to approve or reject doctor applications.
- **System Statistics**: Global metrics on users, appointments, and system health.

---

## System Architecture

The Nabd Backend follows **Clean Architecture**, enforcing strict separation of concerns and a one-way dependency rule.

### Layers Description
1. **Domain Layer (Nabd.Core)**: The innermost layer. Contains all enterprise-wide logic, business entities, enums, and interfaces. It has zero dependencies on other projects.
2. **Application Layer (Nabd.Application)**: Contains business use cases, DTOs, and interface implementations (Services). It depends only on the Core layer.
3. **Infrastructure Layer (Nabd.Infrastructure)**: Handles external concerns such as the Database (Entity Framework Core), File Storage, Email dispatching, and Identity management. It implements interfaces defined in Application/Core.
4. **Presentation Layer (Nabd.API)**: The outer layer hosting the ASP.NET Core REST API. It handles HTTP requests, routes, and responses, depending on the Application layer to process requests.
5. **Shared Layer (Nabd.Shared)**: Contains cross-cutting concerns, helpers, and constants used across multiple layers.

### Dependency Flow
API -> Infrastructure -> Application -> Core
This ensures that the business logic (Core/Application) remains completely ignorant of the database (Infrastructure) and web delivery mechanisms (API).

### Request Lifecycle
1. HTTP Request hits the **Controller** in Nabd.API.
2. The Controller maps the request to a DTO and passes it to an **Application Service** (e.g., IPatientService).
3. The Service retrieves domain entities from the **Repository** (in Nabd.Infrastructure).
4. Business rules are applied to the entity.
5. Changes are persisted via the Repository/Unit of Work.
6. The Service returns a standardized BaseResponse<T> DTO back to the Controller.
7. The Controller returns an appropriate HTTP Status Code (200, 400, 404).

### Why Clean Architecture?
Chosen for maximum maintainability, testability, and scalability. It allows replacing the database (e.g., SQL Server to PostgreSQL) or the delivery mechanism without altering a single line of business logic.

---

## Solution Structure

The .sln file contains the following projects:

- **Nabd.API**: ASP.NET Core Web API project. Contains Controllers, Program.cs, and Dependency Injection configuration.
- **Nabd.Application**: Class library containing Application Services, DTOs, Mapping profiles, and AI integration logic.
- **Nabd.Core**: Class library containing Entities (e.g., Patient, Doctor, Appointment), Enums, and core abstractions.
- **Nabd.Infrastructure**: Class library containing EF Core DbContext, Repositories, Migrations, and external service integrations.
- **Nabd.Shared**: Common utilities, constants, and custom exception classes.

---

## Folder Structure

### Nabd.API
- /Controllers: HTTP endpoint handlers grouped by feature (e.g., AppointmentsController).
- /Middlewares: Custom HTTP middlewares (e.g., GlobalExceptionMiddleware).
- /Extensions: Service collection extensions for clean DI setup.

### Nabd.Application
- /DTOs: Data Transfer Objects for Requests and Responses.
- /Services: Implementations of business logic interfaces.
- /Interfaces: Contracts for repositories and services.
- /AI: Contains Python scripts (medical_ai_service.py), models (.pkl), and data JSONs for diagnostics.

### Nabd.Core
- /Entities: Domain models categorized by feature (Base, Identity, Medical, System, Clinics).
- /Enums: Standardized enumerations (e.g., AppointmentStatus).

### Nabd.Infrastructure
- /Data: ApplicationDbContext and EF Core entity configurations (Fluent API).
- /Repositories: Generic and specific repository implementations.
- /Migrations: Entity Framework Core migration history.
- /Seeders: Data seeders for initial database population.

---

## Database Design

The system uses **Entity Framework Core** with **SQL Server**.

### Key Entities & Relationships
- **User (Base Identity)**: Extended from ASP.NET Core Identity. Navigates 1:1 to Patient, Doctor, or Verifier.
- **Doctor**: Has many DoctorConsultation (specialties), DoctorDocument (licenses), DoctorAvailability (schedule), Appointment, and DoctorReview.
- **Patient**: Has many Appointment, MedicalHistoryItem, and Review.
- **Appointment**: The central transaction record connecting Patient and Doctor. Contains properties for AppointmentTime, Status, and Payment.
- **ConsultationRecord**: 1:1 with Appointment. Contains clinical notes (Chief Complaint, HPI, Diagnosis).
- **Prescription**: 1:1 with Appointment. Contains a collection of PrescribedMedication.
- **Clinic**: A facility entity that can host multiple doctors. Has many ClinicService, ClinicPhoneNumber, and ClinicPhoto.

### Base Classes
- AuditableEntity: Adds CreatedAt, CreatedBy, UpdatedAt, UpdatedBy to entities.
- SoftDeletableEntity: Adds IsDeleted and DeletedAt for soft-delete functionality.

---

## Authentication & Authorization

Secured using **JSON Web Tokens (JWT)** and **ASP.NET Core Identity**.

### Flow
1. User logs in with Email/Password.
2. Server validates credentials and generates a short-lived **JWT Access Token** (e.g., 15 mins) and a long-lived **Refresh Token** (e.g., 7 days).
3. Client stores Access Token in memory and Refresh Token in an HttpOnly Cookie (or secure local storage).
4. Protected API endpoints demand the Authorization: Bearer <token> header.

### Roles & Policies
- Roles: Admin, Verifier, Doctor, Patient.
- Role claims are embedded in the JWT.
- Controllers use [Authorize(Roles = "Doctor")] to enforce access control.

---

## AI Module

The Nabd Backend uniquely integrates a **Python-based Machine Learning service** directly within the .NET application context for medical diagnostics.

### Components
- **medical_ai_service.py**: A Python script utilizing joblib and scikit-learn/
umpy to load a pre-trained model (medical_model.pkl).
- **Data Files**: symptom_to_ecode.json, ecode_to_name.json, diseases_ar.json for mapping user symptoms to AI features and translating disease predictions to Arabic.

### Workflow
1. The .NET DiagnosisController receives an array of symptom strings from the frontend.
2. The MedicalDiagnosisService serializes the input into JSON.
3. .NET spawns a System.Diagnostics.Process calling python ai/medical_ai_service.py '<json>'.
4. Python script loads the joblib model, processes the vector, and runs .predict_proba().
5. Python outputs a JSON string to stdout.
6. .NET intercepts the output, deserializes it, and returns a strongly-typed DiagnosisResponse to the client.

### Limitations & Requirements
- Requires Python 3 installed on the host server.
- The joblib model (medical_model.pkl) is loaded per request (cold start overhead). Future iterations may wrap this in a FastAPI microservice for persistent model loading.

---

## API Documentation

The API follows RESTful principles, utilizing proper HTTP verbs (GET, POST, PUT, DELETE, PATCH) and status codes.

### Controller Groups
- **AuthController**: Handles login, registration, email verification, and password resets.
- **PatientsController** & **PatientProfileController**: Endpoints for patient data retrieval and updates.
- **DoctorsController** & **DoctorDashboardController**: Endpoints for doctor searching, profile management, and dashboard statistics.
- **AppointmentsController** & **DoctorSessionsController**: Managing the lifecycle of medical appointments and active clinical sessions.
- **PrescriptionsController**: Managing medications and digital prescriptions.
- **DiagnosisController**: Endpoint for the AI Diagnostic tool.
- **VerifierController**: Endpoints for administrators to verify doctor applications.
- **SeedController**: Utility for populating the database with mock data.

### Request & Response Conventions
Every endpoint returns a standardized response envelope:
`json
{
  "isSuccess": true,
  "data": { ... },
  "message": "Operation completed successfully.",
  "errors": []
}
`

### Pagination & Filtering
List endpoints (e.g., getting appointments or doctors) accept query parameters for pagination (PageNumber, PageSize) and return pagination metadata in the response. Advanced filtering is handled via query parameters (e.g., ?specialty=cardiology&city=cairo).

---

## Frontend Integration

The frontend should consume the API using HTTP clients like xios or etch.

### Token Handling
- The JWT ccess_token must be attached to the Authorization header as a Bearer token.
- Handle 401 Unauthorized responses by attempting to refresh the token using the refresh token flow, then retrying the original request.

### File Uploads
- Use multipart/form-data for endpoints expecting file uploads (e.g., uploading a doctor's medical license or clinic photos).
- Ensure the field name matches the backend DTO (e.g., IFormFile LicenseFile).

---

## Configuration

The application is configured via ppsettings.json and environment variables.

### Key Sections
- **ConnectionStrings**: Contains DefaultConnection for SQL Server.
- **JwtSettings**: Contains Secret, Issuer, Audience, and ExpiryMinutes.
- **MailSettings**: SMTP configuration for sending emails (e.g., SendGrid, Mailjet, or SMTP server).
- **PythonConfiguration**: Path to the Python executable (python3 or specific path) used for the AI module.

---

## Database Seeders

The database can be pre-populated using Seeders found in Nabd.Infrastructure/Seeders.

### Execution Order
1. **Roles Seeder**: Creates predefined Identity roles.
2. **Users Seeder**: Creates admin, verifier, doctor, and patient accounts.
3. **Medical Data Seeder**: Generates mock conditions, symptoms, and specialties.
4. **Appointments Seeder**: Generates historical and upcoming appointments for testing.

*The seeders can be triggered via the SeedController endpoint in Development environments.*

---

## Error Handling

### Validation
Uses **FluentValidation** integrated via a pipeline behavior in MediatR (if MediatR is used) or directly in controllers. Invalid models return 400 Bad Request with an array of specific field errors in the errors property of the response wrapper.

### Global Exception Handling
A custom GlobalExceptionMiddleware catches all unhandled exceptions, logs them using the configured logging provider (e.g., Serilog/ILogger), and returns a standard 500 Internal Server Error JSON response. It prevents stack traces from leaking into production.

---

## Deployment Guide

### Requirements
- Windows Server / Linux VPS
- .NET 10 SDK / Runtime
- SQL Server
- Python 3.x (with joblib, scikit-learn, 
umpy)

### Steps
1. **Clone & Pull**: Retrieve the latest code from the main branch.
2. **Database Migration**: Run dotnet ef database update to apply the latest schema.
3. **Publish**: Run dotnet publish -c Release -o ./publish.
4. **Python Setup**: Ensure the i folder is copied to the publish directory. Install required pip packages globally or via virtualenv.
5. **Host Service**: Configure IIS, Kestrel via Systemd (Linux), or a Docker container.
6. **Environment Variables**: Set ASPNETCORE_ENVIRONMENT to Production and configure secure connection strings/JWT secrets.

---

## Tech Stack

- **Framework**: .NET 10 (ASP.NET Core Web API)
- **Language**: C# 12, Python 3
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity & JWT
- **Architecture**: Clean Architecture
- **AI / ML**: Scikit-Learn, Joblib, Numpy

---

## How to Run Locally

1. **Clone the repository**: git clone https://github.com/nabd-healthcare/nabd-backend.git
2. **Navigate to the Backend**: cd Nabd/Back/src/Nabd.API
3. **Update Connection String**: Open ppsettings.Development.json and set your local SQL Server instance.
4. **Apply Migrations**: dotnet ef database update -p ../Nabd.Infrastructure -s .
5. **Run the Project**: dotnet run
6. **Access Swagger**: Open browser at https://localhost:5001/swagger

*Note: Ensure Python is installed and accessible via system PATH to test the AI Diagnosis feature.*

---

## License

This project is licensed under the MIT License.
