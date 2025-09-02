using PruebaTecnicaCamiloCadavid.App.Dtos;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.App.Extensions
{
    public static class RoleExtensions
    {
        public static List<RoleDto> ToRoleListDto(this List<Role> roles)
        {
            return roles
                .Select(r => new RoleDto(
                 r.Id,
                 r.Name
                )).ToList();
        }
    }
}
