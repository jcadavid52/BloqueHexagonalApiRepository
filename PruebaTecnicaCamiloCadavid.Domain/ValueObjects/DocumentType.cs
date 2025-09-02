namespace PruebaTecnicaCamiloCadavid.Domain.ValueObjects
{
    public sealed class DocumentType
    {
        public static readonly DocumentType Cedula = new("CC");
        public static readonly DocumentType Pasaporte = new("PA");

        public string Value { get; }

        private DocumentType(string value)
        {
            Value = value.Trim();
        }

        public override string ToString() => Value;

        public static DocumentType From(string value) =>
        value switch
        {
            "CC" => Cedula,
            "PA" => Pasaporte,
            _ => throw new ArgumentException($"Tipo de documento inválido: {value}")
        };
    }
}
