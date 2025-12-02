#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#这种模式是直接在构建镜像的内部编译发布dotnet项目。
#注意下容器内输出端口是9291
#如果你想先手动dotnet build成可执行的二进制文件，然后再构建镜像，请看.Api层下的dockerfile。


#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 复制 Directory.Build.props 文件
COPY ["Directory.Build.props", "."]

# 复制所有项目文件
COPY ["Inventory.Api/Inventory.Api.csproj", "Inventory.Api/"]
COPY ["Inventory.Extensions/Inventory.Extensions.csproj", "Inventory.Extensions/"]
COPY ["Inventory.EventBus/Inventory.EventBus.csproj", "Inventory.EventBus/"]
COPY ["Inventory.Common/Inventory.Common.csproj", "Inventory.Common/"]
COPY ["Inventory.Model/Inventory.Model.csproj", "Inventory.Model/"]
COPY ["Inventory.Serilog.Es/Inventory.Serilog.Es.csproj", "Inventory.Serilog.Es/"]
COPY ["Ocelot.Provider.Nacos/Ocelot.Provider.Nacos.csproj", "Ocelot.Provider.Nacos/"]
COPY ["Inventory.Services/Inventory.Services.csproj", "Inventory.Services/"]
COPY ["Inventory.IServices/Inventory.IServices.csproj", "Inventory.IServices/"]
COPY ["Inventory.Repository/Inventory.Repository.csproj", "Inventory.Repository/"]
COPY ["Inventory.Tasks/Inventory.Tasks.csproj", "Inventory.Tasks/"]
COPY ["build", "build/"]

# 恢复依赖项
RUN dotnet restore "Inventory.Api/Inventory.Api.csproj"

# 复制其余的源代码
COPY . .

# 构建项目
WORKDIR "/src/Inventory.Api"
RUN dotnet build "Inventory.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 9291 
ENTRYPOINT ["dotnet", "Inventory.Api.dll"]
