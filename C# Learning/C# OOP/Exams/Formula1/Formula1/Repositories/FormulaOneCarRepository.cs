using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private Dictionary<string, IFormulaOneCar> formulaOneCarRepository;

        public FormulaOneCarRepository()
        {
            this.formulaOneCarRepository = new Dictionary<string, IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.formulaOneCarRepository.Values;

        public void Add(IFormulaOneCar model)
        {
            this.formulaOneCarRepository.Add(model.Model,model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            if (this.formulaOneCarRepository.ContainsKey(name))
            {
                return this.formulaOneCarRepository[name];
            }
            return null;
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (this.formulaOneCarRepository.ContainsValue(model))
            {
                this.formulaOneCarRepository.Remove(model.Model);
                return true;
            }
            return false;
        }
    }
}
