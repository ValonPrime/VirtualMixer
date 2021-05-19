using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VirtualMixer.Models
{
    class InputDeviceModel
    {
        public static Collection<string> DeviceNames
        {
            get
            {
                IList<string> v = (from item in Devices
                                   select item.Value).ToList();
                return new Collection<string>(v);
            }
        }

        internal static int GetByName(string name)
        {
            return (from item in Devices
                    where item.Value == name
                    select item.Key).FirstOrDefault();
        }

        private static Dictionary<int, string> Devices
        {
            get
            {
                Dictionary<int, string> devices = new Dictionary<int, string>();

                int waveInDevices = WaveIn.DeviceCount;
                for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
                {
                    WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                    devices.Add(waveInDevice, deviceInfo.ProductName);
                }

                return devices;
            }
        }
    }
}
