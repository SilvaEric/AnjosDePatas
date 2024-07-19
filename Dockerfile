#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore ApiCRUDWeb/ApiCRUDWeb.csproj
RUN dotnet publish ApiCRUDWeb/ApiCRUDWeb.csproj -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /runtime-app
COPY --from=build-env /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ApiCRUDWeb.dll"]