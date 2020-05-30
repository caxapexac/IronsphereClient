namespace MonoBehaviours
{
    public static class Constants
    {
        public const string Ip = "127.0.0.1:1109";
        public const int Version = 105;
        public const float SlowUpdateDelay = 3f;
    }


    public enum Scenes
    {
        MainMenu,
        Lobby,
        Session,
    }


    public enum States
    {
        choosing,
        holding,
        playing
    }
    
    public enum Requests
    {
        in_connect,
        //in_signal, abstract
        in_server_info,
        in_read_chat,
        in_write_chat,
        in_create_session,
        // in_signal_session, abstract
        in_game_info,
        in_game_load,
        in_game_save,
        in_game_join,
        in_game_quit,
        in_game_play,
        in_game_pause,
        in_game_stop,
        in_game_setup,
        in_game_signal
    }


    public enum Responses
    {
    }
}