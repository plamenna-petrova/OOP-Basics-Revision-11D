﻿using AnimalFarm.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AnimalFarm
{
    // Exercise: Access modifiers Task #2

    public class Program
    {
        static void Main(string[] args)
        {
            Type chickenType = typeof(Chicken);
            FieldInfo[] fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            Debug.Assert(fields.Where(f => f.IsPrivate).Count() == 2);
            Debug.Assert(methods.Where(m => m.IsPrivate).Count() == 1);

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);

            Console.WriteLine(
                "Chicken {0} (age {1}) can produce {2} eggs per day.",
                chicken.Name,
                chicken.Age,
                chicken.GetProductPerDay()
            );
        }
    }
}
