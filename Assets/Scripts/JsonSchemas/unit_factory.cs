using System.Collections.Generic;


namespace JsonSchemas
{
    public class unit_factory : j_typed
    {
        public Dictionary<string, unit_prototype> prototypes; // : map<std::string, unit_prototype>
        public int next_id; // : int
    }
}