﻿namespace JsonKnownTypes.Utils
{
    internal static class Mapper
    {
        internal static JsonDiscriminatorSettings Map(JsonDiscriminatorAttribute entity)
        {
            var settings = new JsonDiscriminatorSettings();

            settings.DiscriminatorFieldName = entity.Name ?? settings.DiscriminatorFieldName;
            settings.UseClassNameAsDiscriminator = entity.AutoJson ?? settings.UseClassNameAsDiscriminator;
            
            return settings;
        }
    }
}
