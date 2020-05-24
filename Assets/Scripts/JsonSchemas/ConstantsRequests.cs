using System.Collections.Generic;


namespace JsonSchemas
{
    public class in_signal : j_typed
    {
        public int sender; // : int
    }


    public class in_server_info : in_signal
    {
    }


    public class in_read_chat : in_signal
    {
    }


    public class in_write_chat : in_signal
    {
        public string message; // : string
    }


    public class in_create_session : in_signal
    {
        public int session_id; // : int
        public string session_name; // : string
    }


    public class in_signal_session : in_signal
    {
        public int session_id; // : int
    }


    public class in_game_info : in_signal_session
    {
    }


    public class in_game_load : in_signal_session
    {
        public abstract_game game; // : abstract?
    }


    public class in_game_save : in_signal_session
    {
    }


    public class in_game_join : in_signal_session
    {
    }


    public class in_game_quit : in_signal_session
    {
    }


    public class in_game_play : in_signal_session
    {
    }


    public class in_game_pause : in_signal_session
    {
    }


    public class in_game_stop : in_signal_session
    {
    }


    public class in_game_setup : in_signal_session
    {
        public abstract_generator generator; // : abstract_generator
    }


    public class in_game_signal : in_signal_session
    {
        public List<int> units; // : list<int>
        public string component; // : string
        public command data; // : j_{command_name}
    }
}