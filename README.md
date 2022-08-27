# Azure Managed Identity Sample

This is a sample project that showcases how to use Azure managed identities.

## How to run

Before you run this project you need to have the following:

- Azure storage account -- get the table storage URI and set it to your user secrets: `dotnet user-secrets set "TableStorageUri" "[URI]" --p src/ManagedIdentity.Svc/ManagedIdentity.Svc.csproj`
- If you want to use a user-assigned managed identity, create one and give it `Table Data Contributor` permission to your storage account. Set the client ID of the managed identity to the user secrets: `dotnet user-secrets sets "IdentityClientId" "[CLIENT-ID]" -p src/ManagedIdentity.Svc/ManagedIdentity.Svc.csproj`
- If you're running locally ensure that you are logged in to Visual Studio, VS Code or Azure CLI with your azure credentials.
