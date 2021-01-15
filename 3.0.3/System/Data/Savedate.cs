using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

public class Savedate : MonoBehaviour
{
    //セーブデータを暗号化・復号化するプログラム
    [System.Serializable]
    public class SaveData
    {
        public float Number = 0.5f;
        public string Name = "Hoge";
        public int Count = 5;

        public override string ToString()
        {
            return string.Format("Name: {0}, Number: {1}, Count: {2}", Name, Number, Count);
        }
    }

    static public class SaveDataManager
    {
        public const string SavePath = "./test.bytes";
        private const string _password = "MB_DATAPasswordString";
        private const string _salt = "saltString_MB";
        static private RijndaelManaged _rijindeal;

        static SaveDataManager()
        {
            _rijindeal = new RijndaelManaged();
            _rijindeal.KeySize = 128;
            _rijindeal.BlockSize = 128;

            byte[] bsalt = Encoding.UTF8.GetBytes(_salt);
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(_password, bsalt);
            deriveBytes.IterationCount = 1000;

            _rijindeal.Key = deriveBytes.GetBytes(_rijindeal.KeySize / 8);
            _rijindeal.IV = deriveBytes.GetBytes(_rijindeal.BlockSize / 8);
        }

        static public void Save(SaveData data)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, data);

                byte[] source = stream.ToArray();

                source = AESlize(source);

                using (FileStream fileStream = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(source, 0, source.Length);
                }

                Console.WriteLine("Done [" + data.ToString() + "]");
            }
        }

        static public SaveData Load(string name)
        {
            SaveData data = null;

            using (FileStream stream = new FileStream(name, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    const int size = 4096;
                    byte[] buffer = new byte[size];
                    int numBytes;

                    while ((numBytes = stream.Read(buffer, 0, size)) > 0)
                    {
                        memStream.Write(buffer, 0, numBytes);
                    }

                    byte[] source = memStream.ToArray();
                    source = DeAESlize(source);

                    using (MemoryStream memStream2 = new MemoryStream(source))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        data = formatter.Deserialize(memStream2) as SaveData;

                        Console.WriteLine("Loaded.");
                    }
                }
            }

            return data;
        }

        static private byte[] AESlize(byte[] data)
        {
            ICryptoTransform encryptor = _rijindeal.CreateEncryptor();
            byte[] encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);

            encryptor.Dispose();

            // Console.WriteLine(string.Join(" ", encrypted));

            return encrypted;
        }

        static private byte[] DeAESlize(byte[] data)
        {
            ICryptoTransform decryptor = _rijindeal.CreateDecryptor();
            byte[] plain = decryptor.TransformFinalBlock(data, 0, data.Length);

            // Console.WriteLine(string.Join(" ", plain));

            return plain;
        }
    }

    static public class EntryPoint
    {
        static public void Main()
        {
            Console.WriteLine("Save? [y/n]");
            string cond = Console.ReadLine();

            if (cond == "y")
            {
                Save();
            }
            else
            {
                Load();
            }
        }

        static void Save()
        {
            
            Console.WriteLine("Name?");
            string name = Console.ReadLine();

            Console.WriteLine("Number?");
            float number;
            if (!float.TryParse(Console.ReadLine(), out number))
            {
                Debug.Log("Must input float value.");
                //Console.WriteLine("Must input float value.");
                return;
            }

            Console.WriteLine("Count?");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Debug.Log("Must input int value.");
                //Console.WriteLine("Must input int value.");
                return;
            }
            
            SaveData data = new SaveData
            {
                Name = name,
                Number = number,
                Count = count,
            };
            SaveDataManager.Save(data);
        }

        static void Load()
        {
            SaveData data = SaveDataManager.Load(SaveDataManager.SavePath);
            //Debug.Log(data.ToString());
            //Console.WriteLine(data.ToString());
        }
    }
}