using System;
using System.Net.Http;
using System.Threading.Tasks;
//void Csere (ref char q) => q = '#';
Func<char,char> CserFunc = (char v) => v ='#';
Action<char> Valami = sz => sz = '&';

async Task<string> GettingStuff(){
    using var client = new HttpClient();
    return await client.GetStringAsync("https://raw.githubusercontent.com/CsharptutorialHungary/stepintonet5/main/Peldak/PatternMatch/PatternMatch.csproj");
};

char a = 'c';   

unsafe
{
    char* b = &a;
    Here:
    if (*b == '#')
        System.Console.WriteLine(*b);
    else{
        //Csere(ref a);
        Valami(a);
        System.Console.WriteLine($"az a: {a}");
     a = CserFunc(a);
        goto Here;
    }
}
char wq = a;
System.Console.WriteLine(wq);

string szoveg = await GettingStuff();
System.Console.WriteLine(szoveg);


var hg = await Task<string>.Run(async () => 
{using var client = new HttpClient();
return await client.GetStringAsync("https://raw.githubusercontent.com/CsharptutorialHungary/stepintonet5/main/Peldak/NullableRef/Nullable.cs");
 });

 System.Console.WriteLine(hg);

 Func<Task<string>> AFunc = async () => 
{using var client = new HttpClient();
return await client.GetStringAsync("https://raw.githubusercontent.com/CsharptutorialHungary/stepintonet5/main/Peldak/NullableRef/NullableRef.csproj");
 };

 var res = await AFunc();
 System.Console.WriteLine(res);




/*
var array = new byte[100];
var arraySpan = new Span<byte>(array);

byte data = 0;
for (int ctr = 0; ctr < arraySpan.Length; ctr++)
    arraySpan[ctr] = data++;

int arraySum = 0;
foreach (var value in array)
    arraySum += value;

Console.WriteLine($"The sum is {arraySum}");


byte data2 = 0;
Span<byte> stackSpan2 = stackalloc byte[150];
for (int ctr = 0; ctr < stackSpan2.Length; ctr++)
    stackSpan2[ctr] = data2++;

int stackSum2 = 0;
foreach (var value in stackSpan2)
    stackSum2 += value;

Console.WriteLine($"The sum is {stackSum2}");


  System.Func<char,char,char> e = (char x, char a)=> x = a;



Fizzbuzz();



void Fizzbuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        StringBuilder sb = new StringBuilder("",8);
        if (i%3 == 0){ sb.Append("Fizz");}
        if (i%5 == 0){ sb.Append("Buzz");}
        
        if (sb.Length == 0)
        {sb.Append($"{i}");}
        System.Console.WriteLine(sb);
    }
}



*/
/*using System;
using System.Collections.Generic;
using PracticeSharp;
using System.Linq;

Console.WriteLine("Hello World!");
List<Jarmu> Vehicles = Jarmu.Readin("jarmu.txt");
Jarmu.HowManyHours(Vehicles);
Jarmu.FirstCars(Vehicles);
Jarmu.BKM(Vehicles);
Jarmu.FindVehicle(Vehicles);


List<int> intList = new List<int>();
        intList.Add(5);
        intList.Add(10);
        intList.Add(64);
        intList.Add(15);
        intList.Add(46);

int indexMax
    = !intList.Any() ? -1 :
    intList
    .Select( (value, index) => new { Value = value, Index = index } )
    .Aggregate( (a, b) => (a.Value > b.Value) ? a : b )
    .Index;

int maxindex = intList.Where(x => x.IndexOf)

System.Console.WriteLine(indexMax);*/