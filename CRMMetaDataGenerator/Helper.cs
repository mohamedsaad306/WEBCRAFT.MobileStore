using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMMetaDataGenerator
{
    class Helper
    {

        public static List<SavedData> LoadSavedConnectionsData()
        {
            List<SavedData> DataList = new List<SavedData>();
            try
            {
                var Data = File.ReadAllLines("Data.txt").ToList();


                int SavedConnectionsCount = Data.Count/ 3;
                for (int i = 0; i < SavedConnectionsCount ; i++)
                {
                    var x = new SavedData();
                    x.Url = Data.Skip(i * 3).Take(3).ToList()[0];
                    x.UserName= Data.Skip(i * 3).Take(3).ToList()[1];
                    x.Password= Data.Skip(i * 3).Take(3).ToList()[2];
                    DataList.Add(x);
                }

            }
            catch (FileNotFoundException ex)
            {
                File.Create("Data.txt");


            }
            return DataList;

        }

    

        internal static void SaveConnection(string[] v)
        {
            File.AppendAllLines("Data.txt", v);
        }
    }
}
