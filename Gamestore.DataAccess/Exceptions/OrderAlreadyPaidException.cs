﻿namespace Gamestore.DataAccess.Exceptions;
public class OrderAlreadyPaidException : Exception
{
    public OrderAlreadyPaidException(string message = "This order is already paid!")
    : base(message)
    {
    }
}
