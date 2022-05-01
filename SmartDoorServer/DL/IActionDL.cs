using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Action = SmartDoorServer.Entities.Action;
namespace DL
{
    public interface IActionDL
    {
        List<TableRow> GetActionsByDates(int id, DateTime fromDate, DateTime toDate);
    }
}