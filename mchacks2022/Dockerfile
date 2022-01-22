#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["mchacks2022/McHacks2022.csproj", "mchacks2022/"]
RUN dotnet restore "mchacks2022/McHacks2022.csproj"
COPY . .
WORKDIR "/src/mchacks2022"
RUN dotnet build "McHacks2022.csproj" -c Release -o /app/build

FROM build AS publish
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash - && apt-get install -yq nodejs
RUN dotnet publish "McHacks2022.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash - && apt-get install -yq nodejs
ENTRYPOINT ["dotnet", "McHacks2022.dll"]