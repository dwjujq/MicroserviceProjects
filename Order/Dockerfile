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
COPY ["Order.Api/Order.Api.csproj", "Order.Api/"]
COPY ["Order.Extensions/Order.Extensions.csproj", "Order.Extensions/"]
COPY ["Order.EventBus/Order.EventBus.csproj", "Order.EventBus/"]
COPY ["Order.Common/Order.Common.csproj", "Order.Common/"]
COPY ["Order.Model/Order.Model.csproj", "Order.Model/"]
COPY ["Order.Serilog.Es/Order.Serilog.Es.csproj", "Order.Serilog.Es/"]
COPY ["Ocelot.Provider.Nacos/Ocelot.Provider.Nacos.csproj", "Ocelot.Provider.Nacos/"]
COPY ["Order.Services/Order.Services.csproj", "Order.Services/"]
COPY ["Order.IServices/Order.IServices.csproj", "Order.IServices/"]
COPY ["Order.Repository/Order.Repository.csproj", "Order.Repository/"]
COPY ["Order.Tasks/Order.Tasks.csproj", "Order.Tasks/"]
COPY ["build", "build/"]

# 恢复依赖项
RUN dotnet restore "Order.Api/Order.Api.csproj"

# 复制其余的源代码
COPY . .

# 构建项目
WORKDIR "/src/Order.Api"
RUN dotnet build "Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 9291 
ENTRYPOINT ["dotnet", "Order.Api.dll"]
