using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Bolnica.Model;
using System.IO;

namespace Bolnica.Repository
{
    public  class AutoIncrementRepository
    {
        String lokacija = @"..\..\..\Data\AutoIncrementId.txt";

        public List<int> getAll()
        {
            List<int> ids = new List<int>();
            string[] lines = System.IO.File.ReadAllLines(lokacija);
            foreach (String line in lines)
            {
                string[] fields = line.Split(',');
               int id = Convert.ToInt32(fields[0]);
                ids.Add(id);
            }
            return ids;
        }
        public void saveOne(AutoIncrement ai)
        {
            String noviRed = ai.id.ToString();
            StreamWriter write = new StreamWriter(lokacija, true);
            write.WriteLine(noviRed);

            write.Close();
        }
    }
}
