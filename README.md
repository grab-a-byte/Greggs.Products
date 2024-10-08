# Please Read next 3
## Changes made
- Using dependency injection for Product Access and Currency Conversion
- Updated project to dotnet 8 (Latest LTS at time of completion)
- Updated language version to 12 (shipped with dotnet 8.0)
- Enabled nullable reference types for better null handling
- Updated all nuget packages
- Added main project as dependency of Unit Test Project
- Added a DTO (Data Transfer Object) to seperate API response form database
- Added tests for controllers and Services
- Added 'sealed' to all classes for improved performance
- Removed dead code
- Changed mock datastore to use a backing array for efficiency.
- Pricing updated in line with [greggsmenu.co.uk](https://greggsmenu.co.uk) as of time of completing

## Considerations
- Parameter added to controller for currency to allow further additions to be added without needing new endpoints and allowing a single path for all price calculations.
- Logger in controller uses printf style messages instead of string interpolation as some logging frameworks allow filtering and searching in this way that string interpolation does not (e.g. Azure App Insights).
- Conversions done in a seperate service so updates can be made independantly for how conversion rates are calculated.
- Added a bruno collection for local API calling which can be found at [usebruno.com](https://www.usebruno.com/)

## Other issues
Making the repo public and asking candidates to fork allows all forks to be public allowing candidates to copy off each other if they chose. I did not do this however it could be an issue amongst other candidates.

# Greggs.Products
## Introduction
Hello and welcome to the Greggs Products repository, thanks for finding it!

## The Solution
So at the moment the api is currently returning a random selection from a fixed set of Greggs products directly
from the controller itself. We currently have a data access class and it's interface but
it's not plugged in (please ignore the class itself, we're pretending it hits a database),
we're also going to pretend that the data access functionality is fully tested so we don't need
to worry about testing those lines of functionality.

We're mainly looking for the way you work, your code structure and how you would approach tackling the following
scenarios.

## User Stories
Our product owners have asked us to implement the following stories, we'd like you to have
a go at implementing them. You can use whatever patterns you're used to using or even better
whatever patterns you would like to use to achieve the goal. Anyhow, back to the
user stories:

### User Story 1
**As a** Greggs Fanatic<br/>
**I want to** be able to get the latest menu of products rather than the random static products it returns now<br/>
**So that** I get the most recently available products.

**Acceptance Criteria**<br/>
**Given** a previously implemented data access layer<br/>
**When** I hit a specified endpoint to get a list of products<br/>
**Then** a list or products is returned that uses the data access implementation rather than the static list it current utilises

### User Story 2
**As a** Greggs Entrepreneur<br/>
**I want to** get the price of the products returned to me in Euros<br/>
**So that** I can set up a shop in Europe as part of our expansion

**Acceptance Criteria**<br/>
**Given** an exchange rate of 1GBP to 1.11EUR<br/>
**When** I hit a specified endpoint to get a list of products<br/>
**Then** I will get the products and their price(s) returned

