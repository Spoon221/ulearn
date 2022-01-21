static double Calculate(string userInput)
{
	var temporaryStr = userInput.Split();
    var sum = Convert.ToDouble(temporaryStr[0]);
    var interestRate = Convert.ToDouble(temporaryStr[1]);
    var termOwnMonths = Double.Parse(temporaryStr[2]);
    return sum * Math.Pow(1 + interestRate / 1200, termOwnMonths);
}