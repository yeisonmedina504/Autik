FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Autik.sln", "."]
COPY ["Autik.API/Autik.API.csproj", "Autik.API/"]
COPY ["Autik.Application/Autik.Application.csproj", "Autik.Application/"]
COPY ["Autik.Domain/Autik.Domain.csproj", "Autik.Domain/"]
COPY ["Autik.Infrastructure/Autik.Infrastructure.csproj", "Autik.Infrastructure/"]
RUN dotnet restore "Autik.API/Autik.API.csproj"

COPY . .
RUN dotnet publish "Autik.API/Autik.API.csproj" --configuration Release --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Autik.API.dll"]
