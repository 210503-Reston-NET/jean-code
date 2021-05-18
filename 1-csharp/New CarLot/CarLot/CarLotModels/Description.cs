using System;
namespace CarLotModels
{
    public class Description
    {
        private int _year;
        /// <summary>
        /// This describes the overall numeric rating of a restaurant
        /// </summary>
        /// <value></value>
        public Description(int mpg, string rating)
        {
            this.Rating = rating;
            this.Mpg = Mpg;
        }
        public Description()
        { }
        public int Mpg
        {
            get { return _year; }
            set
            {
                //Setting validation logic in properties
                if (_year < 0)
                {
                    throw new Exception("Rating should be greater tha zero.");
                }
                _year = value;
            }
        }
        /// <summary>
        /// Verbose description of the dining experience
        /// </summary>
        /// <value></value>
        public string Rating { get; set; }

        public override string ToString()
        {
            return $"\t Rating: {Mpg} \n\t Description: {Rating}";
        }
    }
}