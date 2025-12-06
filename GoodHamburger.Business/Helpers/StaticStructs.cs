using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Helpers
{
    public struct StaticStructs
    {
        public struct ProductsId
        {
            public const string Burger = "08d212ed-c3aa-432b-8aed-74c9269abd01";
            public const string Eggs = "803f106f-38cf-4c2e-8670-61b4f91af064";
            public const string Bacon = "b4a7c952-21f1-47bc-b403-64c88aae6d61";
            public const string Fries = "8e85d72f-8fc9-43c2-9667-62af9520686b";
            public const string SoftDrink = "798fc00b-8727-46a0-8dd1-4d0c24784271";
        }

        public struct ProductTypesId
        {
            public const string Sandwich = "1";
            public const string Extra = "2";
        }
    }
}
