using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using CustomerService.Events;
using Newtonsoft.Json;
using System.Text;

namespace CustomerService.EventStore
{

 

    public static class ServiceBusQueueStore
    {

        public static void SendEvent(CustomerCreatedEvent cce) {
            TopicClient client = new TopicClient("Endpoint=sb://customerservicens.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=jzBPEK8pBZI2LOktxiqi97yaFsm3AJ37+JunB0uI8Sc=", "customercreated");
            var jsonstring = JsonConvert.SerializeObject(cce);
            byte[] bytedata = Encoding.ASCII.GetBytes(jsonstring);


            Message msg = new Message();
            msg.Body = bytedata;

            client.SendAsync(msg).GetAwaiter().GetResult();




        }
    }
}
