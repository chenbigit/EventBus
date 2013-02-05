﻿using EventBus.Infrastructure;
using ServiceStack.Redis;
using System.Linq;

namespace EventBus.Redis.Extension
{
	internal class RedisClientsManager : SingletonBase<RedisClientsManager>
	{
		private readonly IRedisClientsManager Pool;

		private RedisClientsManager()
		{
			//var servers = ConfigurationManager.Instance.GetList("RedisServers");
			Pool = new PooledRedisClientManager(new string[] { }, Enumerable.Empty<string>());
		}

		public IRedisClient GetClient()
		{
			return Pool.GetClient();
		}
	}
}