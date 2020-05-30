using System;
using System.Collections.Generic;
using GuiConcreteComponents;
using MonoBehaviours;
using Singletons;
using Static;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace JsonSchemas
{
    public class out_broadcast : j_typed
    {
        public int chat_buffer_updates; // : int (to read_chat on change)
        
        public override void Execute()
        {
            if (PlayerPrefsWrapper.Get(IntPrefs.chat_buffer_updates) != chat_buffer_updates)
            {
                PlayerPrefsWrapper.Set(IntPrefs.chat_buffer_updates, chat_buffer_updates);
                in_read_chat.Send();
            }
        }
    }
    
    public class out_signal : j_typed
    {
        public string error; // : string?
        public string success; // : string?
        
        public sealed override void Execute()
        {
            if (error != null)
            {
                MessageBox.Error(error);
                return;
            }
            if (success != null) MessageBox.Info(success);
            HandleSignal();
        }

        public virtual void HandleSignal()
        {
            throw new NotImplementedException(GetType() + "Handling");
        }
    }
    
    public class out_connect : out_signal // js part
    {
        public List<string> users;
        
        public override void HandleSignal()
        {
            God.NetworkManager.Users = users;
            int uid = users.FindIndex(s => s == PlayerPrefsWrapper.Get(StrPrefs.input_nickname));
            if (uid == -1)
            {
                MessageBox.Error("You aren't registered. Contact administrator for additional info");
                return;
            }
            PlayerPrefsWrapper.Set(IntPrefs.sender, uid);
        }
    }

    public class out_server_info : out_signal
    {
        public Dictionary<int, session> sessions; // : map<int, session>

        public override void HandleSignal()
        {
            SessionScrollList.DrawScrollList(sessions);
        }
    }


    public class out_read_chat : out_signal
    {
        public List<chat_message> chat_buffer; // : queue<chat_message>?

        public override void HandleSignal()
        {
            ChatScrollList.DrawScrollList(chat_buffer);
        }
    }


    public class out_write_chat : out_signal
    {
        public override void HandleSignal()
        {
            in_read_chat.Send();
        }
    }


    public class out_create_session : out_signal
    {
        public int session_id; // int

        public override void HandleSignal()
        {
            PlayerPrefsWrapper.Set(IntPrefs.session_id, session_id);
            in_game_join.Send();
        }
    }
    
    public class out_signal_session : out_signal
    {
        
    }
    
    
    public class out_game_info : out_signal_session
    {
        public abstract_game game_data; // : abstract_game?
        
        public override void HandleSignal()
        {
            SessionInfoPanel.DrawPanel(game_data);
        }
    }


    public class out_game_load : out_signal_session
    {
        public override void HandleSignal()
        {
            in_game_info.Send();
        }
    }


    public class out_game_save : out_signal_session
    {
        public abstract_game game; // : base_game?
        
        public override void HandleSignal()
        {
            // TODO
        }
    }


    public class out_game_join : out_signal_session
    {
        public override void HandleSignal()
        {
            UnityWrapper.LoadScene(Scenes.Session);
        }
    }


    public class out_game_quit : out_signal_session
    {
        public override void HandleSignal()
        {
            UnityWrapper.LoadScene(Scenes.Lobby);
        }
    }


    public class out_game_play : out_signal_session
    {
        public override void HandleSignal()
        {
            UnityWrapper.LoadScene(Scenes.Session);
        }
    }


    public class out_game_pause : out_signal_session
    {
        public override void HandleSignal()
        {
            // TODO?
        }
    }


    public class out_game_stop : out_signal_session
    {
        public override void HandleSignal()
        {
            in_game_info.Send();
        }
    }


    public class out_game_setup : out_signal
    {
        public override void HandleSignal()
        {
            in_game_info.Send();
        }
    }


    public class out_game_signal : out_signal
    {
        public override void HandleSignal()
        {
            // TODO
        }
    }
}