namespace MonoBehaviours
{
    public static class Constants
    {
        public const string Ip = "163.172.163.152:1109";
        public const string IpLocalhost = "127.0.0.1:1109";
        public const int Version = 106;
        public const float SlowUpdateDelay = 3f;
    }

    public enum States
    {
        choosing,
        holding,
        playing
    }
}