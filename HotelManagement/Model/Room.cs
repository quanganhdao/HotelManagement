using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Model
{
    public class Room
    {
        public static double BasePrice = 1000000;
        [Key]
        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public bool isVip { get; set; }

        public double PricePerDay
        {
            get
            {
                if (isVip)
                {
                    return 1.5 * BasePrice * Capacity;
                }
                else return Capacity * BasePrice;
            }
            set
            {

            }
        }
    }
}
