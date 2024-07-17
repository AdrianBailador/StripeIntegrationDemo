# Stripe Integration Demo

This repository contains a demo project showing how to integrate Stripe into a .NET application using Visual Studio Code. The project demonstrates setting up Stripe Checkout, configuring API keys, creating a payment controller, and handling payment responses.

## Prerequisites

- **Visual Studio Code** installed.
- **.NET SDK** installed (preferably the latest version).
- A **Stripe account**. Sign up at [Stripe](https://stripe.com) and obtain your API keys.

## Setup

### 1. Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/AdrianBailador/StripeIntegrationDemo.git
cd StripeIntegrationDemo
```

### 2. Install the Stripe Package

Install the Stripe.Net package:

```bash
dotnet add package Stripe.net
```

### 3. Configure Stripe API Keys

Open `appsettings.json` and add your Stripe configuration:

```json
{
  "Stripe": {
    "SecretKey": "your_secret_key_here",
    "PublishableKey": "your_publishable_key_here"
  }
}
```

### 4. Run the Application

Execute the application:

```bash
dotnet run
```

Navigate to `https://localhost:5001` in your browser. You should see the home page with a button to access the payment page.

## Features

- **Stripe Checkout Integration**: Secure payment gateway with Stripe.
- **Error Handling**: Basic error handling for Stripe exceptions.
- **Responsive UI**: Clean and user-friendly views using Bootstrap.

## Useful Links

- [Stripe Documentation](https://stripe.com/docs)
- [Guide on Stripe Integration](https://github.com/AdrianBailador/StripeIntegrationDemo)

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any improvements or bug fixes.
