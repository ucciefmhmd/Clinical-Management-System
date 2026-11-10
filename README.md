# Clinic Management System (C# Windows Forms)

A desktop application for running a small **clinic**: patients, doctors, receptionists, appointment reservations, and the doctor's diagnosis and prescription for each visit. It's built with **C# Windows Forms (.NET 8)** and **Entity Framework Core (code first) on SQL Server**. It was a team training project.

<!-- TODO(Youssef): confirm which parts you built yourself before adding a "My role" section. -->

![Screenshot](https://github.com/ucciefmhmd/Clinical-Management-System/assets/155498111/e1a4ef04-302f-46a4-8e93-772eb1c4624f)

## Features by role

The login screen asks for a role:

| Role | Can do |
|---|---|
| **Admin** | Manage patients and doctors, and open the home dashboard (counts of patients, doctors, receptionists and reservations) |
| **Doctor** | A personal dashboard of today's reservations (waiting / done), and recording a **diagnosis and medicine** for a patient |
| **Receptionist** | Register patients and book **reservations** with a doctor, including appointment time, price and status |

## Data model

| Entity | Main fields |
|---|---|
| `Patient` | Name, gender, date of birth, address, phone |
| `Doctor` | Name, specialisation, experience, contact details |
| `Reciptionist` | Name, contact details |
| `ReciptionAddPatientDoc` (reservation) | Patient, doctor, receptionist, appointment, price, state |
| `Doctorspatient` (visit record) | Patient, doctor, diagnosis, medicine |

## Running it

Requirements: Windows, the .NET 8 SDK, and SQL Server or LocalDB.

```bash
# The default connection string uses LocalDB; override it if needed:
set CLINIC_DB_CONNECTION=Server=.\SQLEXPRESS;Database=DBClinicalManagement;Trusted_Connection=True;TrustServerCertificate=True

# The repository has no EF migrations, so create the schema once:
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial
dotnet ef database update

dotnet run
```

## Known limitations (training project)

* The admin login uses **fixed demo credentials in `LoginPage.cs`**. Doctor and receptionist passwords are stored in **plain text**. A real system would use hashed passwords (for example ASP.NET Core Identity's password hasher) and no built-in accounts.
* The UI uses the third-party **Bunifu UI WinForms** controls.

## Tech

C# · Windows Forms · .NET 8 · Entity Framework Core 8 · SQL Server · Bunifu UI
