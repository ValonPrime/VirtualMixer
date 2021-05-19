using NAudio.Wave;
using System;
using System.Linq;

namespace VirtualMixer.Models
{
    class AudioRouteModel
    {
        WaveIn source = null;
        DirectSoundOut sink = null;

        public AudioRouteModel(string inputDevice, string outputDevice)
        {
            int deviceNumber = InputDeviceModel.GetByName(inputDevice);
            
            // Input Initiation
            source = new WaveIn();
            source.DeviceNumber = deviceNumber;
            source.BufferMilliseconds = 10;
            source.WaveFormat = new WaveFormat(44100, 2);
            source.DataAvailable += DataRecive;

            WaveInProvider waveIn = new WaveInProvider(source);

            // Output Initiation
            Guid outputDeviceID = (from item in DirectSoundOut.Devices
                                   where item.Description == outputDevice
                                   select item.Guid).FirstOrDefault();

            sink = new DirectSoundOut(outputDeviceID, 40);
            sink.Init(waveIn);
        }

        private void DataRecive(object sender, WaveInEventArgs e)
        {

        }

        public AudioRouteModel Start()
        {
            source.StartRecording();
            sink.Play();
            return this;
        }

        public void Stop()
        {
            if(source != null)
            {
                source.StopRecording();
            }
            if(sink != null)
            {
                sink.Stop();
            }
        }

        public void UpdateVolume(float vol)
        {
            //sink. = vol;
        }

        
    }
}
