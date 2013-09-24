using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class ExpensesBIZ
    {
        ExpensesDAL expensesDAL = new ExpensesDAL();

        public int InsertExpenses(objExpenses obj)
        {
            try{
                return expensesDAL.InsertExpenses(obj);
             }
            catch (Exception)
            {

                throw;
            }
        
        }

        public List<objExpenses> ExpensesSearch(int branchID, DateTime startDate, DateTime endDate)
        {
            try
            {
                return expensesDAL.ExpensesSearch(branchID, startDate, endDate);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
