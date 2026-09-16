FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["DeliveryOrderApp.csproj", "./"]
RUN dotnet restore "./DeliveryOrderApp.csproj"
COPY . .
RUN dotnet build "DeliveryOrderApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliveryOrderApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir -p /app/Data

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "DeliveryOrderApp.dll"]