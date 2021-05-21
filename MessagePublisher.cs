// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// This application uses the Azure IoT Hub device SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/device/samples

using Microsoft.Azure.Devices.Client;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendMessageWinApp.View;
using SendMessageWinApp.MsgFormat;
using System.Collections.Generic;

namespace SendMessageWinApp.Publisher
{
   
    public class cMessagePublisher
    {
        private readonly IAzureIotView view;
        private bool bStart = false;
        private static DeviceClient s_deviceClient= null;
        private static readonly TransportType s_transportType = TransportType.Mqtt;
        private static Mutex mutex = new Mutex();
        private static Queue<MessageFormat> qSysDataMsg = new Queue<MessageFormat>();

        // The device connection string to authenticate the device with your IoT hub.
        // Using the Azure CLI:
        // az iot hub device-identity show-connection-string --hub-name {YourIoTHubName} --device-id MyDotnetDevice --output table
        private static string s_connectionString = "HostName=AltranIndiaIOTHub.azure-devices.net;DeviceId=MyDeskDevice;SharedAccessKey=sgw7RCCwUj7Z4774DVlrVr8tZ2CCV0wTMo8Xh60YaFg=";

        private static TimeSpan s_telemetryInterval = TimeSpan.FromSeconds(5); // Seconds
        public cMessagePublisher(IAzureIotView view)
        {
            this.view = view;

        }

        public  async Task<bool> ConnectToAzure(string args)
        {
            bool cnstr = ValidateConnectionString(args);
            if (cnstr)
                view.ConnectStatusLabel = "Valid Connection String";
            else
            {
                view.ConnectStatusLabel = "Invalid Connection String";
                view.PublishMessageText = "Connection Failed : Invalid Connection String";
                return false;
            }
            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(args, s_transportType);
            if(s_deviceClient != null)
                view.ConnectStatusLabel = "Valid Connection String";
            //view.PublishMessageText = "Successfully connected to Azure IoT Hub";

            // Create a handler for the direct method call
            await s_deviceClient.SetMethodHandlerAsync("SetTelemetryInterval", SetTelemetryInterval, null);

            return true;
        }

        public async Task startPublishData()
        {
            // Run the telemetry loop
            bStart = true;
            view.PublishMessageText = "Data Publishing to IoT Hub Started";
            await SendDeviceToCloudMessagesAsync();
        }

        public void stopPublishData()
        {
            bStart = false;
            view.PublishMessageText = "Data Publishing to IoT Hub Stopped";
        }

        public void Disconnect()
        {
            stopPublishData();
            s_deviceClient.Dispose();
            view.ConnectStatusLabel = "Disconnected";
            view.PublishMessageText = "Azure IoT Hub Disconnected";
            s_deviceClient = null;
        }

        private static bool ValidateConnectionString(string args)
        {
            if (args.Any())
            {
                try
                {
                    var cs = IotHubConnectionStringBuilder.Create(args);
                    s_connectionString = cs.ToString();
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error: Unrecognizable parameter '{args}' as connection string.");
                    //Environment.Exit(1);
                    return false;
                }
            }
            else
            {
                try
                {
                    _ = IotHubConnectionStringBuilder.Create(s_connectionString);
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("This sample needs a device connection string to run. Program.cs can be edited to specify it, or it can be included on the command-line as the only parameter.");
                    //Environment.Exit(1);
                    return false;
                }
            }
        }

