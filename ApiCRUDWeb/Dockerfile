FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish ApiCRUDWeb/ApiCRUDWeb.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/ApiCRUDWeb/out .

ENTRYPOINT ["dotnet", "ApiCRUDWeb.dll"]