﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
    class Map
    {
        string[] contents;

        public void Draw()
        {
            int i;
            i = 0;
            while (i < contents.Length)
            {
                Console.WriteLine(contents[i]);
                i++;
            }
        }

        public void Load(string name)
        {
            int lines;
            StreamReader sr = File.OpenText(name);
            lines = int.Parse(sr.ReadLine());
            contents = new string[lines];
            int i;

            i = 0;
            while (i < lines)
            {
                contents[i] = sr.ReadLine();
                i++;
            }
        }
    }
}