using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Action = SmartDoorServer.Entities.Action;
namespace DL
{
    public interface IActionDL
    {
        List<Action> GetActionsByDates(DateTime fromDate, DateTime toDate);
         string detectFaces();
    }
}