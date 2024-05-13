
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT="Development"
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["1-Edu.Services/Edu.Services.csproj", "1-Edu.Services/"]
RUN dotnet restore "1-Edu.Services/Edu.Services.csproj"

WORKDIR "/src/1-Edu.Services"
COPY . .
RUN dotnet build "Edu.Services.csproj" -c Release -o /app/build

# Run the postbuild.sh script
COPY ["postbuild.sh","/app/postbuild.sh"]
RUN chmod +x "/app/postbuild.sh"
RUN /app/postbuild.sh
FROM build AS publish
RUN dotnet publish "Edu.Services.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edu.Services.dll"]


