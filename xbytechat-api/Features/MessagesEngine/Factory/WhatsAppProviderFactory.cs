using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using xbytechat.api;
using xbytechat.api.Features.MessagesEngine.Abstractions;
using xbytechat.api.Features.MessagesEngine.Providers;

namespace xbytechat.api.Features.MessagesEngine.Factory
{
    public class WhatsAppProviderFactory : IWhatsAppProviderFactory
    {
        private readonly IServiceProvider _sp;
        private readonly AppDbContext _db;
        private readonly ILogger<WhatsAppProviderFactory> _logger;

        public WhatsAppProviderFactory(IServiceProvider sp, AppDbContext db, ILogger<WhatsAppProviderFactory> logger)
        {
            _sp = sp;
            _db = db;
            _logger = logger;
        }

        public async Task<IWhatsAppProvider> CreateAsync(Guid businessId)
        {
            var setting = await _db.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive)
                ?? throw new InvalidOperationException("WhatsApp settings not found for this business.");

            var providerKey = (setting.Provider ?? "meta_cloud").Trim().ToLowerInvariant();

            using var scope = _sp.CreateScope();

            var httpClientFactory = scope.ServiceProvider.GetService<IHttpClientFactory>();
            var http =
                httpClientFactory != null
                    ? httpClientFactory.CreateClient(providerKey == "meta_cloud" ? "wa:meta_cloud" : "wa:pinnacle")
                    : scope.ServiceProvider.GetRequiredService<HttpClient>();

            return providerKey switch
            {
                //"pinnacle" =>
                //            new PinnacleProvider(http, scope.ServiceProvider.GetRequiredService<ILogger<PinnacleProvider>>(), setting),
                "pinnacle" => new PinnacleProvider(http, scope.ServiceProvider.GetRequiredService<ILogger<PinnacleProvider>>(), setting),
                "meta_cloud" =>
                    new MetaCloudProvider(_db, http, scope.ServiceProvider.GetRequiredService<ILogger<MetaCloudProvider>>(), setting),

                _ => throw new NotSupportedException($"Unsupported WhatsApp provider: {providerKey}")
            };
        }
    }
}


//// 📄 File: Features/MessagesEngine/Factory/WhatsAppProviderFactory.cs
//using System;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using xbytechat.api;
//using xbytechat.api.Features.MessagesEngine.Abstractions;
//using xbytechat.api.Features.MessagesEngine.Providers;

//namespace xbytechat.api.Features.MessagesEngine.Factory
//{

//    public class WhatsAppProviderFactory : IWhatsAppProviderFactory
//    {
//        private readonly IServiceProvider _sp;
//        private readonly AppDbContext _db;
//        private readonly ILogger<WhatsAppProviderFactory> _logger;

//        public WhatsAppProviderFactory(IServiceProvider sp, AppDbContext db, ILogger<WhatsAppProviderFactory> logger)
//        {
//            _sp = sp;
//            _db = db;
//            _logger = logger;
//        }

//        public async Task<IWhatsAppProvider> CreateAsync(Guid businessId)
//        {
//            var setting = await _db.WhatsAppSettings.FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive)
//                          ?? throw new InvalidOperationException("WhatsApp settings not found for this business.");

//            var providerKey = (setting.Provider ?? "meta_cloud").Trim().ToLowerInvariant();

//            // Create a new scope to inject the per-tenant setting into provider constructor
//            var scope = _sp.CreateScope();
//            var http = scope.ServiceProvider.GetRequiredService<HttpClient>();

//            return providerKey switch
//            {
//                "pinnacle" => new PinbotProvider(http, scope.ServiceProvider.GetRequiredService<ILogger<PinbotProvider>>(), setting),
//                "meta_cloud" => new MetaCloudProvider(_db, http, scope.ServiceProvider.GetRequiredService<ILogger<MetaCloudProvider>>(), setting),
//                _ => throw new NotSupportedException($"Unsupported WhatsApp provider: {providerKey}")
//            };
//        }
//    }
//}
