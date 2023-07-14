FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-final
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "net7_demo_api.dll" ]

# docker run -p 8081:80 -e ASPNETCORE_URLS=http://+:80 net7-demo-api