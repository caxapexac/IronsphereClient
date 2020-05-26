using System.Collections.Generic;


namespace JsonSchemas
{
    public class abstract_tilemap : j_typed
    {
        public vector2<int> scale; // : vector2<int>
        public List<base_tile> data; // : base_tile[]
        
        // TODO
        public string GetData()
        {
            string result = "Tilemap:\n";
            for (int i = 0; i < scale.y; i++)
            {
                for (int k = 0; k < scale.x; k++)
                {
                    result += data[i * scale.x + k].height + "\t"; // TODO
                }
                result += "\n";
            }
            return result;
        }
    }
}