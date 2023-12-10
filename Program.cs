using System;

public class CardHolder
{
	String CardNum;
	int pin;
	String FirstName;
	String LastName;
	double balance;
	public CardHolder(String CardNum, String FirstName, String LastName, double balance, int pin)
	{
		this.CardNum = CardNum;
		this.FirstName = FirstName;
		this.LastName = LastName;
		this.balance = balance;
		this.pin = pin;

	}
}