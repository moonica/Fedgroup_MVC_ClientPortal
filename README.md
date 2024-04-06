# Fedgroup_MVC_ClientPortal
Take-home Technical Assessment for Fedgroup by Jonica Brown

# How to use this app
- Suggested: run in Visual Studio. Open the solution in Visual Studio on a computer with .NET 8.0 or later. Click on the green "run" button in the menu ribbon (select "http" or "IIS Express" if one is not already selected)
- Installing the app: if the app can not be run in Visual Studio, follow the below guide to install it on the machine as a website and access it through Internet Information Services (IIS), but please note the following
 - The linked Microsoft documentation refers to .NET 3.5, you can ignore that as it's an older piece of documentation
 - You can ignore step 2 and onwards, step 1 should be sufficient
 - You can install .NET 8.0 if needed from Microsoft: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
 - https://learn.microsoft.com/en-us/iis/application-frameworks/scenario-build-an-aspnet-website-on-iis/configuring-step-1-install-iis-and-asp-net-modules

# Assumptions
- Installation instructions assume a Windows environment, please refer to Microsoft documentation to run it in Linux or MacOS
- A small, mocked up array of clients and investments were created as in memory objects; a repository pattern was used so this could easily be replaced by a database or other data store
- Basic styling was implemented using Bootstrap, there's a lot of room for improvement. The Bootstrap javascript files were not being picked up by Bootstrap elements (eg. Modals), this would have to be investigated in a production environment rather than the few quick workarounds implemented in the interest of time
- Similar to Bootstrap as above, model binding did not work as expected in all views, notably the forecast end date was mocked in the interest of time. This would need solving outside a theoretical scenario
- All backend functions were implemented as syncronous; with a larger data volume, async would be recommended where appropriate
- Unit tests were not implemented but are recommended 
- The current scope of client details is small enough that a separate details view was not implemented on selecting a client. A new view or modal display would be an obvious extension to this version
- No upper limit was placed on the forecasting end date, and it was assumed forecast end dates could not be in the past or before the investment start date
- If there were any third parties or other systems who would consume the data, I would split the web and API parts of this implementation more fully

# TO DO
- Various minor notes, assumptions and potential improvements were noted in the code as comments starting with "TODO"
- A Logger mechanism should be injected in each controller and more thorough logging included 
- try-catch blocks should be implemented around controller methods to exit gracefully in unforseen circumstances
- More detailed error handling and messaging would be ideal
- Authentication and authorisation would be an obvious and critical addition in a real-world scenario

# License
- This software is licensed under an MIT license to Jonica Brown, please see the "LICENSE" document included