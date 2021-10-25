using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Keyboard_Logger{
    public class Key{

        public Int32 ascii {get; set;}
        private Char buttonChar {get; set;}
        private bool isKeyDown = false;
        public int keyCount {get; set;}
        public double totalTimePressed {get; set;}

        private Stopwatch stopWatch;

        public Key(Int32 Ascii, int keycount, double totaltimepressed){
            ascii = Ascii;
            buttonChar = (char) Ascii;
            keyCount = keycount;
            totalTimePressed = totaltimepressed;
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
                double ms = timeSpan.TotalMilliseconds;
                totalTimePressed += ms;
                Console.WriteLine("");
                Console.WriteLine(buttonChar + " click lasted for: " + clickTime(ms));
                Console.WriteLine(buttonChar + " average click time: " + averageClickTime());
                
            }
        }

        private string averageClickTime(){
            int avg = (int) totalTimePressed/keyCount;
            string avgString = "";
            if(avg < 1000){
                avgString += avg;
                return (avgString+"ms");
            }
            else{
                avgString += avg/1000;
                return (avgString+"s");
            }
        }

        private string clickTime(double ms){
            int click = (int) ms;
            string clickString = "";
            if(click < 1000){
                clickString += click;
                return (clickString+"ms");
            }
            else{
                clickString += click/1000;
                return (clickString+"s");
            }
        }

        public void printKeyInfo(){
            Console.WriteLine("Key: " + this.ascii);
            Console.WriteLine("Total times pressed: " + this.keyCount);
            Console.WriteLine("Average time pressed: " + totalTimePressed/keyCount + "ms");
        }
    }
}