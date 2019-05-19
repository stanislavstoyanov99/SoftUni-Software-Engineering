using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 1; i <= numberOfSongs; i++)
            {
                var data = Console.ReadLine().Split("_");

                string type = data[0]; // set the type of song
                string name = data[1]; // set the name of song
                string time = data[2]; // set the time of song

                Song song = new Song(type, name, time); // create new object from the class Song

                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                songs.ForEach(s => Console.WriteLine(s.Name));

                /* With foreach loop
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
                */
            }

            List<Song> filteredSongs = songs.Where(s => s.TypeList == typeList).ToList();

            songs.ForEach(s => Console.WriteLine(s.Name));

            /* Another way to do the above alogorithm
            string result = string.Empty;
            if (typeList == "all")
            {
                result += string.Join("\n", songs.Select(x => x.Name));
            }
            result += string.Join("\n", songs.Where(x => x.TypeList == typeList).Select(x => x.Name));
            Console.WriteLine(result);
            */
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
    }
}
