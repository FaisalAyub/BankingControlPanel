using MCN.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MCN.ServiceRep.BAL.Common
{
    public interface IJDataTableDataBL
    {
        object fnJModelFailed<T>(DataTableAjaxPostModel model);
        object fnJModelException<T>(DataTableAjaxPostModel model);
        object fnJFailed<T>(object bpco);
        object fnJException<T>(object bpco);
        object fnJDataTable(DataTable dt);
        object fnJDataSet(DataSet ds);
        object fnJDataTable(object bpco, DataTable dt);
        object fnJDataSet(object bpco, DataSet ds);
    }
}
