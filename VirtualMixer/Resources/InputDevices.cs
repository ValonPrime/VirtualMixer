using NAudio.Wave;
using System.Collections.ObjectModel;
using VirtualMixer.Models;

namespace VirtualMixer.Resources
{
    class InputDevices : Collection<string>
    {
        public InputDevices()
        {
            foreach (var item in InputDeviceModel.DeviceNames)
            {
                Add(item);
            }
        }
    }
}
