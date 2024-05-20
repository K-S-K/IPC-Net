# Creating the service.
# The buidl command will be looking like this:
# 
# docker build -t minimalapi:1.0 .


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS sdk
WORKDIR /app

COPY ./ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=sdk /app/out /app

# This parameter is necessary if we want to see Swagger
# because our project displays swagger in Development only
ENV ASPNETCORE_ENVIRONMENT=Development

# This parameter is necessary to configure port.
# Instead of this, we can configure port in docker run command:
# docker run -p 5237:5237 -e DOTNET_URLS=http://+:5237 minimalapi:1.0
# When we have this parameter in Dockerfile, run command can be shorter:
# docker run -p 5237:5237  minimalapi:1.0
# Read about it: https://andrewlock.net/why-isnt-my-aspnetcore-app-in-docker-working/
ENV ASPNETCORE_URLS=http://*:5237

EXPOSE 5237

ENTRYPOINT ["dotnet", "/app/Src.dll"]