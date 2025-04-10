﻿using System.Collections.Generic;
using System.IO;


namespace BookStoreApp.DAL
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private static readonly object _lock = new object();

        private DataProvider() { }

        public static DataProvider Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataProvider();
                    return _instance;
                }
            }
        }

        public List<string[]> ReadCsv(string filePath)
        {
            List<string[]> data = new List<string[]>();
            if (!File.Exists(filePath)) return data;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    data.Add(values);
                }
            }
            return data;
        }
        public void Write_CSV(string filePath, List<string[]> data)
        {
            // Đảm bảo folder tồn tại
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var line in data)
                {
                    sw.WriteLine(string.Join(",", line));
                }
            }
        }

        public void Clear_Data(string filePath)
        {
            File.WriteAllText(filePath, string.Empty);
        }
    }
}
