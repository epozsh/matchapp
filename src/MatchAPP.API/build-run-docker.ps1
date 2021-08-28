# powershell -executionpolicy bypass -File build-run-docker.ps1

# build and publish as Debian runtime
& dotnet clean -f netcoreapp3.1 -r debian.8-x64 -c Release
& dotnet publish -f netcoreapp3.1 -r debian.8-x64 -c Release

# build and run
& docker-compose up