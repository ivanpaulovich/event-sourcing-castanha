FROM microsoft/dotnet:2.0-sdk-jessie

ENV ASPNETCORE_URLS="http://*:80"

EXPOSE 80
WORKDIR /app
COPY . .

WORKDIR /app/Castanha.UI

ENTRYPOINT ["dotnet", "run"]