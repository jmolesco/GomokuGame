using System.Threading.Tasks;

namespace PG.API.Infrastructure.KeepAlive.Publisher
{
    public interface IKeepAliveEventPublisher
    {
        Task PublishKeepAliveEvent();
    }
}
