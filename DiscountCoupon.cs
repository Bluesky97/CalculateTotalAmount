using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrianAlexanderPutraCodingTest
{
    public class DiscountCoupon
    {
        private int promoCode;
        private string name;
        private double percentage;

        public DiscountCoupon(int promoCode, string name, double percentage)
        {
            this.promoCode = promoCode;
            this.name = name;
            this.percentage = percentage;
        }
        public int PromoCode
        {
            get { return promoCode; }
            set { promoCode = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }



    }
}
