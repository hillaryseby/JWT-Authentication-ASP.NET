# JWT Authentication in ASP.NET

This project provides a simple sample implementation of JSON Web Token (JWT) authentication in an ASP.NET Core application. No databases are used in this project. JWTs are used to securely transmit information between parties and are commonly used for authentication and authorization in web applications.

## What is JSON Web Token (JWT)?

JSON Web Token (JWT) is an open standard (RFC 7519) that defines a compact and self-contained way for securely transmitting information between parties as a JSON object. This information can be verified and trusted because it is digitally signed. JWTs can be signed using a secret (with HMAC algorithm) or a public/private key pair using RSA or ECDSA.

### Components of JWT

- **Header**: Contains metadata about the type of token and the signing algorithm used.
- **Payload**: Contains the claims, which are statements about an entity (typically, the user) and additional data.
- **Signature**: Used to verify the integrity of the token and to ensure that it has not been tampered with.

## Setup and Implementation

### Prerequisites

Ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download)
- Basic understanding of ASP.NET Core

### Features

- User registration and login endpoints (`UserRegister` and `UserLogin`).
- Password hashing using BCrypt for secure storage.
- Token generation upon successful authentication.

### How it Works

1. **User Registration**: When a user registers, their password is securely hashed using BCrypt.

2. **User Login**: Upon login, the provided username and password are verified. If valid, a JWT token is generated and returned to the client.

3. **Token Generation**: JWT token is created with the user's claims (e.g., username) and signed using a secret key.

### Configuration

Add the necessary NuGet packages and the JWT secret key to the `appsettings.json` file:
```json
{
  "Jwt": {
    "SecretKey": "your-secret-key-here"
  }
}
```
### Necessary NuGet Packages

- **Microsoft.AspNetCore.Mvc.NewtonsoftJson**: For JSON serialization and deserialization.
- **Microsoft.IdentityModel.Tokens**: For handling JWT tokens.
- **BCrypt.Net-Next**: For password hashing.

### Project Structure

- **AuthController.cs**: Contains API endpoints for user registration and login.
- **Models**: Contains the User model and DTOs (Data Transfer Objects) for user registration and login.
- **Utils**: Contains utility classes for password hashing and token generation.
- **appsettings.json**: Configuration file for JWT secret key.

### Usage

1. **User Registration**: Send a POST request to `/api/Auth/UserRegister` with the user's details (username and password).
2. **User Login**: Send a POST request to `/api/Auth/UserLogin` with the user's credentials. Upon successful authentication, a JWT token will be returned.
3. **Protected Endpoints**: Include the JWT token in the Authorization header of subsequent requests to access protected endpoints.
