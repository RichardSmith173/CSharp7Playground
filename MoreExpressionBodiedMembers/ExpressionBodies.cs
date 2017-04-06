using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreExpressionBodiedMembers
{
    public class ExpressionBodies
    {
        private string name;
        public string FirstName
        {
            get => "Hello" + name;
            set => name = value ?? "No Name Given";
        }

        public ExpressionBodies(string name) => this.name = name;
    }
}
