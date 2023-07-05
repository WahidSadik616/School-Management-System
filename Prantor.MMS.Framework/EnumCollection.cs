using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Framework
{
    public static class EnumCollection
    {
        public enum UserTypeEnum
        {
            OtherUsers,
            Admin,
            SuperAdmin,
            MadrasaMember
        }

        public enum UserStatusEnum
        {
            Active,
            Pending,
            Inactive
        }

        public enum GenderEnum
        {
            Male,
            Female
        }

        public enum BloodGroupEnum
        {
            APos,
            ANeg,
            BPos,
            BNeg,
            ABPos,
            ABNeg,
            OPos,
            ONeg
        }

        public enum SubjectTypeEnum
        {
            Theory,
            Practical
        }


        public enum WeekNameEnum
        {
            Saturday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

      
        public static List<EnumDetail> GetEnumList(Type enumType)
        {
            var list = new List<EnumDetail>();
            var values= Enum.GetValues(enumType);
            int i = 0;
            foreach(var v in values)
            {
                list.Add(new EnumDetail() 
                {
                    ID=i,
                    Name=v.ToString()
                });
                i++;
            }
            return list;
        }
    }

    public class EnumDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
