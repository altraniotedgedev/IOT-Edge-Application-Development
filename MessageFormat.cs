using System;
using System.Collections.Generic;
using System.Text;

namespace SendMessageWinApp.MsgFormat
{
    public enum ESystemState : byte
    {
        FAULTSTATE = 0x01,
        RESETSTATE = 0x03,
        STANDBYSTATE = 0x06,
        WAIT2_LAMPONSTATE = 0x09,
        LAMPONSTATE = 0x0A,sss
    }
    public class MessageFormat
    {
        public int[] iSysData;
        public string sSysState;
        public int iFaultCode;
    }

    
}
