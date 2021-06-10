using System;
using AVFoundation;

namespace MAUICameraSetting.MacCatalyst.Models
{
    public class CameraDevice : Shared.Models.ICameraDevice
    {
        private AVCaptureDevice captureDevice;

        public static CameraDevice? FromNative(AVCaptureDevice? maybeDevice)
        {
            if (maybeDevice == null)
            {
                return null;
            }
            return new CameraDevice(maybeDevice);
        }

        private CameraDevice(AVCaptureDevice captureDevice)
        {
            this.captureDevice = captureDevice;
        }
    }
}