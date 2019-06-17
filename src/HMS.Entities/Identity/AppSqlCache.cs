using System;

namespace HMS.Entities.Identity
{
    /// <summary>
    /// For Microsoft.Extensions.Caching.SqlServer
    /// More info: http://www.YaZahra.YaAli/post/2577
    /// and http://www.YaZahra.YaAli/post/2578
    /// plus http://www.YaZahra.YaAli/post/2581
    /// </summary>
    public class AppSqlCache
    {
        public string Id { get; set; }
        public byte[] Value { get; set; }
        public DateTimeOffset ExpiresAtTime { get; set; }
        public long? SlidingExpirationInSeconds { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
    }
}