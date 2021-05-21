using System;
using System.Collections.Generic;
using System.Text;

namespace SendMessageWinApp
{
    public class GlobalFunctions
    {
        public static bool System_Normal_Mode;
        public static int System_State;
        public static String Sending_Unit_Address_X;
        public static String Sending_Unit_Address_Y;
        public static String GblPowerLevel;
        public static bool ValueCANStatus;
        public static bool EdgeDeviceStatus;
        public static bool DataPublishToCloudStatus;
        

        public static void Intialization()
        {
            System_Normal_Mode = false;
            System_State = 0;
            Sending_Unit_Address_X = "";
            Sending_Unit_Address_Y = "";
            GblPowerLevel = "";
            ValueCANStatus = false;
            EdgeDeviceStatus = false;
            DataPublishToCloudStatus = false;

        }
    
    }
}
