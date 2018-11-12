FROM microsoft/aspnetcore-build:2.0
COPY . /cs341
WORKDIR /cs341
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

