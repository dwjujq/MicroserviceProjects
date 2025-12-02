color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd Inventory.Api

dotnet publish -o ..\Inventory.Api\bin\Debug\net7.0\

md ..\.PublishFiles

xcopy ..\Inventory.Api\bin\Debug\net7.0\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd