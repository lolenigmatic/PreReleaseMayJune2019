Imports System

Module Program
    Sub Main(args As String())
        'TASK 1 - INPUT ITEMS'
        'Dim itemName(9) As String
        'Dim itemDesc(9) As String
        'Dim itemReserve(9) As Decimal
        Dim itemHighestBid() As Decimal = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim itemBidCount() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim itemExceedsReservePrice() As Boolean = {False, False, False, False, False, False, False, False, False, False}
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
            Console.WriteLine("Current highest bid: ${0}", itemHighestBid(currentItem))
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
                    ElseIf userInput > itemHighestBid(currentItem) Then
                        'If the above statements are true, the bid will be valid, and will be recorded.
                        itemBidCount(currentItem) += 1
                        itemHighestBid(currentItem) = userInput
                        itemBuyerIDOfHighestBid(currentItem) = currentBuyerID
                        If itemHighestBid(currentItem) > itemReserve(currentItem) Then
                            itemExceedsReservePrice(currentItem) = True
                        End If
                        Console.WriteLine("Bid successful!")
                        Console.WriteLine("Bid: ${0}", userInput)
                        Console.WriteLine("BuyerID: {0}", currentBuyerID)
                        exitBidLoop = True
                    Else
                        'Bid unsuccessful will ask for another input
                        Console.WriteLine("Bid cannot be lower than that of the current highest bid.")
                        Console.WriteLine("Please enter a higher price or cancel the bid.")
                    End If

                Loop Until exitBidLoop
            Else
                'Exit
                Console.WriteLine("See you next time!")
            End If

            Console.WriteLine("Would you like to end the auction? (Type ""y"" or ""n""")
            userInput = Console.ReadLine

            If userInput = "y" Then
                exitBool = True
            End If
        Loop Until exitBool
        'TASK 3
        Console.WriteLine("The auction as now ended!")
        Console.WriteLine("Calculating auction summary...")
        Dim totalItemsSold As Integer = 0
        Dim totalItemsNotReachedReserve As Integer = 0
        Dim totalItemsNotBidded As Integer = 0
        Dim itemTotalFee(9) As Decimal
        For i = 0 To itemName.Length - 1
            Console.WriteLine("--------------------------------")
            Console.WriteLine("Item ID: {0}", i + 1)
            Console.WriteLine("Name: {0}", itemName(i))
            If itemExceedsReservePrice(i) Then
                Console.WriteLine("Status: SOLD")
                itemTotalFee(i) = itemHighestBid(i) * 1.1
                Console.WriteLine("Total Fee: {0}", itemTotalFee(i))
                totalItemsSold += 1
            ElseIf itemBidCount(i) > 0 Then
                Console.WriteLine("Status: NOT SOLD")
                Console.WriteLine("Reason: Has not reached reserve price")
                Console.WriteLine("Final Bid: {0}", itemHighestBid(i))
                totalItemsNotReachedReserve += 1
            Else
                Console.WriteLine("Status: NOT SOLD")
                Console.WriteLine("Reason: No bids received")
                totalItemsNotBidded += 1
            End If
        Next
        Console.WriteLine("-------------------------")
        Console.WriteLine("FINAL AUCTION SUMMARY")
        Console.WriteLine("Items sold: {0}", totalItemsSold)
        Console.WriteLine("Items not reached reserve price: {0}", totalItemsNotReachedReserve)
        Console.WriteLine("Items not bidded on: {0}", totalItemsNotBidded)
        Console.ReadLine()
    End Sub
End Module
