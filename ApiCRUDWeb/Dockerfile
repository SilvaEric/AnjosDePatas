FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish ApiCRUDWeb -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/ApiCRUDWeb/out .

ENTRYPOINT ["dotnet", "ApiCRUDWeb.dll"]