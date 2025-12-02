color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd Order.Api

dotnet publish -o ..\Order.Api\bin\Debug\net7.0\

md ..\.PublishFiles

xcopy ..\Order.Api\bin\Debug\net7.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd