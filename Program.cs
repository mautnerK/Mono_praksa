using System;
using System.IO;
using System.Collections;
using Prvi_dan_mono;




Dog kia = new("kia", 20, 52.2, 'F');
Dog boy = new("boy", 35, 62.2, 'M');
Dog rex = new("rex", 45, 75.9, 'M');

Cat mia = new("mia", 11, 14.2, 'F');
Cat kio = new("kio", 13, 15.6, 'M');

Fish mirko = new("mirko", 1, 0.5);


Dictionary<string, Dog> dogDictionary=new Dictionary<string, Dog>();

dogDictionary.Add("kia", kia);
dogDictionary.Add("boy", boy);

if (!dogDictionary.ContainsKey("rex")) { 
    dogDictionary.Add("rex", rex);
    System.Console.WriteLine("added rex");
}

for (int index = 0; index < dogDictionary.Count; index++)
{
    var item = dogDictionary.ElementAt(index);
    var itemKey = item.Key;
    var itemValue = item.Value;
    System.Console.WriteLine(itemKey);
    itemValue.GetWeight();
 
}



ArrayList cats = new ArrayList();
cats.Add(mia);
cats.Add(kio);

foreach(Cat cat in cats)
{
    cat.GetWeight();
}


     
rex.GetWeight();
rex.Sound();
rex.GetWeight();



boy.Eat(11);
boy.GetWeight();


mirko.swim();

Console.ReadKey();
    
    