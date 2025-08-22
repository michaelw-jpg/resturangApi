namespace resturangApi.Mappers
{
    public static class GenericPatchMapper
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
                    continue; //skip if a proerty is null
                }
                var entityProp = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name);
                if (entityProp == null)
                    continue; // skip if dto/entity property missmatch

                var targetType = Nullable.GetUnderlyingType(entityProp.PropertyType) ?? entityProp.PropertyType;
                entityProp.SetValue(entity, Convert.ChangeType(value, targetType));
            }
        }
    }
}
