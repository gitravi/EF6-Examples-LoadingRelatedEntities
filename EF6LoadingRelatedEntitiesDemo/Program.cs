using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6LoadingRelatedEntitiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*  Pre-requisites:
                 *  => Before execution please change the connection string to your SQL Server Database.
                 *  => Restore nuget packages
                 */

                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SchoolContext context = new SchoolContext(connectionString))
                {
                    #region Print generated query to console
                    //context.Database.Log = (q) => Console.WriteLine(q);
                    #endregion

                    #region Lazy Loading
                    //var query = context.Standards.Include(b => b.Students);
                    #endregion

                    #region Eager Loading
                    //var query = context.Standards.Include(b => b.Students).ToList();
                    //int StandardCountFromSeed = 5;
                    //for (int i = 1; i <= StandardCountFromSeed; i++)
                    //{
                    //    var standard = query.FirstOrDefault(m => m.Id == i);
                    //    foreach (var student in standard.Students)
                    //    {
                    //        Console.WriteLine($"Student Id: {student.Id} , Name: {student.Name} ,Standard: {standard.Name}");
                    //    }
                    //}
                    #endregion

                    #region Explicit Loading
                    var _standard = context.Standards.FirstOrDefault(i => i.Id == 2);
                    context.Entry(_standard).Collection(s => s.Students).Load();
                    foreach (var student in _standard.Students)
                    {
                        Console.WriteLine($"Student Id: {student.Id} , Name: {student.Name} ,Standard: {_standard.Name}");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
