using PruebaTecnicaCamiloCadavid.Domain.Abstractions;

namespace PruebaTecnicaCamiloCadavid.Domain.Models
{
    public class Role:DomainEntity<int>
    {
        public string Name { get; private set; } = default!;
        public ICollection<RolePerson> RolePerson { get; set; } = new List<RolePerson>();

        public static Role Create(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));

            return new Role
            {
                Name = name
            };
        }
    }
}
