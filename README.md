## Overview

This is a small demo project to log error messages to Application Insights. It demonstrates the different ways to log messages via the logger and the result. 

See my Blog post [ASP.NET Core Logger messages matter](https://chadpeters.dev/blog/aspnetcore-logger-messages) for more information. 

## Setup

- Created a Log Analytics workspace in Azure
- Created an Application Insights instance in Azure and connected it to the Log Analytics workspace
- Ran `dotnet new webapp --output appinsightslogging --no-https`
- In Visual Studio, add Application Insights Telemetry via Project > Add Application Insight Telemetry
- Added endpoint to Program.cs
