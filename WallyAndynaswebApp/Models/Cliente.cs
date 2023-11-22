namespace WallyAndynaswebApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? NombreCompleto { get; set; }
        public int CI { get; set; }
        public int Celular { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
