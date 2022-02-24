FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

WORKDIR /src                                                                    
COPY ./src ./

RUN dotnet restore TaxCalculator.sln

WORKDIR /src/TaxCalculator.WebApi
RUN dotnet build TaxCalculator.WebApi.csproj -c Release
 
RUN dotnet publish TaxCalculator.WebApi.csproj -c Release -o /app/published

FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app/published
COPY --from=build-env /app/published .

ENTRYPOINT ["dotnet", "TaxCalculator.WebApi.dll"]
