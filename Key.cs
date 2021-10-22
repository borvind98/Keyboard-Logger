using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Keyboard_Logger{
    public class Key{

        Int32 ascii;

        Char buttonChar;
        private bool isKeyDown = false;
        private int keyCount = 0;
        private double totalTimePressed = 0;

        Stopwatch stopWatch;

        public Key(Int32 i){
            ascii = i;
            buttonChar = (char) i;
        }

        public void pressed(){
            if(!isKeyDown){
                stopWatch = new Stopwatch();
                stopWatch.Start();
                isKeyDown = true;
                keyCount++;
                Console.WriteLine("");
                Console.WriteLine(buttonChar + " total times pressed: " + keyCount);
                
            }
        }

        //Function for when a key is not pressed, or when a key is released
        public void notPressed(){
            if(isKeyDown){
                stopWatch.Stop();
                isKeyDown = false;
                TimeSpan timeSpan = stopWatch.Elapsed;
                double ms = timeSpan.Milliseconds;
                double s = timeSpan.Seconds;
                totalTimePressed += ms;
                Console.WriteLine("");
                Console.WriteLine(buttonChar + " click lasted for: " +s+" "+ ms + "ms");
                Console.WriteLine(buttonChar + " average click time: " + (int) totalTimePressed/keyCount + "ms");
                
            }
        }
    }
}