using Inventory.Common;
using Inventory.Common.DB;
using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Inventory;

namespace Blog.Core.Extensions.ServiceExtensions;

public static class CapSetup
{
    /// <summary>
    /// 统一注册CAP
    /// </summary>
    /// <param name="services"></param>
    public static void AddCapSetup(this IServiceCollection services, Action<CapOptions> configure = null)
    {
        var logger = ServiceProviderServiceExtensions.GetRequiredService<ILogger<CapOptions>>(services.BuildServiceProvider());

        var rabbitMQEnabled = AppSettings.app(new string[] { "RabbitMQ", "Enabled" }).ObjToBool();
        if (!rabbitMQEnabled)
        {
            throw new Exception("rabbitmq not Enabled.");
        }

        services.AddCap(x =>
        {
            //使用RabbitMQ传输
            x.UseRabbitMQ(opt => {
                opt.HostName = AppSettings.app(new string[] { "RabbitMQ", "Connection" });
                opt.Port= AppSettings.app(new string[] { "RabbitMQ", "Port" }).ObjToInt();
                opt.UserName= AppSettings.app(new string[] { "RabbitMQ", "UserName" });
                opt.Password= AppSettings.app(new string[] { "RabbitMQ", "Password" });
                opt.VirtualHost= AppSettings.app(new string[] { "RabbitMQ", "VirtualHost" });
            });

            ////使用MySQL持久化
            x.UseMySql(BaseDBConfig.MainConfig.ConnectionString);

            x.UseDashboard();

            //成功消息的过期时间（秒）
            x.SucceedMessageExpiredAfter = 3 * 24 * 3600;

            x.FailedRetryCount = 3;

            x.FailedRetryInterval = 10;

            //失败回调，通过企业微信，短信通知人工干预
            x.FailedThresholdCallback = (e) =>
            {
                if (e.MessageType == MessageType.Publish)
                {
                }
                else if (e.MessageType == MessageType.Subscribe)
                {
                }
            };

            configure?.Invoke(x);
        });
    }
}