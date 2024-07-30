# CarBook - Car Renting Project

## The Main Purpose of Our Project

Developed with ASP.NET Core 8.0 Web API and MVC, this project allows the user to rent a car by location, list vehicle prices according 
to vehicle brand models on a hourly, daily, weekly and monthly basis, make user-specific blog comments and browse comments, and provide various
statistics on the admin side. It is a web project that has various statistics and graphics and allows CRUD operations to be performed by the admin. 
In the project, all CRUD operations are performed through the API and these operations are consumed on the MVC side. The aim is to make the 
code more sustainable by using the Onion Architecture architectural structure and CQRS, Mediator design patterns. Additionally, the project covers 
important topics such as JWT, Fluent Validation.


## Features:

### User Pages:

Searching: List and rent available vehicles according to suitable location.
Car Reviews: Users can comment their thoughts about cars.
Blog Comments: Users can comment on blog posts.


### Admin Pages:

Inventory Management: Tools for managing car inventory.

Product Management: Capabilities to add, edit, and delete cars.

CRUD Operations: Admins can perform CRUD operations on all entities of the website, including cars, categories, reviews, and blog comments. 



## Technologies Used:

## Backend:

Asp.Net Core Web API: Robust framework for server-side logic.

Entity Framework: Efficient ORM for database interactions and management.

MSSQL: Reliable and scalable database management system.

Design Patterns: CQRS and Mediator.

Fluent Validation:  Ensures that the data received and sent by the application meets the required business rules and constraints. 
It helps in creating clean and maintainable validation logic.

Onion Architecture: Provides a clear separation of concerns and promotes a more maintainable and testable codebase by organizing 
the code into layers. This architecture ensures that the core logic of the application remains independent of the UI and data access code.

## Frontend:

HTML, SASS: For structured and styled markup.

JavaScript, jQuery: For a responsive and interactive user interface.

Bootstrap: For responsive design and consistent styling.


## Authentication:

JWT (JSON Web Token): A compact, URL-safe means of representing claims to be transferred between two parties.
It allows for secure token-based authentication. JWTs are used for securely transmitting information between the client and the server as a JSON object.
They are signed using a cryptographic algorithm to ensure the claims cannot be altered after the token is issued.


## Some Images of the Project:
