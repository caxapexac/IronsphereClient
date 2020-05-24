using System.Collections.Generic;


namespace JsonSchemas
{
    public class abstract_tilemap : j_typed
    {
        public vector2<int> scale; // : vector2<int>
        public List<base_tile> data; // : base_tile[]
    }
}