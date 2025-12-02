using Inventory.Common.Helper;
using StackExchange.Redis;

namespace JCZY.CAP.Message
{
    public class RedisMessageTracker : IMessageTracker
    {
        #region 属性和字段
        private const string KEY_PREFIX = "msgtracker:"; // 默认Key前缀
        private const int DEFAULT_CACHE_TIME = 60 * 60 * 24 * 3; // 默认缓存时间为3天，单位为秒

        private readonly IDatabase _redisDatabase;
        #endregion

        //依赖StackExchange.Redis;
        public RedisMessageTracker(ConnectionMultiplexer multiplexer)
        {
            _redisDatabase = multiplexer.GetDatabase();
        }

        public bool HasProcessed(string msgId)
        {
            return _redisDatabase.KeyExists(KEY_PREFIX + msgId);
        }

        public async Task<bool> HasProcessedAsync(string msgId)
        {
            return await _redisDatabase.KeyExistsAsync(KEY_PREFIX + msgId);
        }

        public void MarkAsProcessed(string msgId)
        {
            var msgRecord = new MessageTrackLog(msgId);
            _redisDatabase.StringSet($"{KEY_PREFIX}{msgId}", JsonHelper.ObjToJson(msgRecord), TimeSpan.FromMinutes(DEFAULT_CACHE_TIME));
        }

        public async Task MarkAsProcessedAsync(string msgId)
        {
            var msgRecord = new MessageTrackLog(msgId);
            await _redisDatabase.StringSetAsync($"{KEY_PREFIX}{msgId}", JsonHelper.ObjToJson(msgRecord), TimeSpan.FromMinutes(DEFAULT_CACHE_TIME));
        }
    }
}