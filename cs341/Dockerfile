FROM microsoft/aspnetcore-build:2.0
COPY . /CS341-Shopping-Cart
WORKDIR /CS341-Shopping-Cart
RUN ["dotnet", "restore", "cs341.sln"]
RUN ["dotnet", "build", "cs341.sln"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

