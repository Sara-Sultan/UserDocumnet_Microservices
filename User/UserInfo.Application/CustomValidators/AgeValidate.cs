using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.CustomValidators
{
    public static class AgeValidate
    {
        public static bool AgeGreaterThan20(DateTime value)

        {

            DateTime now = DateTime.Today;

            int age = now.Year - Convert.ToDateTime(value).Year;



            if (age < 20)

            {

                return false;

            }

            else

            {

                return true;

            }

        }
    }
}
