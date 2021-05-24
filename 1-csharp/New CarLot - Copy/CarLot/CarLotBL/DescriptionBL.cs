using System;
using System.Collections.Generic;
using CarLotDL;
using CarLotModels;

namespace CarLotBL
{
    public class DescriptionBL : IDescriptionBL
    {
        private IRepository _repo;
        public DescriptionBL(IRepository repo)
        {
            _repo = repo;
        }
        public Description AddDescription(Car car,Description description)
        {
            _repo.AddDescription(car, description);
            return description;
        }


        // public Tuple<List<Description>, int> GetDescriptions(Car car)
        // {
        //     List<Description> carDescriptions = _repo.GetDescriptions(car);
        //     int averageMpg = 0;
        //     carDescriptions.ForEach(description => averageMpg += description.Mpg);
        //     averageMpg = averageMpg / carDescriptions.Count;
        //     return new Tuple<List<Description>, int>(carDescriptions, averageMpg);
        // }
    }
}