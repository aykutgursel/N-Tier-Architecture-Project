namespace web.GurselFramework.Core.NoSql.Redis.Model
{
    public class RedisRequestTemplate
    {
        public string RedisKey { get; set; }
        public object RedisValue { get; set; }
        public int UserId { get; set; }
    }
}
