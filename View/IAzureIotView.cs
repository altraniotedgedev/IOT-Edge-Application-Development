namespace SendMessageWinApp.View
{
    public interface IAzureIotView
    {
        string ConnectStatusLabel { get; set; }
        string ConnectionStringTextBox { get; set; }
        string MagATemp { get; set; }
        string MagBTemp { get; set; }
        string PowerLevel { get; set; }
        string FilA_Volt { get; set; }
        string AirPressure { get; set; }
        string DeviceIdText { get; set; }

        string PublishMessageText { get; set; }

        string DeviceListBox { get; set; }
        void ClearDevListBox();

       // void StopBlinkLED();

        void SetDeviceState(string devState, string powerLvl, string faultCode);
    }
}
