FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV DATABASE_HOST "localhost"
ENV DATABASE_USER "privnote"
ENV DATABASE_NAME "privnote"
ENV DATABASE_PASSWORD "password"
ENV DATABASE_PORT "5432"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Privnote/Privnote.csproj", "Privnote/"]
RUN dotnet restore "Privnote/Privnote.csproj"
COPY . .
WORKDIR "/src/Privnote"
RUN dotnet build "Privnote.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Privnote.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Privnote.dll"]
