﻿using PaternsImpl.AbsctractFactoryMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaternsImpl.AbsctractFactoryMethod.Products
{
    internal class MenTShirt : ITShirt, IClothes
    {
        public int Size { get ; set; }
        public string? BrandName { get; set ; }
        public string? Color { get ; set; }
        public string? MadeIn { get ; set; }

        public void AboutProduct()
        {
            Console.WriteLine("This is men t-shirt");
        }
    }
}
