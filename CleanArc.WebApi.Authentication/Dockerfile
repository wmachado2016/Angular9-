#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CleanArc.WebApi.Autenthication/CleanArc.WebApi.Autenthication.csproj", "CleanArc.WebApi.Autenthication/"]
RUN dotnet restore "CleanArc.WebApi.Autenthication/CleanArc.WebApi.Autenthication.csproj"
COPY . .
WORKDIR "/src/CleanArc.WebApi.Autenthication"
RUN dotnet build "CleanArc.WebApi.Autenthication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArc.WebApi.Autenthication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArc.WebApi.Autenthication.dll"]