        // Handle the direct method call
        private static Task<MethodResponse> SetTelemetryInterval(MethodRequest methodRequest, object userContext)
        {
            var data = Encoding.UTF8.GetString(methodRequest.Data);

            // Check the payload is a single integer value
            if (int.TryParse(data, out int telemetryIntervalInSeconds))
            {
                s_telemetryInterval = TimeSpan.FromSeconds(telemetryIntervalInSeconds);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Telemetry interval set to {s_telemetryInterval}");
                Console.ResetColor();

                // Acknowlege the direct method call with a 200 success message
                string result = $"{{\"result\":\"Executed direct method: {methodRequest.Name}\"}}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 200));
            }
            else
            {
                // Acknowlege the direct method call with a 400 error message
                string result = "{\"result\":\"Invalid parameter\"}";
                return Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(result), 400));
            }
        }

        // Async method to send simulated telemetry
        private async Task SendDeviceToCloudMessagesAsync()
        {
            MessageFormat mf = new MessageFormat();

            while (bStart)
            {
                mutex.WaitOne();
                var count = qSysDataMsg.Count;
                Console.WriteLine("Queue size = {0}", count);
                if(count > 0)
                    mf = qSysDataMsg.Dequeue();
                mutex.ReleaseMutex();

                if (count == 0)
                {
                    await Task.Delay(500);
                    continue;
                }
                else
                {
                    int currentPowerLvl = mf.iSysData[0];
                    int currentMagA = mf.iSysData[1];
                    int currentMagB = mf.iSysData[2];
                    int currentFilAVolt = mf.iSysData[3];
                    int currentAirPressure = mf.iSysData[4];

                    int iFaultCode = mf.iFaultCode;
                    string sSysState = mf.sSysState;

                    //view.PowerLevel = currentPowerLvl.ToString("###");
                    //view.MagATemp = currentMagA.ToString("###");
                    //view.MagBTemp = currentMagB.ToString("###");
                    //view.FilA_Volt = currentFilAVolt.ToString("###.##");
                    //view.AirPressure = currentAirPressure.ToString("###");

                    view.PowerLevel = Convert.ToString(currentPowerLvl);
                    view.MagATemp = Convert.ToString(currentMagA);
                    view.MagBTemp = Convert.ToString(currentMagB);
                    view.FilA_Volt = Convert.ToString(currentFilAVolt);
                    view.AirPressure = Convert.ToString(currentAirPressure);
                    view.SetDeviceState(sSysState, view.PowerLevel, Convert.ToString(iFaultCode));

                    string tsStr = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    string strmsg = "Pay Load: ";
                    strmsg += "{ TS [" + tsStr + "], ";
                    strmsg += "DEV ID [" + view.DeviceIdText + "], ";
                    strmsg += "DEV STATE [" + sSysState + "], ";
                    strmsg += "FAULT CODE [" + Convert.ToString(iFaultCode) + "], ";
                    strmsg += "DATA [" + currentPowerLvl.ToString() + ", " + currentMagA.ToString()+ ", " + currentMagB.ToString() + "," + currentFilAVolt.ToString() + "," + currentAirPressure.ToString() + "] }";

                    if (GlobalFunctions.DataPublishToCloudStatus == true)
                    {
                        // Create JSON message
                        string messageBody = JsonSerializer.Serialize(
                            new
                            {
                                TS = tsStr,
                                DevId = view.DeviceIdText,
                                SystemState = sSysState,
                                FaultCode = Convert.ToString(iFaultCode),
                                PowerLevel = view.PowerLevel,
                                MagATemp = view.MagATemp,
                                MagBTemp = view.MagBTemp,
                                FilAVolt = view.FilA_Volt,
                                AirPressure = view.AirPressure,
                            });
                        using var message = new Microsoft.Azure.Devices.Client.Message(Encoding.ASCII.GetBytes(messageBody))
                        {
                            ContentType = "application/json",
                            ContentEncoding = "utf-8",
                        };

                        // Add a custom application property to the message.
                        // An IoT hub can filter on these properties without access to the message body.
                        message.Properties.Add("PowerLevelAlert", (currentPowerLvl > 90) ? "true" : "false");

                        // Send the telemetry message
                        await s_deviceClient.SendEventAsync(message);
                        Console.WriteLine($"{DateTime.Now} > Sending message: {messageBody}");
                    }
                    view.PublishMessageText = strmsg;
                    Array.Clear(mf.iSysData, 0, 5);

                    try
                    {
                        await Task.Delay(s_telemetryInterval);
                    }
                    catch (TaskCanceledException)
                    {
                        // User canceled
                        return;
                    }
                }
            }
        }

        public void UpdateSystemData(MessageFormat mf)
        {
           // view.StopBlinkLED();
            mutex.WaitOne();
            if(qSysDataMsg.Count == 0)
                qSysDataMsg.Enqueue(mf);
            mutex.ReleaseMutex();
        }
    }
}