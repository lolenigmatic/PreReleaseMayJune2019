Imports System

Module Program
    Sub Main(args As String())
        'TASK 1 - INPUT ITEMS'
        'Dim itemName(9) As String
        'Dim itemDesc(9) As String
        'Dim itemReserve(9) As Decimal
        Dim itemHighestBid() As Decimal = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim itemBidCount() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim itemBuyerIDOfHighestBid(9) As String
        Dim userInput As String
        Dim currentItem As Integer
        Dim currentBuyerID As String
        Dim bidValid As Boolean = False
        Dim exitBidLoop As Boolean = False
        Dim exitBool As Boolean = False
        'For i = 0 To itemName.Length - 1
        '    Console.WriteLine("Please enter the name of the item you wish to sell.")
        '    itemName(i) = Console.ReadLine
        '    Console.WriteLine("Please enter the description of that item.")
        '    itemDesc(i) = Console.ReadLine
        '    Console.WriteLine("Please enter the reserve price.")
        '    itemReserve(i) = Console.ReadLine
        '    Console.WriteLine("Thank you, your item number is: {0}", i + 1)
        '    Console.ReadLine()
        'Next

        'TASK 1 HARDCODE
        Dim itemName() As String = {"yeet", "meat", "leat", "peat", "seat", "beat", "heat", "neat", "teat", "wheat"}
        Dim itemDesc(9) As String
        'Hard coding description
        For i = 0 To itemName.Length - 1
            itemDesc(i) = itemName(i) & " PLACEHOLDER DESCRIPTION"
        Next
        Dim itemReserve() As Decimal = {5, 5, 5, 5, 5, 5, 5, 5, 5, 5}

        'Task 2 - Buyer bids
        Do
            'Searching & viewing for items
            Console.WriteLine("Welcome to the Quan auction! Where we sell items that rhyme with -eet")
            Console.WriteLine("Enter the item number that you wish to view:")
            userInput = Console.ReadLine
            currentItem = userInput - 1
            'Displaying item info
            Console.WriteLine("Name: {0}", itemName(currentItem))
            Console.WriteLine("Description: {0}", itemDesc(currentItem))
            'Only shows highest bid if there has been a bid on the item.
            If itemHighestBid(currentItem) = 0 Then
                Console.WriteLine("Reserve price: ${0}", itemReserve(currentItem))
            Else
                Console.WriteLine("Current highest bid: ${0}", itemHighestBid(currentItem))
            End If
            Console.WriteLine("Would you like to make a bid for this item? (Type ""y"" or ""n""")
            userInput = Console.ReadLine
            'Setting bids
            If userInput = "y" Then
                'Input buyer ID and enter bid loop
                Console.WriteLine("Enter your buyer ID")
                currentBuyerID = Console.ReadLine
                Console.WriteLine("Enter your bid (enter 0 to cancel):")
                exitBidLoop = False
                Do
                    'Begin bid logic
                    userInput = Console.ReadLine
                    If userInput = "0" Then
                        '0 is cancel bid
                        exitBidLoop = True
                    ElseIf userInput > itemReserve(currentItem) And userInput > itemHighestBid(currentItem) Then
                        'If the above statements are true, the bid will be valid, and will be recorded.
                        itemBidCount(currentItem) += 1
                        itemHighestBid(currentItem) = userInput
                        itemBuyerIDOfHighestBid(currentItem) = currentBuyerID
                        Console.WriteLine("Bid successful!")
                        Console.WriteLine("Bid: ${0}", userInput)
                        Console.WriteLine("BuyerID: {0}", currentBuyerID)
                        exitBidLoop = True
                    Else
                        'Bid unsuccessful will ask for another input
                        Console.WriteLine("Bid cannot be lower than that of the reserve price or current highest bid.")
                        Console.WriteLine("Please enter a higher price or cancel the bid.")
                    End If

                Loop Until exitBidLoop
            Else
                'Exit
                Console.WriteLine("See you next time!")
            End If

        Loop Until exitBool
        Console.ReadLine()
    End Sub
End Module
