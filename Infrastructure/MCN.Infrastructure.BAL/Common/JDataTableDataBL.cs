using Newtonsoft.Json;
using MCN.Common;
using MCN.Common.AttribParam;
using MCN.Core.Entities.Common;
using MCN.ServiceRep.BAL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MCN.Infrastructure.BAL.Common
{
    public class JDataTableDataBL : IJDataTableDataBL
    {
        public object fnJModelFailed<T>(DataTableAjaxPostModel model)
        {
            try
            {
                Type tClass = typeof(T);
                DataTable dt = CollectionToDataTable.AsDataTableSchema(tClass);
                dynamic newtonresult = new
                {
                    draw = model.draw,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = dt,
                    success = false,
                    IsUser = false,
                    response = AttribConstants.Messages.Default.ListFailure
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJModelException<T>(DataTableAjaxPostModel model)
        {
            try
            {
                Type tClass = typeof(T);
                DataTable dt = CollectionToDataTable.AsDataTableSchema(tClass);
                dynamic newtonresult = new
                {
                    draw = model.draw,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = dt,
                    success = false,
                    IsUser = true,
                    response = AttribConstants.Messages.Default.ListFailure
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJFailed<T>(object bpco)
        {
            try
            {
                Type tClass = typeof(T);
                DataTable dt = CollectionToDataTable.AsDataTableSchema(tClass);
                dynamic newtonresult = new
                {
                    bpco = bpco,
                    data = dt,
                    success = false,
                    IsUser = false,
                    response = AttribConstants.Messages.Default.ListFailure
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJException<T>(object bpco)
        {
            try
            {
                Type tClass = typeof(T);
                DataTable dt = CollectionToDataTable.AsDataTableSchema(tClass);
                dynamic newtonresult = new
                {
                    bpco = bpco,
                    data = dt,
                    success = false,
                    IsUser = true,
                    response = AttribConstants.Messages.Default.ListFailure
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJDataTable(DataTable dt)
        {
            try
            {
                dynamic newtonresult = new
                {
                    data = dt
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJDataSet(DataSet ds)
        {
            try
            {
                dynamic newtonresult = new
                {
                    data = ds
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJDataTable(object bpco, DataTable dt)
        {
            try
            {
                dynamic newtonresult = new
                {
                    bpco= bpco,
                    data = dt
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        public object fnJDataSet(object bpco, DataSet ds)
        {
            try
            {
                dynamic newtonresult = new
                {
                    bpco = bpco,
                    data = ds
                };
                return newtonresult;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
