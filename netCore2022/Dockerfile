#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["netCore2022/netCore2022.csproj", "netCore2022/"]
RUN dotnet restore "netCore2022/netCore2022.csproj"
COPY . .
WORKDIR "/src/netCore2022"
RUN dotnet build "netCore2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "netCore2022.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "netCore2022.dll"]