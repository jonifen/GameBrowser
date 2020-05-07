FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as builder

WORKDIR /app

COPY ./ ./

WORKDIR /app/GameBrowser.Api
RUN dotnet build -c Release
RUN dotnet publish -o ../out --no-build

##### above step is failing, but unsure why! Docker output is below...
##### ----------------------------------------------------------------
# Step 5/9 : RUN dotnet publish -c Release -o ../out
#  ---> Running in f5af7377b9e6
# Microsoft (R) Build Engine version 16.5.0+d4cbfca49 for .NET Core
# Copyright (C) Microsoft Corporation. All rights reserved.

#   Restore completed in 4.33 sec for /app/GameBrowser/GameBrowser.csproj.
#   Restore completed in 1.39 min for /app/GameBrowser.Api/GameBrowser.Api.csproj.
# Managers/IQ3AManager.cs(1,26): error CS0234: The type or namespace name 'Q3A' does not exist in the namespace 'GameBrows
# er.Models' (are you missing an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Managers/Q3AManager.cs(4,26): error CS0234: The type or namespace name 'Q3A' does not exist in the namespace 'GameBrowse
# r.Models' (are you missing an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/IQ3AServerResponseMapper.cs(1,26): error CS0234: The type or namespace name 'Q3A' does not exist in the namespac
# e 'GameBrowser.Models' (are you missing an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/Q3AServerResponseMapper.cs(1,26): error CS0234: The type or namespace name 'Q3A' does not exist in the namespace
#  'GameBrowser.Models' (are you missing an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Managers/IQ3AManager.cs(7,9): error CS0246: The type or namespace name 'ServerDetails' could not be found (are you missi
# ng a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/IQ3AServerResponseMapper.cs(7,9): error CS0246: The type or namespace name 'ServerDetails' could not be found (a
# re you missing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Managers/Q3AManager.cs(22,16): error CS0246: The type or namespace name 'ServerDetails' could not be found (are you miss
# ing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Managers/Q3AManager.cs(44,17): error CS0246: The type or namespace name 'ServerDetails' could not be found (are you miss
# ing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/Q3AServerResponseMapper.cs(19,16): error CS0246: The type or namespace name 'ServerDetails' could not be found (
# are you missing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/Q3AServerResponseMapper.cs(28,17): error CS0246: The type or namespace name 'ServerDetails' could not be found (
# are you missing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# Mappers/Q3AServerResponseMapper.cs(54,23): error CS0246: The type or namespace name 'Player' could not be found (are you
#  missing a using directive or an assembly reference?) [/app/GameBrowser/GameBrowser.csproj]
# The command '/bin/sh -c dotnet publish -c Release -o ../out' returned a non-zero code: 1

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=builder /app/out .
ENTRYPOINT [ "dotnet", "GameBrowser.Api.dll" ]