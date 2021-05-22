dotnet clean  src\SProfTIAPI
dotnet restore src\SProfTIAPI
dotnet build src\SProfTIAPI
cd src\SProfTIAPI
dotnet publish -c Release -o out 
