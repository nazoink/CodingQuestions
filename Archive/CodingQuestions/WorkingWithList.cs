using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestions
{
    public class DataObjectOne
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
    public class DataObjectTwo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
    public class WorkingWithList
    {
        //Async
        //public async Task<DataObjectTwo> WorkingWithList(DataObjectOne currentData, List<DataObjectTwo> dataObjects) {

        //    //Filter dataObjects based on name fields
        //    List<DataObjectTwo> dataResults = dataObjects.Where(r => r.Name == currentData.Name).ToList();

        //    //from the results log matches based on two contraints (contains description == desctriptionKey and the other starts with Name == Name)
            


        //    // return first match from the remaining list of matches
        //    return dataObjects.First();
        //}
    }
}
