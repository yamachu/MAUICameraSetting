namespace MAUICameraSetting.Shared.Services
{
	public interface ICameraSettingService
	{
		// Serviceが管理しているDeviceの参照を更新する
		void ReloadDevices();

		// 指定された名前のデバイスを取得する
		Models.ICameraDevice HandleCameraDevice(string deviceName);
	}
}