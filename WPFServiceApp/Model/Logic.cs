using DapperDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService1;

namespace WPFServiceApp.Model
{
    public static class Logic
    {
        private static Uri address = new Uri("http://tractor-001-site1.dtempurl.com/Service1.svc");
        private static IService1 channel;
        
        internal static string Auth(WUser wUser) => channel.Auth(wUser);
        internal static void Reg(WUser wUser) => channel.Reg(wUser);

        static Logic()
        {
            BasicHttpBinding basicHttp = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);

            ChannelFactory<IService1> channelFactory = new ChannelFactory<IService1>(basicHttp, endpoint);
            channel = channelFactory.CreateChannel();
        }
    }
}
