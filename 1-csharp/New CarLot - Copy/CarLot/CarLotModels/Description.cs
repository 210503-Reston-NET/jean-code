using System;
namespace CarLotModels
{
    public class Description
    {
        private int _mpg;
        public Description(int mpg, string rating, int price)
        {
            this.Rating = rating;
            this.Mpg = mpg;
            this.Price = price;
        }
        public Description()
        { }
        public int Mpg
        {
            get { return _mpg; }
            set
            {
                if (_mpg < 0)
                {
                    throw new Exception("Mpg should be greater than zero.");
                }
                _mpg = value;
            }
        }
        public string Rating { get; set; }
        public int Price{get;set;}

        public override string ToString()
        {
            return $"\t Mpg: {Mpg} \n\t Description: {Rating} \n\t Price: {Price}";
        }
    }
}