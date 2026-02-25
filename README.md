# Selenium Sample Project

This is a **Selenium C# sample project** demonstrating automated UI testing for [SauceDemo](https://www.saucedemo.com).  
The project follows the **Page Object Model (POM)** and **NUnit** for test management.

---

## Project Structure
selenium-sample-work/
│
├── Base/ # Base classes like BaseTest.cs
├── Pages/ # Page Objects (LoginPage.cs, InventoryPage.cs)
├── Tests/ # Test cases (LoginTests.cs, InventoryTests.cs)
├── Utilities/ # Helper classes (e.g., random selection, calculation)
├── selenium-sample-work.sln
├── selenium-sample-work.csproj
└── README.md

---

## Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download)
- [Chrome Browser](https://www.google.com/chrome/)
- [ChromeDriver](https://chromedriver.chromium.org/) (matches your Chrome version)
- VSCode or Visual Studio (for editing and debugging)

---

## Setup Instructions

1. Clone the repository:

    ```bash
    git clone git@github.com:hanishanis88/selenium-sample-work.git
    cd selenium-sample-work
    ```

2. Restore NuGet packages:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

---

## Running Tests

```bash
dotnet test

