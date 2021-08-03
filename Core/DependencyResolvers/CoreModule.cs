using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollction)
        {
            serviceCollction.AddMemoryCache();
            serviceCollction.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollction.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollction.AddSingleton<Stopwatch>();

        }
    }
}
