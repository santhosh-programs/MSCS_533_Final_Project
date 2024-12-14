using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TrackYourself.Models
{
    public class DeviceLocationMessage : ValueChangedMessage<DeviceLocation>
    {
        public DeviceLocationMessage(DeviceLocation deviceLocation) : base(deviceLocation) 
        {
            
        }
    }
}
