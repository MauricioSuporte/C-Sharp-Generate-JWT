# **JWT Generator**

This repository contains an implementation of a **JSON Web Token (JWT)** generator with fixed claims using the **HMAC-SHA256** signing algorithm. The project includes a method called `GenerateJwtWithFixedClaims`, which simplifies the creation of JWTs with customizable information and secure signing.

---

## **Description**

The project's goals are to:
- Demonstrate how to create a JWT in **C#** with fixed claims.
- Generate tokens without relying on external libraries, focusing on understanding the process.
- Sign tokens using a secure algorithm (HMAC-SHA256) with a secret key.

---

## **Features**

- **Automatically generated claims:**
  - `sub` (Subject): Represents the subject/owner of the token.
  - `jti` (JWT ID): A unique identifier for the token.
  - `iat` (Issued At): The Unix timestamp indicating when the token was issued.
  - `iss` (Issuer): Identifies the token's issuer.
  - `aud` (Audience): Identifies the token's intended recipient.

- **No Expiration (`exp`):**
  - The generated token does not have a validity limit, but this can be customized if needed.

- **Easy customization:**
  - Allows setting essential information such as issuer, audience, subject, and the secret key for signing.

---

## **Usage Example**

### **Method Signature**
```csharp
string GenerateJwtWithFixedClaims(
    string secret, 
    string issuer, 
    string audience, 
    string sub, 
    string jti, 
    long iat
);
```
---
## **How It Works**

1. The method receives the necessary parameters to construct the JWT payload, including `issuer`, `audience`, `sub`, `jti`, and `iat`.
2. Converts the **header** and **payload** to Base64Url format.
3. Computes the token signature using **HMAC-SHA256** with the secret key.
4. Concatenates the `header`, `payload`, and `signature` in the format `<header>.<payload>.<signature>` to produce the final JWT.

---

## **Dependencies**

- This project uses only the .NET standard library, with no external dependencies.

---

## **How to Run**

1. Clone the repository:
   ```bash
   git clone https://github.com/MauricioSuporte/C-Sharp-Generate-JWT.git
   cd jwt-generator
   ```
---
## **Testing**

Make sure to implement and validate tests to ensure the correct functionality of the JWT Generator.  
An example test could include comparing generated tokens with expected values.

---

## **Customization**

If you need additional claims, such as `exp` (expiration) or `nbf` (not before):

1. Modify the payload directly in the `GenerateJwtWithFixedClaims` method.
2. Add the logic to calculate these claims as needed.

---

## **Contributing**

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a branch for your feature or bug fix:
   ```bash
   git checkout -b my-feature
   ```
3. Submit a pull request for review.
---
## **License**

This project is licensed under the **MIT License**.

---

If you need help or have questions, feel free to open an **issue** in the repository. 😊


