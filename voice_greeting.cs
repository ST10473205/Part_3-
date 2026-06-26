using System;
using System.Media;

namespace demo
{
    //start of namespace
    public class voice_greeting
    {
        public void greet()
        { 
            string auto_path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\", @"\Record.wav");

            //create an instance for the soundPlayer class
            SoundPlayer greetMe = new SoundPlayer(auto_path);
            //then greet
            greetMe.Play();


        }


    }
}//end of namespace