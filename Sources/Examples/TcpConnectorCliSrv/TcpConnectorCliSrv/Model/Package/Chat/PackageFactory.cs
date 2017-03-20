namespace xPhoneShared.SocketStream.Package
{
    class PackageFactory
    {
        public static Package CreateLoginPackage(string deviceId, string accessToken, string refreshToken)
        {
            return new LoginReqPackage(deviceId, accessToken, refreshToken);
        }

        public static Package CreateCallRequestPackage()
        {
            return new Package(MessageTypes.CallReq);
        }

        public static Package CreateCallHangupPackage()
        {
            return new Package(MessageTypes.CallReq);
        }

        public static Package CreateForwardPackage(string targetId, byte[] messageBytes)
        {
            return new DeviceForwardReqPackage(targetId, messageBytes);
        }
    }
}
