# # RIRentalCar 🚗💻

RIRentalCar is a simple WPF desktop application built in C# that simulates a car rental system.  
The project was created as part of my coursework, but also as a way to explore how to combine a database, models, and UI pages into a functional application.

---

## ✨ Features
- **Car management**: add new cars, view a full list of cars, or remove existing ones.
- **Reservations**: choose a car, select start and end dates with a calendar, and the app calculates the total rental price. Booked dates are automatically blocked.
- **Reviews**: leave a review with a rating and comment, and browse through all submitted reviews.
- **Login-protected actions**: adding and deleting cars require logging in.

---

## 🛠️ Technologies
- **C# / .NET (WPF)** for the application.
- **Entity Framework Core** for data access.
- **SQLite** as the local database (`RentalCarDB.db`).

---

## 📂 Project Structure
- **Models**
  - `Car` – stores car info (model, year, price per day, availability).
  - `Reservation` – connects a car with selected dates and the total price.
  - `Review` – simple feedback with name, rating, and comment.
- **Pages**
  - `CarListPage` – overview of all cars.
  - `AddCarPage` – add new car (requires login).
  - `CarReservationPage` – reserve a car via calendar.
  - `DeleteCarPage` – delete car (requires login).
  - `ReviewEntryPage` & `ReviewListPage` – add and view reviews.
  - `LoginPage` – basic login to unlock admin actions.
- **Main Menu / Main Window** – entry point and navigation.

---

## 🗄️ Database
The app uses a local SQLite database with three tables:
- **Cars**
- **Reservations**
- **Reviews**

Reservations are linked to cars (1-to-many).  
Business rules include preventing overlapping reservations and disabling already booked dates in the UI.

---

## 🛣️ Roadmap
- Improve authentication (replace hard-coded credentials).  
- Introduce roles (admin/user) and separate permissions.  
- Add model-level validations and database constraints.  

---

## 📌 Notes
- This project is written fully in **C#** using **Visual Studio 2022**.  
- The main goal was to combine UI, database, and simple business logic into one working system.  

---
