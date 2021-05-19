using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VirtualMixer.Resources
{
    class OutputDevices : Collection<string>
    {
        public OutputDevices()
        {
            foreach (var item in DirectSoundOut.Devices)
            {
                Add(item.Description);
            }
        }
    }
}
