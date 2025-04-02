public ActionResult CalculateQuote(Insuree insuree)
{
    // Base price of $50 per month
    double quote = 50;

    // Add based on age
    if (insuree.Age <= 18)
    {
        quote += 100;
    }
    else if (insuree.Age >= 19 && insuree.Age <= 25)
    {
        quote += 50;
    }
    else if (insuree.Age >= 26)
    {
        quote += 25;
    }

    // Add based on car year
    if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
    {
        quote += 25;
    }

    // Add based on car make
    if (insuree.CarMake == "Porsche")
    {
        quote += 25;

        // If the car is a Porsche 911 Carrera, add an additional $25
        if (insuree.CarModel == "911 Carrera")
        {
            quote += 25;
        }
    }

    // Add based on speeding tickets
    quote += insuree.SpeedingTickets * 10;

    // Add 25% if the user has had a DUI
    if (insuree.HasDUI)
    {
        quote *= 1.25;
    }

    // Add 50% if the user wants full coverage
    if (insuree.IsFullCoverage)
    {
        quote *= 1.50;
    }

    // Store the calculated quote
    insuree.Quote = quote;

    // Return the view with the insuree object containing the calculated quote
    return View(insuree);
}
