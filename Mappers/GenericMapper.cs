using resturangApi.Enums;

namespace resturangApi.Mappers
{
    public static class GenericMapper
    {
        public static void ApplyPatch<TEntity,TDto>(TEntity entity, TDto dto)
            where TEntity : class
            where TDto : class
        {
            var dtoProps = typeof(TDto).GetProperties();
            var entityProps = typeof(TEntity).GetProperties();
            foreach (var dtoProp in dtoProps)
            {
                var value = dtoProp.GetValue(dto);
                if (value == null)
                {
                    continue; //skip if a property is null
                }
                var entityProp = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name);
                if (entityProp == null)
                    throw new Exception($"Property missmatch between {typeof(TEntity).Name} and {typeof(TDto).Name}"); //this shouldnt happen only if dto is missconfigured

                var targetType = Nullable.GetUnderlyingType(entityProp.PropertyType) ?? entityProp.PropertyType;
                entityProp.SetValue(entity, Convert.ChangeType(value, targetType));
            }
        }

        public static void ApplyCreate<TEntity,TDto>(TEntity entity, TDto dto)
            where TEntity : class
            where TDto : class
        {
            var dtoProps= typeof(TDto).GetProperties();
            var entityProps = typeof(TEntity).GetProperties();

            foreach(var dtoProp in dtoProps)
            {
                var value = dtoProp.GetValue(dto);
                var entityProp = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name);
                if (entityProp == null)
                   throw new Exception($"Property missmatch between {typeof(TEntity).Name} and {typeof(TDto).Name}"); //this shouldnt happen only if dto is missconfigured
                if (value == null)
                    continue; // skip if a property is null, optional fields

                entityProp = entityProps.First(p => p.Name == dtoProp.Name);
                entityProp.SetValue(entity, value);
            }
            

        }
    }
}
