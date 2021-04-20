using System;

namespace PracticeSharp
{
    public unsafe class Biztonsagtalan
    {

    void Trystuff<T>(ref T betu, Action<T> act, T masik){
    betu = masik;
    act(betu);
}
static void Cserelj <T>(ref T a, T b, Action<T> act)
{ 
    a = b;
    act(a);
}
    public static void DoUnsafeThings()
    {

    delegate* <ref char, char, Action<char>, void> funcpointer = &Cserelj;

    char a = 'm';
    char* b = &a;

    Here:
    if (*b is 'f')
        System.Console.WriteLine(*b);
    else{
       funcpointer(ref a,'f', a => System.Console.WriteLine($"Az a: {a}"));
        goto Here;

    }
        
    char another = a;
    System.Console.WriteLine(another);


    delegate* <ref int, int, Action<int>, void> funcintpointer = &Cserelj;
    int azta = 10;

    static void Cserelj2 (ref char a, char b) =>  a = b;
    delegate* <ref char, char, void> funcpointer2 = &Cserelj2;

       funcintpointer(ref azta, 30, azta => System.Console.WriteLine($"szam: {azta}"));

}
        
    }
}