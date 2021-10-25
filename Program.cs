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

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        static List<Key> keys;

        static int clicks = 0;
        static void Main(string[] args){

            handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(handler, true);

            keys = DataHandler.readSavedData("data.json");

            while(true){
                
                Thread.Sleep(5);
                if(clicks == 50){
                    DataHandler.saveData(keys, "data.json");
                    clicks = 0;
                }

                //check all key states

                for(int i = 0; i < 300; i++){
                    Key key = keys[i];
                    int keyState = GetAsyncKeyState(i);
                    if(keyState == 32769){
                        clicks+= 1;
                        key.pressed();
                    }
                    if(keyState == 0){
                        key.notPressed();
                    }
                    
                }
            }

        }

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            switch (sig)
            {
                case CtrlType.CTRL_C_EVENT:
                    
                case CtrlType.CTRL_LOGOFF_EVENT:
                    
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                    
                case CtrlType.CTRL_CLOSE_EVENT:

                    DataHandler.saveData(keys, "data.json");
                    System.Environment.Exit(1);
                    return true;

                default:
                    return false;
            }
        } 

    }
}
