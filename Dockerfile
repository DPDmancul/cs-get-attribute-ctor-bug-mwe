FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app
COPY . .

RUN scripts/build.sh
WORKDIR src/TestApp
CMD dotnet run -c Release