using System.Collections.Generic;
using MonoBehaviours;
using Singletons;
using Static;
using UnityEngine;


namespace JsonSchemas
{
    public class in_connect : j_typed
    {
        public int version;
        public string nickname;

        protected in_connect()
        {
            version = Constants.Version;
            nickname = PlayerPrefsWrapper.Get(StrPrefs.input_nickname);
        }

        public override bool IsValid()
        {
            return nickname != "";
        }

        public static void Send()
        {
            in_connect data = new in_connect();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }
    
    public class in_signal : j_typed
    {
        public int version;
        public int sender; // : int

        protected in_signal()
        {
            version = Constants.Version;
            sender = PlayerPrefsWrapper.Get(IntPrefs.sender);
        }
        
        public override bool IsValid()
        {
            return sender != 0;
        }
    }


    public class in_server_info : in_signal
    {
        public static void Send()
        {
            in_server_info data = new in_server_info();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_read_chat : in_signal
    {
        public static void Send()
        {
            in_read_chat data = new in_read_chat();
            Debug.Log("sen");
            if (!data.IsValid()) return;
            Debug.Log("ding");
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_write_chat : in_signal
    {
        public string message; // : string

        protected in_write_chat()
        {
            message = PlayerPrefsWrapper.Take(StrPrefs.input_message);
        }

        public override bool IsValid()
        {
            return base.IsValid() && message != "";
        }

        public static void Send()
        {
            in_write_chat data = new in_write_chat();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_create_session : in_signal
    {
        public string session_name; // : string

        protected in_create_session()
        {
            session_name = PlayerPrefsWrapper.Take(StrPrefs.input_session_name);
        }

        public override bool IsValid()
        {
            return base.IsValid() && session_name != "";
        }

        public static void Send()
        {
            in_create_session data = new in_create_session();
            Debug.Log(data.IsValid() + " " + JsonManager.Serialize(data));
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_signal_session : in_signal
    {
        public int session_id; // : int

        protected in_signal_session()
        {
            session_id = PlayerPrefsWrapper.Get(IntPrefs.session_id);
        }

        public override bool IsValid()
        {
            return base.IsValid() && session_id != 0;
        }
    }


    public class in_game_info : in_signal_session
    {
        public static void Send()
        {
            in_game_info data = new in_game_info();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_load : in_signal_session
    {
        public abstract_game game; // : abstract?

        protected in_game_load()
        {
            // TODO
        }

        public override bool IsValid()
        {
            return base.IsValid() && game != null;
        }

        public static void Send()
        {
            in_game_load data = new in_game_load();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_save : in_signal_session
    {
        public static void Send()
        {
            in_game_save data = new in_game_save();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_join : in_signal_session
    {
        public static void Send()
        {
            in_game_join data = new in_game_join();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_quit : in_signal_session
    {
        public static void Send()
        {
            in_game_quit data = new in_game_quit();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_play : in_signal_session
    {
        public static void Send()
        {
            in_game_play data = new in_game_play();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_pause : in_signal_session
    {
        public static void Send()
        {
            in_game_pause data = new in_game_pause();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_stop : in_signal_session
    {
        public static void Send()
        {
            in_game_stop data = new in_game_stop();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_setup : in_signal_session
    {
        public abstract_generator generator; // : abstract_generator

        protected in_game_setup()
        {
            // TODO
        }

        public override bool IsValid()
        {
            return base.IsValid() && generator != null;
        }

        public static void Send()
        {
            in_game_setup data = new in_game_setup();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }


    public class in_game_signal : in_signal_session
    {
        public List<int> units; // : list<int>
        public string component; // : string
        public command data; // : j_{command_name}

        protected in_game_signal()
        {
            // units = God.I.SelectedUnits
            // component = God.I.Action
            // data = God.I.Payload
            // TODO
        }

        public override bool IsValid()
        {
            return base.IsValid() && units != null && units.Count > 0 && component != "" && data != null;
        }

        public static void Send()
        {
            in_game_signal data = new in_game_signal();
            if (!data.IsValid()) return;
            God.NetworkManager.Send(JsonManager.Serialize(data));
        }
    }
}