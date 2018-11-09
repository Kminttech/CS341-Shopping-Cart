FROM microsoft/aspnetcore-build:lts
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore", "cs341.sln"]
RUN ["dotnet", "build", "cs341.sln"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

