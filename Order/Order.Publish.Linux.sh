
find .PublishFiles/ -type f -and ! -path '*/wwwroot/images/*' ! -name 'appsettings.*' |xargs rm -rf
dotnet build;
rm -rf /home/Order/Order.Api/bin/Debug/.PublishFiles;
dotnet publish -o /home/Order/Order.Api/bin/Debug/.PublishFiles;
rm -rf /home/Order/Order.Api/bin/Debug/.PublishFiles/WMBlog.db;
# cp -r /home/Order/Order.Api/bin/Debug/.PublishFiles ./;
awk 'BEGIN { cmd="cp -ri /home/Order/Order.Api/bin/Debug/.PublishFiles ./"; print "n" |cmd; }'
echo "Successfully!!!! ^ please see the file .PublishFiles";