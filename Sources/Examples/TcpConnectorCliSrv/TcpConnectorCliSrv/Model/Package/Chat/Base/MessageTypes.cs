using System;
using System.Collections.Generic;
using System.Text;

namespace xPhoneShared.SocketStream.Package
{
    public enum MessageTypes : UInt16
    {
        None = 0,
        Ping = 1,
        Pong = 2,
        LoginReq = 10,
        LoginResp = 11,
        CallReq = 20,
        CallResp = 21,
        RingReq = 25,
        RingResp = 26,
        SessionReq = 30,
        SessionResp = 31,
        LogReq = 100,
        LogResp = 101,
        SyncReq = 180,
        SyncResp = 181,
        DeviceForwardReq = 200,
        DeviceForwardResp = 201,
        SessionForwardReq = 202,
        SessionForwardResp = 203
    }
}
