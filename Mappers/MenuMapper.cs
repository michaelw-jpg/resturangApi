using resturangApi.Dto.MenuDtos;
using resturangApi.Models;

namespace resturangApi.Mappers
{
    public class MenuMapper
    {
        public static void ApplyPatch(Menu menu, PatchMenuDto PatchMenuDto)
        {
            var dtoProps = typeof(PatchMenuDto).GetProperties();
            var entityProps = typeof(Menu).GetProperties();

            foreach (var dtoProp in dtoProps)
            {
                var entityProp = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name);
                if (entityProp != null && dtoProp.GetValue(PatchMenuDto) != null)
                {
                    entityProp.SetValue(menu, dtoProp.GetValue(PatchMenuDto));
                }
            }
        }
    }
}
