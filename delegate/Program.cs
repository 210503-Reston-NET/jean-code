using System;
class Program
{
    public delegate string NewDel(string str);

    class EventProgram{
        event NewDel MyEvent;

        public EventProgram(){
            this.MyEvent += new NewDel(this.WelcomeUser);
        }

        public string WelcomeUser(string username){
            return "Welcome " + username;
        }
        static void Main(string[] args)
        {
            EventProgram obj1 = new EventProgram();
            string result = obj1.MyEvent("Tutorials Point");
            Console.WriteLine(result);
            Console.WriteLine("Hi");
        }
    }
}
