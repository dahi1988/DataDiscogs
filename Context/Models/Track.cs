using System;

namespace Context.Models
{
    public class Track
    {
        public int Id {get; set;}
        public string Position {get; set;}
        public string Title {get; set;}
        /// Duration is set in seconds
        public int Duration {get; set;}

        /// <summary>
        /// returns duration in seconds
        /// </summary>
        private static int ParseDurationToSeconds(string d)
        {
            if (d.Contains(":"))
            {
                string[] duration = d.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                int min = 0;
                if (duration.Length >= 1)
                {
                    int.TryParse(duration[0], out min);
                }
                int sec = 0;
                if (duration.Length >= 2)
                {
                    int.TryParse(duration[1], out sec);
                }
                return min * 60 + sec;
            }

            return 0;
        }
    }
}