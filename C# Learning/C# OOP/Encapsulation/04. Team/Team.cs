using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string _name;
        private readonly List<Person> _firstTeam;
        private readonly List<Person> _reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this._firstTeam = new List<Person>();
            this._reserveTeam = new List<Person>();
        }
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get 
            { 
                return this._firstTeam.AsReadOnly(); 
            }
        }
        public IReadOnlyCollection<Person> ReservedTeam
        {
            get
            {
                return this._reserveTeam.AsReadOnly();
            }
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this._firstTeam.Add(person);
            }
            else
            {
                this._reserveTeam.Add(person);
            }

        }
        public override string ToString()
        {
            return $"First team has {this.FirstTeam.Count} players.\n" +
                   $"Reserve team has {this.ReservedTeam.Count} players.";
        }
    }
}
