using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using BTSMonitoring.Data;

namespace BTSMonitoring
{
    [HubName("btsHub")]
    public class BtsHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        [HubMethodName("nhan")]
        public void Receive(string name, string message)
        {
            Clients.Caller.addNewMessageToMe(name, message);
        }

        public void SendNotification()
        {        
            //Clients.All.receiveNotify(new BtsMapController().GetDataMonitoring().point, new BtsMapController().GetDataMonitoring().detail);
        }
        [HubMethodName("addPointToBTS")]
        public void AddPointToBTS(string lat, string lng, string name)
        {
            Bo_BtsMonitoring bo = new Bo_BtsMonitoring();
            if(bo.AddPointBTS2DB(lat, lng, name) == 0)
            {
                Clients.Caller.receivePoint("Thêm vị trí BTS không thành công");
            }
            else
            {
                Clients.Caller.receivePoint("Thêm vị trí BTS thành công");
            }          
        }
    }
}