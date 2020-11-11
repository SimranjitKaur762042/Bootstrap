using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class Quotation
    {
        [Required(ErrorMessage = "Please enter Total Units Used.")]
        [Range(0, 100000000, ErrorMessage = "Total units used must be greater than zero.")]
        public double? TotalUnits { get; set; }

        [Required(ErrorMessage = "Please enter Price Per Unit.")]
        [Range(0, 100000000, ErrorMessage = "Price per unit used must be greater than zero.")]
        public double? PricePerUnit { get; set; }


        public double DiscountPercent,Sale;

        public double CalcSale()
        {
            Sale = PricePerUnit.Value * TotalUnits.Value;
            return Sale;
        }

        public double CalcDiscountPercent()
        {
            Sale = CalcSale();
            if (TotalUnits.HasValue && PricePerUnit.HasValue)
            {
                if (Sale>5000)
                {
                    DiscountPercent = 5;
                    return DiscountPercent;
                }
                else
                {
                    DiscountPercent = 2;
                    return DiscountPercent;
                }
                
            }
            else
            {
                return 0;
            }
        }

        public double CalculateDiscount() {
            if (TotalUnits.HasValue)
            {
                DiscountPercent=CalcDiscountPercent();
                return Sale * (DiscountPercent / 100);  
            }
            else
            {
                return 0;
            }
        }

        public double CalculateTotal()
        {
            if (TotalUnits.HasValue && PricePerUnit.HasValue)
            {
                double discount = CalculateDiscount();
                return Sale - discount;
            }
            else
            {
                return 0;
            }
        }
    }
}
