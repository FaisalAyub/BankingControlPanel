using MCN.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common
{
    public class DataTableAjaxPostModelProcess<T>
    {
        public DataTableRequestModel<T> GetDataTableRequestModel(DataTableAjaxPostModel model)
        {
            DataTableRequestModel<T> _DataTableRequestModel = new DataTableRequestModel<T>();
            _DataTableRequestModel.draw = model.draw;
            _DataTableRequestModel.searchBy = (model.search != null) ? model.search.value : "";
            _DataTableRequestModel.take = model.length.ToString();
            _DataTableRequestModel.skip = model.start.ToString();
            _DataTableRequestModel.sortBy = "";
            _DataTableRequestModel.sortDir = true;
            if (model.order != null)
            {
                _DataTableRequestModel.dir = model.order[0].dir.ToLower();
                _DataTableRequestModel.sortBy = model.columns[model.order[0].column].data;
                _DataTableRequestModel.sortDir = model.order[0].dir.ToLower() == "asc";
                _DataTableRequestModel.sortColumnBy = _DataTableRequestModel.sortBy + " " + _DataTableRequestModel.dir;
            }
            if (_DataTableRequestModel.searchBy == null)
                _DataTableRequestModel.searchBy = "";
            return _DataTableRequestModel;
        }
    }
}
