using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;


namespace StoreBL
{
    public class CustBL : ICustBL
    {
        private IRepository _repo;
        public CustBL(IRepository repo)
        {
            _repo = repo;
        }

        // public Cust AddCust(Cust cust)
        // {
        //     if(_repo.GetCust(cust)!=null)
        //     {
        //         throw new Exception("Customer already exists");
        //     }
        //     return _repo.AddCust(cust);
        // }
        // public List<Cust> GetAllCusts()
        // {
        //     return _repo.GetAllCusts();
        // }

    }
}
