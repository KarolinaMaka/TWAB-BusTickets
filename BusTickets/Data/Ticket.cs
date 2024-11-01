using System;
using System.ComponentModel.DataAnnotations;


namespace BusTickets.Data
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public TicketTypeEnum TicketType { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public string BuyerName { get; set; }

        [Required]
        public string BuyerLastName { get; set; }

        [Required]
        public string BuyerEmail    { get; set; }   

        public bool IsValidated { get; set; }   

    }



    public enum TicketTypeEnum
    {
        Normal,
        Student, 
        School,
        Discounted
    }

}
