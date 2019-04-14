FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FluentValidation.Tests/FluentValidation.Tests.csproj", "FluentValidation.Tests/"]
COPY ["FluentValidation.Person/FluentValidation.Person.csproj", "FluentValidation.Person/"]
RUN dotnet restore "FluentValidation.Tests/FluentValidation.Tests.csproj"
COPY . .
WORKDIR "/src/FluentValidation.Tests"
RUN dotnet build "FluentValidation.Tests.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FluentValidation.Tests.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FluentValidation.Tests.dll"]