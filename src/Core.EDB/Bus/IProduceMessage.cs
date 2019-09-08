using System.Threading.Tasks;
using Confluent.Kafka;
using Core.EDB.Configurations;

namespace Core.EDB.Bus
{
    public interface IProduceMessage
    {
         Task<bool> CreateMessage(string topicName, EDBConfigurations config, object message);
    }
}