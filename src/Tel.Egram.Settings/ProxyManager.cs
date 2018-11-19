﻿using System;
using System.Reactive;
using System.Reactive.Linq;
using TdLib;
using Tel.Egram.Utils.TdLib;

namespace Tel.Egram.Settings
{
    public class ProxyManager : IProxyManager
    {
        private readonly IAgent _agent;

        public ProxyManager(
            IAgent agent
            )
        {
            _agent = agent;
        }
        
        public IObservable<TdApi.Proxy> GetAllProxies()
        {
            return _agent.Execute(new TdApi.GetProxies())
                .SelectMany(p => p.Proxies_ ?? new TdApi.Proxy[0]);
        }

        public IObservable<TdApi.Proxy> AddProxy(TdApi.Proxy proxy)
        {
            return _agent.Execute(new TdApi.AddProxy
                {
                    Server = proxy.Server,
                    Port = proxy.Port,
                    Type = proxy.Type
                });
        }

        public IObservable<TdApi.Proxy> UpdateProxy(TdApi.Proxy proxy)
        {
            return _agent.Execute(new TdApi.EditProxy
            {
                ProxyId = proxy.Id,
                Server = proxy.Server,
                Port = proxy.Port,
                Type = proxy.Type
            });
        }

        public IObservable<TdApi.Ok> RemoveProxy(TdApi.Proxy proxy)
        {
            return _agent.Execute(new TdApi.RemoveProxy
                {
                    ProxyId = proxy.Id
                });
        }

        public IObservable<TdApi.Ok> EnableProxy(TdApi.Proxy proxy)
        {
            return _agent.Execute(new TdApi.EnableProxy
                {
                    ProxyId = proxy.Id
                });
        }
        
        public IObservable<TdApi.Ok> DisableProxy()
        {
            return _agent.Execute(new TdApi.DisableProxy());
        }
    }
}