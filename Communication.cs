/*
© Siemens AG, 2017-2019
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/


namespace RosSharp.RosBridgeClient
{
    public abstract class Communication
    {
        public string op { get; set; } // required
        public string id { get; set; } // optional

        public Communication(string id = null)
        {
            this.id = id;
        }
    }

    public class Advertisement : Communication
    {
        public string topic { get; set; } // required
        public string type  { get; set; } // required

        public Advertisement(string id, string topic, string type) : base(id)
        {
            this.op = "advertise";
            this.topic = topic;
            this.type = type;
        }
    }

    public class Unadvertisement : Communication
    {
        public string topic { get; set; } // required

        public Unadvertisement(string id, string topic) : base(id)
        {
            this.op = "unadvertise";
            this.topic = topic;
        }
    }

    public class Publication<T> : Communication where T : Message
    {
        public string topic { get; set; } // required
        public T msg { get; set; } // required

        public Publication(string id, string topic, T msg) : base(id)
        {
            this.op = "publish";
            this.topic = topic;
            this.msg = msg;
        }
    }

    public class Subscription : Communication
    {
        public string topic { get; set; } // required
        public string type { get; set; } // optional
        public int throttle_rate { get; set; } // optional
        public int queue_length { get; set; } // optional
        public int fragment_size { get; set; } // optional
        public string compression { get; set; } // optional

        public Subscription(string id, string topic, string type, int throttle_rate = 0, int queue_length = 1, int fragment_size = int.MaxValue, string compression = "none") : base(id)
        {
            this.op = "subscribe";
            this.topic = topic;
            this.type = type;
            this.throttle_rate = throttle_rate;
            this.queue_length = queue_length;
            this.fragment_size = fragment_size;
            this.compression = compression;
        }
    }

    public class Unsubscription : Communication
    {
        public string topic { get; set; } // required

        public Unsubscription(string id, string topic) : base(id)
        {
            this.op = "unsubscribe";
            this.topic = topic;
        }
    }

    public class ServiceCall<T> : Communication where T : Message
    { 
        public string service { get; set; } // required
        public T args { get; set; } // optional
        public int fragment_size { get; set; } // optional
        public string compression { get; set; } // optional

        public ServiceCall(string id, string service, T args, int fragment_size = int.MaxValue, string compression = "none") : base(id)
        {
            this.op = "call_service";
            this.service = service;
            this.args = args;
            this.fragment_size = fragment_size;
            this.compression = compression;
        }
    }

    public class ServiceResponse<T> : Communication where T : Message
    {
        public string service { get; set; } // required
        public T values { get; set; } // optional
        public bool result { get; set; } // required

        public ServiceResponse(string id, string service, T values, bool Result) : base(id)
        {
            this.op = "service_response";
            this.service = service;
            this.values = values;
            result = Result;
        }
    }
    public class ServiceAdvertisement : Communication
    {
        public string type { get; set; } // required
        public string service { get; set; } // required

        public ServiceAdvertisement(string service, string type) 
        {
            this.op = "advertise_service";
            this.service = service;
            this.type = type;
        }
    }
    public class ServiceUnadvertisement : Communication
    {
        public string service { get; set; } // required

        public ServiceUnadvertisement(string Service)
        {
            this.op = "unadvertise_service";
            service = Service;
        }
    }
}
