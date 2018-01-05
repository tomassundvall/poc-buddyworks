FROM microsoft/aspnetcore-build:2.0.3 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish src/app/api/api.csproj -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:2.0.3
WORKDIR /app
COPY --from=build-env /app/src/app/api/out .
COPY ./version.json .
ENTRYPOINT ["dotnet", "api.dll"]