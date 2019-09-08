using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Core.EDB.Configurations;

namespace Core.EDB.Bus
{
    public class ProduceMessage : IProduceMessage
    {
        public async Task<bool> CreateMessage(string topicName, EDBConfigurations producerConfig, object message)
        {
            var mappedProducerConfig = new ProducerConfig
            {
                BootstrapServers = producerConfig.BootStrapServers
            };
            using (var producer = new ProducerBuilder<string, object>(mappedProducerConfig).Build())
            {
                try
                {
                    var formattedMessage = new Message<string, object>
                    {
                        Key = null,
                        Value = message
                    };
                    var generatedMessage = await producer.ProduceAsync(topicName, formattedMessage);
                    return true;
                }
                catch (ProduceException<string, object> producerEx)
                {
                    return false;
                }
                catch (Exception geenricEx)
                {
                    return false;
                }
            }
        }
    }
}