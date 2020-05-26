using System.Collections.Generic;


namespace JsonSchemas
{
    public class session : j_typed
    {
        public string session_name; // : string?
        public List<int> players_uid; // : list<int>?
        public string state; // : string
        public abstract_game game; // : abstract_game?

        public override void Execute()
        {
            // TODO
        }
    }
}