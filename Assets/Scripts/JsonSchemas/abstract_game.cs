using System.Collections.Generic;


namespace JsonSchemas
{
    public class abstract_game : j_typed {
        public unit_factory factory; // : unit_factory?
        public abstract_rule rule; // : abstract_rule?
        public Dictionary<int, unit> units; // : map<int, unit>?
        public Dictionary<int, player> players; // map<int, player>?
        public abstract_tilemap tilemap; // : abstract_tilemap?
    }
}