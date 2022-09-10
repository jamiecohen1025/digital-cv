# CYBER 206 Summer 2022
# Restaurant Ordering Application
# Program by Francisco Lopez Laplace, Jamie Cohen, Mayank Saxena

# Program will ask user to order from four listed items. It will then calculate any potential discounts, calculate
# the time required to complete the order, and output all data in a receipt.
####################################################################################################################

from datetime import date
today = date.today()
tax = 0.0725


def menu(items):
    # to display the menu options and prices
    count = 1  # for displaying item number (called label below)
    print('*' * 45)
    print('Items                                  Price')
    for item in items:  # loop through the information of each item
        itemName = item[0].ljust(20, " ")  # pulls the name of the item and left justifies it amongst 20 characters
        price = formatPrice(item[1])  # formats price to $0.00
        price = price.rjust(11, " ")  # right adjusts so that decimals match up
        label = 'Item ' + str(count) # gets the item number value
        label = label.ljust(13, " ")
        print(f'{label}{itemName}{price}')
        count += 1
    print('*' * 45)


def formatPrice(price):
    # to format floats to look like prices
    return '$' + str('{:.2f}'.format(float(price)))  # with print a float with 2 decimal places and a $

def order(name):
    # to get client input for what they would like to order.
    orderMore = True  # for looping the code if they want to buy more items
    totalItems = ''  # string list to hold count of items ordered
    print(f"Hello {name}! What would you like to order?")
    while orderMore:
        errorCheck = True  # for getting right input for items ordered and amount
        errorCheck2 = True  # for getting right input of ordering again
        while errorCheck:
            try:
                itemPicked, amountPicked = map(int, input(
                    'Please enter the item number you wish to order and amount separted by a space (Item# Amount): ').split())
                if itemPicked > 0 and itemPicked < 5:  # makes sure the number entered is on the menu. Our menu will never have more than 4 items
                    errorCheck = False  # ends the loop
                else:
                    print('Please enter a number that corresponds with an item on the list.')
            except:
                print(
                    'Please enter the item number and the amount of that item you would like to order separated by a space.')
        totalItems = totalItems + (str(itemPicked) * int(
            amountPicked))  # adds the item number to the total items string the amount of times the item was ordered
        while errorCheck2:
            choice = input('would you like to order anything else? (y)es or (n)o? ')
            if choice.upper() == "Y" or choice.upper() == "N":  # used .upper() to allow for user to enter upper and lowercase letters
                if choice.upper() == "N":
                    print()
                    orderMore = False  # stop the menu program from looping again
                    errorCheck2 = False  # breaks out of the order again loop
                else:
                    print()
                    errorCheck2 = False  # breaks out of the order anything else error check loop. will repeat the orderMore loop.
            else:
                print('Please enter "y" for yes or "n" for no')
    return totalItems


def countItems(totalItemsOrdered):
    # total items are stored in a string. the number of items corresponds to the number of times the item number appears
    amountOfItems = [] # using list because order matters. The index -1 matches the item
    for menuItem in range(1, 5):
        amountOfItems.append(totalItemsOrdered.count(str(menuItem)))  # creates a list where the index corresponds with the item number - 1 and the value is the amount ordered
    return amountOfItems


def prepTime(items, orderedItems):
    # gets the total time it will take to prepare the items
    totalTime = 0
    countOfItems = countItems(orderedItems) # creates a list that
    for (amount, item) in zip(countOfItems, items):
        totalTime = totalTime + (amount * item[3]) # third index (fourth value) of items is the prep time
    return totalTime


def itemsSubtotal(items, orderedItems):
    # gets the total price per item and applies discount when applicable
    totalQuantityOrdered = countItems(orderedItems)
    count = 0
    subprice = [0,0,0,0] # list because order matters. index + 1 equals item number. Start with 4 zeros to represent the starting prices
    for item in items:
        if item[0] == "Sandwich" and totalQuantityOrdered[0] >= 5: # if the price being calculated is for the sandwich, apply a 10% discount to the total sandwich price if there are at least 5 sandwiches
            subprice[count] = totalQuantityOrdered[0] * items[0][1] * items[0][2]
        elif item[0] == "Salad" and totalQuantityOrdered[2] > 0: # if the price being calculated is for salads, if there is at least one soup, apply the salad discount (dont need to check for salad b/c discount * 0 = 0)
            subprice[count]  = totalQuantityOrdered[1] * items[1][1] * items[1][2]
        elif item[0] == "Soup" and totalQuantityOrdered[1] >= 1 and totalQuantityOrdered[0] > 1: # if the price being calculated is for soups, if there is a sandwich and one salad, apply the discount
            subprice[count]  = totalQuantityOrdered[2] * items[2][1] * items[2][2]
        else:
            subprice[count] = totalQuantityOrdered[count] * items[count][1] # if none of the discount requirements are met, take the price of the item times the quantity of the item to get the subtoal for that item.
        count += 1
    return subprice


