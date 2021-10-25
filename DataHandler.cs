using System;
using System.IO;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;

namespace Keyboard_Logger{
    public static class DataHandler
    {
        public static List<Key> readSavedData(string filename){
            try{
                string jsonString = File.ReadAllText(filename);
                List<Key> allKeys = JsonSerializer.Deserialize<List<Key>>(jsonString);
                return allKeys;
            }
            catch(Exception e){
                Console.WriteLine("Exception: " + e);
                return new List<Key>();
                throw e;
            }
        }

        public static void saveData(List<Key> allKeys, string filename){
            var options = new JsonSerializerOptions{ WriteIndented = true };
            string fileName = filename;
            string jsonString = JsonSerializer.Serialize(allKeys, options);
            File.WriteAllText(fileName, jsonString);
        }   
        
    }
}