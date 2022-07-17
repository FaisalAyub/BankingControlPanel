using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MCN.Core.Entities.Common
{
    public class DataTableRequestModel<T>
    {
        public int draw { get; set; }
        public string searchBy { get; set; }
        public string take { get; set; }
        public string skip { get; set; }
        public string sortBy { get; set; }
        public bool sortDir { get; set; }
        public string sortColumnBy { get; set; }
        public string dir { get; set; }
        public int filteredResultsCount { get; set; }
        public int totalResultsCount { get; set; }
        public DataTable dt { get; set; }
        public DataSet ds { get; set; }
    }
}
