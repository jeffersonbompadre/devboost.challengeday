using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.challengeday.Kafka.Config
{
    public class KafkaConfig
    {
        public string  Topic { get; set; }
        public string  UrlBase { get; set; }
        public  string ConsumerGroup { get; set; }
    }
}
