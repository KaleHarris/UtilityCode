﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityScript : MonoBehaviour
{
    //this void is en example of parsing strings to double values
    public static void Main()
   {
      string[] values = { "1,304.16", "$1,456.78", "1,094", "152", 
                          "123,45 €", "1 304,16", "Ae9f" };
      double number;
      CultureInfo culture = null;
      
      foreach (string value in values) {
         try {
            culture = CultureInfo.CreateSpecificCulture("en-US");
            number = Double.Parse(value, culture);
            Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
         }   
         catch (FormatException) {
            Console.WriteLine("{0}: Unable to parse '{1}'.", 
                              culture.Name, value);
            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            try {
               number = Double.Parse(value, culture);
               Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
            }
            catch (FormatException) {
               Console.WriteLine("{0}: Unable to parse '{1}'.", 
                                 culture.Name, value);
            }
         }
         Console.WriteLine();
      }   
   }
   //this void converts strings to an int32 value
   public static void Main2()
   {
      string value = "1,304";
      int number;
      IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
      if (Int32.TryParse(value, out number))
         Console.WriteLine("{0} --> {1}", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'", value);
            
      if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands, 
                        provider, out number))
         Console.WriteLine("{0} --> {1}", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'", value);
   }
   //this void parses unicode to int32 values

   //using System;
   //using System.Globalization;
   public static void Main3()
   {
      string value;
      // Define a string of basic Latin digits 1-5.
      value = "\u0031\u0032\u0033\u0034\u0035";
      ParseDigits(value);

      // Define a string of Fullwidth digits 1-5.
      value = "\uFF11\uFF12\uFF13\uFF14\uFF15";
      ParseDigits(value);
      
      // Define a string of Arabic-Indic digits 1-5.
      value = "\u0661\u0662\u0663\u0664\u0665";
      ParseDigits(value);
      
      // Define a string of Bangla digits 1-5.
      value = "\u09e7\u09e8\u09e9\u09ea\u09eb";
      ParseDigits(value);
   }

   static void ParseDigits(string value)
   {
      try {
         int number = Int32.Parse(value);
         Console.WriteLine("'{0}' --> {1}", value, number);
      }   
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", value);      
      }     
   }
   //below is an example of a struct

   //a struct acts as sort of a lighter version of a class. you can define
   //its properties and then use them elsewhere in the code, as is such in Main4
   struct Point2D {
      public int X;
      public int Y;
      public void AddPoint(Point2D anotherPoint) {
         this.X = this.X + anotherPoint.X;
         this.Y = this.Y + anotherPoint.Y;
      }
   }
   public static void Main4() {
      Point2D myPoint = new Point2D();
      myPoint.X = 10;
      myPoint.Y = 20;
      Point2D anotherPoint = new Point2D();
      anotherPoint.X = 5;
      anotherPoint.Y = 15;
      myPoint.AddPoint(anotherPoint);
   }

   //a simple foreach loop I find myself using frequently. finds the smallest or largest item
   //in an collection if needed. a simple lightweight way to sort data, especially in arrays.
   int biggestVariable = 0;
   foreach (Type i in collection){
      if (i > biggestVariable){
         biggestVariable = i;
      }
   }
   
}
