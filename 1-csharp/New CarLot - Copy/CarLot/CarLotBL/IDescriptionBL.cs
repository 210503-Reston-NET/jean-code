using CarLotModels;
using System;
using System.Collections.Generic;
namespace CarLotBL
{
    public interface IDescriptionBL
    {
        Description AddDescription(Car car, Description description);

        // Description GetDescription(Description description);
        // Tuple<List<Description>, int> GetDescriptions(Description description);
    }
}