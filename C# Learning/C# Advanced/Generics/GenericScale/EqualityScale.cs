using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public T Left { get; set; }
        public T Right { get; set; }
        public EqualityScale(T right, T left)
        {
            this.Right = right;
            this.Left = left;
        }
        public bool AreEqual()
        {
            return this.Left.Equals(this.Right);
            throw new NotImplementedException();
        }
    }
}