def displaytime(time):
    # for separating hours and minutes
    hours = time // 60  # integer hours
    minutes = time % 60  # using modulo to get minutes less than 1 hour
    return (hours, minutes)


def displayReceipt(name, totalItemsOrdered, subtotalPrices, prepTime):
    # for displaying the final output of pricing and timing
    totalQuantityOrdered = countItems(totalItemsOrdered) # gets the quantity of each item ordered in a list
    count = 1
    totalPrice = 0
    hours, minutes = displaytime(prepTime) # gets the total time in a better format for display
    for subtotal in subtotalPrices:
        totalPrice = totalPrice + subtotal # finds the subtotal of all prices
    totalTax = tax * totalPrice
    totalPriceTaxed = totalPrice + totalTax # gets final price with tax

    # code to display
    print('*' * 50)
    print(f'{name}, thanks for your order')
    print()
    print('Items              qty             Price')
    for (quantity, price) in zip(totalQuantityOrdered, subtotalPrices): # loop over the quantities and prices list and display them
        quantity = str(quantity) # makes quantity a string for display
        quantity = quantity.ljust(10, " ") # left justify quantity and apply spacing
        price = formatPrice(price) # make price a stirng and apply money formatting
        price = price.rjust(10, " ") # right justify to match the cents place
        label = 'Item ' + str(count) # get the item number label
        label = label.ljust(20, " ")
        print(f'{label}{quantity}{price}') # display the indivdual parts on a single line
        count += 1
    print()

    # formatting the tax and total price for display
    totalTax = formatPrice(totalTax)
    totalPriceTaxed = formatPrice(totalPriceTaxed)
    totalTax = totalTax.rjust(21, " ")
    totalPriceTaxed = totalPriceTaxed.rjust(19, " ")

    # displaying end notes on receipt
    print(f"Tax{totalTax}")
    print(f"Total{totalPriceTaxed}\n")
    if hours == 0: # decided not to check for zero minutes because it adds more precision than zero hours does
        print(f'{today.strftime("%m/%d/%Y")}, Your order will be ready in {minutes} minutes') # to not print "0 hours"
    elif hours == 1:
        print(f'{today.strftime("%m/%d/%Y")}, Your order will be ready in {hours} hour\nand {minutes} minutes') # to not print plural hours. added a newline to make receipt look better (not run over)
    else:
        print(f'{today.strftime("%m/%d/%Y")}, Your order will be ready in {hours} hours\nand {minutes} minutes') # plural hours
    print('*' * 50)


def main():
    # Used tuples within a list because the index of items is used when comparing to total prices and total time but the characteristics of those items does not change
    # tuple order is ([name], [price], [1 - dicount], [prep time])
    items = [("Sandwich", 10, .90, 10), ("Salad", 8, .9, 8), ("Soup", 6, .8, 15), ("Coffee/Tea", 5, 1, 5)]

    orderAgain = True
    while orderAgain:
        errorCheck = True
        userName = input("Hello! What is your name? ")
        menu(items) # dispalys the menu
        orderedItems = order(userName) # allows the user to add to the order
        totalPrepTime = prepTime(items, orderedItems)
        subtotalPrices = itemsSubtotal(items, orderedItems)
        displayReceipt(userName, orderedItems, subtotalPrices, totalPrepTime)
        while errorCheck: # for checking if the user wants to place a new order
            again = input('Do you want to place another order? y for yes or n for no: ')
            print(again)
            if again.upper() == "Y":
                errorCheck = False # if yes, get out of the errorcheck loop and restart the order loop
            elif again.upper() == "N":
                errorCheck = False # if no, close all loops and end the program
                orderAgain = False
            else:
                print("Please enter y for yes or n for no.")


if __name__ == "__main__":
    main()
