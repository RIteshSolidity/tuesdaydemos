using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.events;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace WebApplication7.EventStore
{
    public static class ServiceBus
    {
        private static string connectionString = "Endpoint=sb://testsbsat.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=2IKXL8H1H5R5unj+MC4ebkf92I2GlSuM7QLFFnwAUeI=";
        public static async Task sendMessage(IEvents myevent) {
            QueueClient client = new QueueClient(connectionString, "testqueue");
            CustomerCreatedEvent e = myevent as CustomerCreatedEvent;
            var jsondata = JsonConvert.SerializeObject(e);
            Message msg = new Message();

            byte[] bytedata = Encoding.ASCII.GetBytes(jsondata);
            msg.Body = bytedata;
            await client.SendAsync(msg);


        }
    }
}
