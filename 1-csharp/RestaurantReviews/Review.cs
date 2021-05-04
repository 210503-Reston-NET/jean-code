namespace RRModels
{
    public class Review
    {
        ///<summary>
        ///This describes the overall rating of a restaurant
        ///</summary>
        ///<value></value>
        public int Rating{get;set;}
        ///<summary>
        ///verbose description of the dining expereince
        ///</summary>
        ///<value></value>

        public string Description{get;set;}

        public override string ToString()
        {
            return $"\t Rating: {Rating} \n\t Description: {Description}";
        }

    }
}