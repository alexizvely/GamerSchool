﻿namespace GameStore.Data.Models
{
    using System.Collections.Generic;

    using GameStore.Data.Common.Models;

    public class JokeCategory : BaseModel<int>
    {
        public JokeCategory()
        {
            this.Jokes = new HashSet<Joke>();
        }

        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
