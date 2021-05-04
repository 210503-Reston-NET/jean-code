/// <summary>
/// 
/// </summary>

namespace RRModels
{
    ///<summary>
    /// Data structure used to define a restaurant 
    ///</summary>

    public class Restaurant
    {
    
    public Restaurant(string name, string city, string state){
        this.Name = name;
        this.City = city;
        this.State = state;
    }


    public Restaurant(){

    }
        //class members
        //1. constructor- use this to create an instance of the class
        //2. fields - defines the characteristics of a class
        //. methods - defines the behaviro of a class
        //4. properties - also known as smart fields, are accessor methods used to access private backing fields (private fields)
        //* note that properties are analogous to java getter and setter.

        ///<summary>
        ///This describes the name of your restaurant
        ///</summary>
        ///<value></value>

        public string Name {get;}
        ///<summary>
        ///This describes the name of your restaurant
        ///</summary>
        ///<value></value>

        public string City {get;}
        ///<summary>
        ///This describes the location
        ///</summary>
        ///<value></value>

        public string State {get;}
        ///<summary>
        ///This describes the State
        ///</summary>
        ///<value></value>

        public Review Review{get;set;}
        ///<summary>
        ///This describes the Review
        ///</summary>
        ///<value></value>

        public override string ToString(){
            return $" Name: {Name} \n Location: {City}, {State} \n Review: {Review.ToString()}";
        }
    }
}