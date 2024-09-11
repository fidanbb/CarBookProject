# CarBook - Car Renting Project

## The Main Purpose of Project

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

![Screenshot 2024-07-30 195507](https://github.com/user-attachments/assets/f491a96c-7742-42ac-a331-8b477272269c)

![Screenshot 2024-07-30 195521](https://github.com/user-attachments/assets/61fd37fd-a8b6-489b-a482-28b733972ebc)

![Screenshot 2024-07-30 195538](https://github.com/user-attachments/assets/31a2d9c4-9a8b-4b40-97d1-a80565f3e675)

![Screenshot 2024-07-30 195557](https://github.com/user-attachments/assets/3f9a853c-bde1-40ce-9347-e8190af292c2)

![Screenshot 2024-07-30 200018](https://github.com/user-attachments/assets/c2a08044-43af-4649-ba97-a43c37c644be)

![Screenshot 2024-07-30 200106](https://github.com/user-attachments/assets/b5b5e5a2-7d6a-47ee-9e82-2c1bc5a16f44)

![Screenshot 2024-07-30 200131](https://github.com/user-attachments/assets/3f17376a-79fe-4e5d-b381-045f2ea1823c)

![Screenshot 2024-07-30 200241](https://github.com/user-attachments/assets/8d199c1a-d369-483b-a460-6da10e554f91)

![Screenshot 2024-07-30 200255](https://github.com/user-attachments/assets/777a07ff-04b9-4270-bbfd-058c2b3cb1ca)

![Screenshot 2024-07-30 200314](https://github.com/user-attachments/assets/ba8122e2-5647-4e48-8bf7-fe2dbb47d955)

![Screenshot 2024-07-30 200328](https://github.com/user-attachments/assets/f3116546-0762-4830-b947-a19c18809733)

![Screenshot 2024-07-30 200348](https://github.com/user-attachments/assets/22a55fb2-b856-4dad-8c2a-b5b74da58ca9)

![Screenshot 2024-07-30 200355](https://github.com/user-attachments/assets/529cedba-1653-407d-b0d6-38aec6d6c41f)

![Screenshot 2024-07-30 200408](https://github.com/user-attachments/assets/95c3f6c3-71f2-4243-959e-4e4fd307cd25)

![Screenshot 2024-07-30 200442](https://github.com/user-attachments/assets/5107fd07-e7ed-480f-8483-add88e3b45bb)

![Screenshot 2024-07-30 200510](https://github.com/user-attachments/assets/927dce09-acc5-445c-a3f6-3b255dc826cc)

![Screenshot 2024-07-30 200519](https://github.com/user-attachments/assets/e83d3a65-352b-4136-8c4b-3879f472041e)

![Screenshot 2024-07-30 200529](https://github.com/user-attachments/assets/28cef1d6-2f33-4367-ab77-affcf04e6bd0)

![Screenshot 2024-07-30 200549](https://github.com/user-attachments/assets/edee13f7-83f8-4eb0-a967-745a6955f8a5)

![Screenshot 2024-07-30 200604](https://github.com/user-attachments/assets/96449b83-fc70-419c-9ad3-c570e125a2c3)

![Screenshot 2024-07-30 200618](https://github.com/user-attachments/assets/d5d705d0-931d-4c20-a530-156d5f47e60b)

![Screenshot 2024-07-30 200647](https://github.com/user-attachments/assets/794f29c0-c688-4c1f-a732-783bd25a6a57)

![Screenshot 2024-07-30 200716](https://github.com/user-attachments/assets/941f3f5a-ae8c-428f-8c2a-29ff56bf235c)

![Screenshot 2024-07-30 200751](https://github.com/user-attachments/assets/bb0cbc2b-8121-4536-9fcc-b9d200840b24)

![Screenshot 2024-07-30 200807](https://github.com/user-attachments/assets/b0e7ea50-92ce-4784-945b-9bc3fbc1c369)

![Screenshot 2024-07-30 200837](https://github.com/user-attachments/assets/ad7d1f84-c889-43c3-b0c4-fcbb837c7b96)

![Screenshot 2024-07-30 200850](https://github.com/user-attachments/assets/207c0032-6f6d-4df9-85d5-4a69519820e7)
![Screenshot 2024-07-30 200900](https://github.com/user-attachments/assets/cf654039-3cf8-49ff-a8c1-6720697229c3)
![Screenshot 2024-07-30 200918](https://github.com/user-attachments/assets/136c6cfb-3552-47b9-baf0-1fe764e27e76)


