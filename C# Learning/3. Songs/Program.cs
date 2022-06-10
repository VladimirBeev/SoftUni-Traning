using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Songs
{
    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] song = Console.ReadLine().Split('_',StringSplitOptions.RemoveEmptyEntries);
                string typeList = song[0];
                string name = song[1];
                string time = song[2];

                Song newSong = new Song()
                {
                    TypeList = typeList,
                    Name = name,
                    Time = time,
                };
                songs.Add(newSong);
            }
            string command = Console.ReadLine();
            if (command == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.FindAll(songs => songs.TypeList == command);
                foreach (var item in filteredSongs)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
