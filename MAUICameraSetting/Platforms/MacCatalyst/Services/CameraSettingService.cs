using MAUICameraSetting.Shared.Services;
using AVFoundation;
using System;
using System.Linq;

namespace MAUICameraSetting.MacCatalyst.Services
{
	public class CameraSettingService : ICameraSettingService
    {
        private AVCaptureDevice[] foundDevices;

        public CameraSettingService()
        {
            foundDevices = Array.Empty<AVCaptureDevice>();
            ReloadDevices();
        }

        public void ReloadDevices()
        {
            var allCameraDeviceTypes = new[] {
                // AVCaptureDeviceType.BuiltInMicrophone, // Cameraだけが欲しい
                AVCaptureDeviceType.BuiltInWideAngleCamera,
                AVCaptureDeviceType.BuiltInTelephotoCamera,
                AVCaptureDeviceType.BuiltInDuoCamera,
                AVCaptureDeviceType.BuiltInDualCamera,
                AVCaptureDeviceType.BuiltInTrueDepthCamera,
                AVCaptureDeviceType.BuiltInUltraWideCamera,
                AVCaptureDeviceType.BuiltInTripleCamera,
                AVCaptureDeviceType.BuiltInDualWideCamera,
                // AVCaptureDeviceType.ExternalUnknown // Not Supported? 呼び出すとクラッシュする
            };
            var discoverySession = AVCaptureDeviceDiscoverySession.Create(allCameraDeviceTypes, AVMediaType.Video, AVCaptureDevicePosition.Unspecified);
            foundDevices = discoverySession.Devices;
        }

        public Shared.Models.ICameraDevice HandleCameraDevice(string deviceName)
        {
            var currentDevice = foundDevices.FirstOrDefault(d => d.LocalizedName == deviceName);
            return Models.CameraDevice.FromNative(currentDevice);
        }
    }
}