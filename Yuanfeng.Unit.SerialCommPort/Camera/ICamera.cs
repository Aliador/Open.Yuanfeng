using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yuanfeng.Unit.SerialCommPort.Camera
{
    public interface ICamera
    {
        /// <summary>
        /// This camera status. If Init this status is true else is false.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Use default setting. width:640,height:480 camera is first device if exist.
        /// </summary>
        /// <param name="control">Set this paint control must be a panel or can add child control.</param>
        /// <returns></returns>
        bool Init(Control control);
        /// <summary>
        /// Use default device.user setting this width and height.
        /// </summary>
        /// <param name="control">Set this paint control must be a panel or can add child control.</param>
        /// <param name="x">This pic width</param>
        /// <param name="y">This pic height</param>
        /// <returns></returns>
        bool Init(Control control, int x, int y);
        /// <summary>
        /// Use setting this device and other options.
        /// </summary>
        /// <param name="control">Set this paint control must be a panel or can add child control.</param>
        /// <param name="x">This pic width</param>
        /// <param name="y">This pic height</param>
        /// <param name="cameraName">Set camera</param>
        /// <returns></returns>
        bool Init(Control control, int x, int y, string cameraName);

        /// <summary>
        /// Take a photo
        /// </summary>
        /// <param name="pictureBuffer">This pic buffer</param>
        /// <returns></returns>
        bool Snapshot(out byte[] pictureBuffer);

        /// <summary>
        /// Realase current use camera.
        /// </summary>
        /// <returns></returns>
        bool Release();
    }
}
