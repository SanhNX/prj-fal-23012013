using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    public class EmployeeBIZ
    {
        EmployeeDAL DAL = new EmployeeDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objEmployee> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objEmployee> lst = new List<objEmployee>();
                lst = DAL.GetEmployeeByPaging(pageIndex, pageSize, out result);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objEmployee> ShowAll()
        {
            try
            {
                List<objEmployee> lst = new List<objEmployee>();
                lst = DAL.GetEmployeeAll();
                
                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public objEmployee ShowByEmployeeByNameAndPass(string username, string password)
        {
            try
            {
                objEmployee obj = new objEmployee();
                obj = DAL.GetEmployeeByNameAndPass(username, password);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public objEmployee ShowEmployeeByID(int id)
        {
            try
            {
                objEmployee obj = new objEmployee();
                obj = DAL.GetEmployeeByID(id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdatePassword(int employeeID, string newPass)
        {
            try
            {
                int result = -1;

                if (employeeID != null && newPass != null)
                {
                    result = DAL.UpdatePassword(employeeID, newPass);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int UpdateFirstFlag(int employeeID)
        {
            try
            {
                int result = -1;

                if (employeeID != null)
                {
                    result = DAL.UpdateFirstFlag(employeeID);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// add new record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insert(objEmployee obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertEmployee(obj);
                }
                else
                {
                    result = -1;
                }

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// edit record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(objEmployee obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.UpdateEmployee(obj);
                }
                else
                {
                    result = 1;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Delete(objEmployee obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteEmployee(obj);
                }
                else
                {
                    result = 1;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean EmployeeGetByUserName(string username)
        {
            try
            {
                Boolean abc = false;

                if (username != null)
                {
                    abc = DAL.EmployeeGetByUserName(username);
                }

                return abc;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objEmployee> EmployeeSearch(string employeeName, int branchID, int role) {
            List<objEmployee> lstEmp = new List<objEmployee>();

            try
            {

                lstEmp = DAL.EmployeeSearch(employeeName, branchID, role);
            }
            catch (Exception)
            {

                throw;
            }

            return lstEmp;
        }
    }
}
