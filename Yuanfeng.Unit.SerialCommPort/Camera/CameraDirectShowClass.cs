using Camera_NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Yuanfeng.Smarty;

namespace Yuanfeng.Unit.SerialCommPort.Camera
{
    public class CameraDirectShowClass : ICamera
    {
        private string DeviceName = string.Empty;
        private int Width = 640;
        private int Height = 480;
        private bool isOpen = false;
        private List<string> DeviceNames = new List<string>();
        private CameraControl CameraControl = new CameraControl();
        private CameraChoice CameraChoice = new CameraChoice();
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public bool Init(Control control)
        {
            this.Width = 640;
            this.Height = 480;

            this.DeviceNames.Clear();
            this.CameraChoice.UpdateDeviceList();

            foreach (var item in CameraChoice.Devices)
            {
                this.DeviceNames.Add(item.Name);
            }

            if (this.DeviceNames.Count <= 0) throw new Exception("Not find this camera device.");

            this.DeviceName = this.DeviceNames[0];

            return Init(control, this.Width, this.Height, DeviceName);
        }

        public bool Init(Control control, int x, int y)
        {
            this.Width = x;
            this.Height = y;

            this.DeviceNames.Clear();
            this.CameraChoice.UpdateDeviceList();

            foreach (var item in CameraChoice.Devices)
            {
                this.DeviceNames.Add(item.Name);
            }

            if (this.DeviceNames.Count <= 0) throw new Exception("Not find this camera device.");

            this.DeviceName = this.DeviceNames[0];

            return Init(control, this.Width, this.Height, DeviceName);
        }

        public bool Init(Control control, int x, int y, string cameraName)
        {
            if (this.IsOpen && this.DeviceName.Equals(cameraName)) throw new Exception("This camera is opend.");

            this.DeviceName = cameraName;
            this.Width = x;
            this.Height = y;

            this.DeviceNames.Clear();
            this.CameraChoice.UpdateDeviceList();

            foreach (var item in CameraChoice.Devices)
            {
                this.DeviceNames.Add(item.Name);
            }

            if (this.DeviceNames.Count <= 0) throw new Exception("Not find this camera device.");

            if (!this.DeviceNames.Contains(DeviceName)) throw new Exception("Not find this set name device.");

            if (control == null) throw new Exception("The target control parent is null.");
            
            control.Controls.Add(this.CameraControl);

            this.CameraControl.Dock = DockStyle.Fill;

            int cameraIndex = this.DeviceNames.IndexOf(DeviceName);

            var moniker = this.CameraChoice.Devices[cameraIndex].Mon;

            ResolutionList resolutions = Camera_NET.Camera.GetResolutionList(moniker);

            if (resolutions == null) throw new Exception("This camera is not find resolutions");

            var resolution = resolutions.Find(delegate (Resolution a) { return a.Height == y && a.Width == x; });

            if (resolution == null) throw new Exception("This resolution is not find.");

            this.CameraControl.SetCamera(moniker, resolution);

            isOpen = true;

            return IsOpen;
        }

        public bool Release()
        {
            if (isOpen) { this.CameraControl.CloseCamera(); isOpen = false; }
            return !IsOpen;
        }

        public bool Snapshot(out byte[] pictureBuffer)
        {
            pictureBuffer = null;
            if (!IsOpen) throw new Exception("This camera is not open.");

           var bmp = this.CameraControl.SnapshotSourceImage();

            if (bmp == null) throw new Exception("This snapshot bmp is null.");

            pictureBuffer = bmp.ToBuffer();

            return true;
        }
    }
}
