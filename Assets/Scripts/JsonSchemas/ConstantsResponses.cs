using System.Collections.Generic;


namespace JsonSchemas
{
    public class out_update
    {
        public float delta_time; // : float
        public out_broadcast broadcast; // : out_broadcast
        public Dictionary<int, Dictionary<int, session>> players_sessions; // : map<int = session_id, map<int = player_id, session>>
    }
    


    public class out_broadcast : j_typed
    {
        public int chat_buffer_updates; // : int (to read_chat on change)
    }


    public class out_signal : j_typed
    {
        public string error; // : string?
        public string success; // : string?
    }


    public class out_server_info : out_signal
    {
        public Dictionary<int, session> sessions; // : map<int, session>
    }


    public class out_read_chat : out_signal
    {
        public List<chat_message> chat_buffer; // : queue<chat_message>?
    }


    public class out_write_chat : out_signal
    {

    }


    public class out_create_session : out_signal
    {

    }


    public class out_signal_session : out_signal
    {

    }


    public class out_game_info : out_signal
    {
        public abstract_game game_data; // : abstract_game?
    }


    public class out_game_load : out_signal
    {

    }


    public class out_game_save : out_signal
    {
        public abstract_game game; // : base_game?
    }


    public class out_game_join : out_signal
    {

    }


    public class out_game_quit : out_signal
    {

    }


    public class out_game_play : out_signal
    {

    }


    public class out_game_pause : out_signal
    {

    }


    public class out_game_stop : out_signal
    {

    }


    public class out_game_setup : out_signal
    {

    }


    public class out_game_signal : out_signal
    {

    }
}