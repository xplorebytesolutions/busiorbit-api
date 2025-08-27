using System.Threading;
using System.Threading.Tasks;
using xbytechat.api.Features.MessagesEngine.Abstractions;

namespace xbytechat.api.Features.MessagesEngine.Factory
{
    public interface IWhatsAppProviderFactory
    {
        //Task<IWhatsAppProvider> CreateAsync(Guid businessId, CancellationToken ct = default);
        Task<IWhatsAppProvider> CreateAsync(Guid businessId);
    }
}
