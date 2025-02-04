# hng12-stage-1

## Overview
This is a simple **Number Classification API** that takes a number as input and returns interesting mathematical properties about it, including:
- Whether the number is **prime**.
- Whether the number is **perfect**.
- Special classifications such as **Armstrong number**, **even/odd**, etc.
- The **sum of its digits**.
- A **fun fact** about the number, fetched from an external API.

## Tech Stack
- **Framework:** .NET 8 
- **Hosting Platform:** Render
- **Version Control:** Git & GitHub

## API Documentation
### **Endpoint:**
```
GET <your-render-api-url>/api/classify-number?number=<integer>
```

### **Response Format (200 OK):**
```json
{
    "number": 371,
    "is_prime": false,
    "is_perfect": false,
    "properties": ["armstrong", "odd"],
    "digit_sum": 11,
    "fun_fact": "371 is an Armstrong number because 3^3 + 7^3 + 1^3 = 371"
}
```

### **Error Response Format (400 Bad Request):**
```json
{
    "number": "alphabet",
    "error": true
}
```

## Setup Instructions
### **Prerequisites**
- .NET 8 SDK installed
- Git installed

### **Clone the Repository**
```sh
git clone https://github.com/adebisi4145/hng12-stage-1.git
cd hng12-stage-1
```

### **Run Locally**
```sh
dotnet run
```

## Deployment
This API is deployed on **Render** and is accessible publicly at:
```
https://render
```

## References
- [Numbers API](http://numbersapi.com/#42)
- [Parity in Mathematics](https://en.wikipedia.org/wiki/Parity_(mathematics))
- Learn more about C# developers: [HNG C# Developers](https://hng.tech/hire/csharp-developers)
