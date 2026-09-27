FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["src/DeliveryOrderApp/DeliveryOrderApp.csproj", "DeliveryOrderApp/"]
RUN dotnet restore "DeliveryOrderApp/DeliveryOrderApp.csproj"

COPY src/ src/
RUN dotnet build "src/DeliveryOrderApp/DeliveryOrderApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/DeliveryOrderApp/DeliveryOrderApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "DeliveryOrderApp.dll"]