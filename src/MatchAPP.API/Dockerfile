FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.18-buster-slim
WORKDIR /app
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Production"

# Publish outside of docker build and copy the files
COPY bin/Release/netcoreapp3.1/debian.8-x64/publish /app

# Apply Migration to Database
COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x ./wait-for-it.sh
CMD /bin/bash ./wait-for-it.sh

EXPOSE 5000
ENTRYPOINT ["dotnet", "MatchAPP.API.dll"]