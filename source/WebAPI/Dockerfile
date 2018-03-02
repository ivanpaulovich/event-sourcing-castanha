FROM microsoft/aspnetcore:2.0.0-jessie

ENV ASPNETCORE_URLS="http://*:80"

EXPOSE 80
WORKDIR /app
COPY . .

WORKDIR /app/Castanha.UI

ENTRYPOINT ["dotnet", "run"]