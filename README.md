# Real-Time Chat Application

## Overview
This is a real-time chat application developed using ASP.NET Core and SignalR. The application allows users to engage in one-on-one and group chats in real-time.

## Features
- User registration and authentication
- One-on-one and group chat functionalities
- Real-time messaging using SignalR
- Persistent storage of messages and chat histories
- Secure authentication and authorization mechanisms
- Scalable architecture to handle concurrent users and messages

## Repository Contents
This repository contains the source code for the chat application backend developed in ASP.NET Core.

## Setup and Usage
### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional)

### Installation
1. Clone this repository to your local machine.
2. Open the project in Visual Studio or Visual Studio Code.

### Running the Application
1. Build the solution in Visual Studio or run `dotnet build` command in the project directory.
2. Set up the database using Entity Framework migrations:
```
dotnet ef database update
```
3. Run the application:
```
dotnet run
```
4. Access the application in your web browser at `https://localhost:5001`.

### Usage
1. Register or login to the application using your credentials.
2. Start a new one-on-one chat by entering the recipient's ID and typing your message.
3. Create or join a group chat by specifying the group name and sending messages to the group.
4. View your message history and manage your chat groups easily.

## Architecture Discussion
The chat application follows a client-server architecture, with the backend implemented in ASP.NET Core and SignalR. Here's a brief overview of key considerations:
- Real-time Communication: SignalR is used to enable real-time messaging between users, ensuring seamless and instantaneous message delivery.
- Data Management: Entity Framework Core is used for data persistence, storing messages and chat histories in a SQL Server database.
- Security: The application implements secure authentication and authorization mechanisms using ASP.NET Core Identity, protecting user data and ensuring access control.
- Scalability: The backend is designed to efficiently handle a significant number of concurrent users and messages, ensuring optimal performance even under heavy load.

For a more detailed discussion of the architecture and its components, please refer to the [Architecture.md](Architecture.md) file in the repository.

## Contributors
- [Sachin Sharma](https://github.com/Sachin-Sharma-0)
