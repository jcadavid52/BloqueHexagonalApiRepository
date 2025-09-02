namespace PruebaTecnicaCamiloCadavid.Domain.Models
{
    public class RolePerson
    {
        public int IdRole { get; set; }
        public Role Role { get; set; } = default!;
        public int IdPerson { get; set; }
        public Person Person { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public static RolePerson Create(int idRole, int idPerson)
        {
            if(idPerson == default || idPerson <= 0)
            {
                throw new ArgumentException("Id de la persona no es válido");
            }

            if(idRole == default || idRole <= 0)
            {
                throw new ArgumentException("Id del rol no es válido");
            }

            return new RolePerson
            {
                IdRole = idRole,
                IdPerson = idPerson
            };
        }
    }
}
