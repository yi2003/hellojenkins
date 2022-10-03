#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8083

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["hellojenkins/hellojenkins.csproj", "hellojenkins/"]
RUN dotnet restore "hellojenkins/hellojenkins.csproj"
COPY . .
WORKDIR "/src/hellojenkins"
RUN dotnet build "hellojenkins.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hellojenkins.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hellojenkins.dll"]