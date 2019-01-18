Imports System

Module Program
    Sub Main(args As String())
        'TASK 1 - INPUT ITEMS'
        'Dim itemName(9) As String
        'Dim itemDesc(9) As String
        'Dim itemReserve(9) As Decimal
        Dim itemHighestBid() As Decimal = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim userInput As String
        Dim exitBool As Boolean
        'For i = 0 To itemName.Length - 1
        '    Console.WriteLine("Please enter the name of the item you wish to sell.")
        '    itemName(i) = Console.ReadLine
        '    Console.WriteLine("Please enter the description of that item.")
        '    itemDesc(i) = Console.ReadLine
        '    Console.WriteLine("Please enter the reserve price.")
        '    itemReserve(i) = Console.ReadLine
        '    Console.WriteLine("Thank you, your item number is: {0}", i)
        '    Console.ReadLine()
        'Next

        'TASK 1 HARDCODE
        Dim itemName() As String = {"yeet", "meat", "leat", "peat", "seat", "beat", "heat", "neat", "teat", "wheat"}
        Dim itemDesc(9) As String
        For i = 0 To itemName.Length - 1
            itemDesc(i) = itemName(i) & " PLACEHOLDER DESCRIPTION"
        Next
        Dim itemReserve() As Decimal = {5, 5, 5, 5, 5, 5, 5, 5, 5, 5}



        Do
            Console.WriteLine("Welcome to the Quan auction! Where we sell items that rhyme with -eet")
            Console.WriteLine("Enter the item number that you wish to view:")
            userInput = Console.ReadLine
            Console.WriteLine("Name: {0}", itemName(userInput))
            Console.WriteLine("Description: {0}", itemDesc(userInput))
            Console.WriteLine("Reserve price: ${0}", itemReserve(userInput))
            Console.ReadLine()
        Loop Until exitBool
    End Sub
End Module
