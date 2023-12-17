using System;
using System.Collections.Generic; // Add this line to use List

public class CardHolder
{
	// Make properties private to encapsulate the class
	private string CardNum;
	private int pin;
	private string FirstName;
	private string LastName;
	private double balance;

	public CardHolder(string CardNum, string FirstName, string LastName, double balance, int pin)
	{
		this.CardNum = CardNum;
		this.FirstName = FirstName;
		this.LastName = LastName;
		this.balance = balance;
		this.pin = pin;
	}

	public string GetCardNum()
	{
		return CardNum;
	}

	public int GetPin()
	{
		return pin;
	}

	public string GetFirstName()
	{
		return FirstName;
	}

	public string GetLastName()
	{
		return LastName;
	}

	public double GetBalance()
	{
		return balance;
	}

	public void SetCardNum(string newcardnum)
	{
		CardNum = newcardnum;
	}

	public void SetPin(int newpin)
	{
		pin = newpin;
	}

	public void SetBalance(double newbalance)
	{
		balance = newbalance;
	}

	public void SetFirstName(string newFirstname)
	{
		FirstName = newFirstname;
	}

	public void SetLastName(string newlastname)
	{
		LastName = newlastname;
	}
}

class Program
{
	static void PrintOptions()
	{
		Console.WriteLine("Please choose from one of the following options..");
		Console.WriteLine("1. Deposit");
		Console.WriteLine("2. Withdraw");
		Console.WriteLine("3. Show Balance");
		Console.WriteLine("4. Exit");
	}

	static void Deposit(CardHolder cardholder)
	{
		Console.WriteLine("How much money would you like to deposit?");
		double deposit = double.Parse(Console.ReadLine());
		cardholder.SetBalance(cardholder.GetBalance() + deposit);
		Console.WriteLine("Thank you for your deposit. Your new balance is: " + cardholder.GetBalance());
	}

	static void Withdraw(CardHolder cardholder)
	{
		Console.WriteLine("How much money would you like to withdraw?");
		double withdraw = double.Parse(Console.ReadLine());
		if (cardholder.GetBalance() < withdraw)
		{
			Console.WriteLine("Insufficient balance :(");
		}
		else
		{
			cardholder.SetBalance(cardholder.GetBalance() - withdraw);
			Console.WriteLine("You are good to go.");
		}
	}

	static void ShowBalance(CardHolder cardholder)
	{
		Console.WriteLine("Current balance: " + cardholder.GetBalance());
	}

	static void Main(string[] args)
	{
		List<CardHolder> cardHolders = new List<CardHolder>
		{
			new CardHolder("23233232", "Baris", "Akgul", 8787, 2424),
			new CardHolder("55553232", "Ahmet", "Günes", 9987, 3434),
			new CardHolder("39393939", "can", "yılmaz", 1000, 5555),
			new CardHolder("99922233", "ceyhun", "yücel", 2222, 4343)
		};

		string debitCardNum = "";
		CardHolder currentUser;

		while (true)
		{
			Console.WriteLine("Please enter your card number: ");
			debitCardNum = Console.ReadLine();

			// Check if the card exists
			currentUser = cardHolders.Find(a => a.GetCardNum() == debitCardNum);

			if (currentUser != null)
			{
				break;
			}
			else
			{
				Console.WriteLine("Card not recognized. Please try again!");
			}
		}

		Console.WriteLine("Please enter your pin: ");
		int userPin = 0;

		while (true)
		{
			try
			{
				userPin = int.Parse(Console.ReadLine());

				if (userPin == currentUser.GetPin())
				{
					break;
				}
				else
				{
					Console.WriteLine("Pin not recognized. Please try again!");
				}
			}
			catch
			{
				Console.WriteLine("Pin not recognized. Please try again!");
			}
		}

		Console.WriteLine("Welcome " + currentUser.GetFirstName());

		int option = 0;

		do
		{
			PrintOptions();

			try
			{
				option = int.Parse(Console.ReadLine());
			}
			catch
			{
				// Handle invalid input
			}

			switch (option)
			{
				case 1:
					Deposit(currentUser);
					break;
				case 2:
					Withdraw(currentUser);
					break;
				case 3:
					ShowBalance(currentUser);
					break;
				case 4:
					break;
				default:
					Console.WriteLine("Invalid option. Please try again.");
					break;
			}
		}
		while (option != 4);

		Console.WriteLine("Thank you. Have a nice day!");
	}
}
