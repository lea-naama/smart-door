using SmartDoorServer.DL;
using System;
using System.Collections.Generic;
using Action = SmartDoorServer.Entities.Action;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;
using Entities;

namespace DL
{
    public class ActionDL : IActionDL
    {
        SmartDoorContext _smartDoorContext;
        string connection = "Server=DESKTOP-N50PQOJ;Database=SmartDoor;Trusted_Connection=True;";
        string dir = @"C:\Users\admin\Documents\finalProject\face_recognition_final_project";


        public ActionDL(SmartDoorContext smartDoorContext)
        {
            _smartDoorContext = smartDoorContext;
            try
            {
                Directory.SetCurrentDirectory(dir);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
        }
        
        public List<TableRow> GetActionsByDates(int id, DateTime fromDate, DateTime toDate)
        {
            List<TableRow> la=new List<TableRow>();
            SqlDataReader reader;
            List<string> daysWeak = new List<string>() { "ראשון", "שני", "שלישי", "רביעי", "חמישי", "שישי", "שבת" };
            using (SqlConnection cn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand("P_GET_EMPLOYEE_ATTENDENCE", cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@FROM_DATE", fromDate);
                cmd.Parameters.AddWithValue("@TO_DATE", toDate);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    if (!reader.IsDBNull(0))
                        tr.Date = reader.GetDateTime(0);
                    if (!reader.IsDBNull(1))
                        tr.DayWeak = daysWeak[reader.GetInt32(1)-1];
                    if (!reader.IsDBNull(2))
                        tr.ActionType = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        tr.EnteringType = reader.GetString(3);
                    if (!reader.IsDBNull(4))
                        tr.CheckIn1 = reader.GetString(4);
                    if (!reader.IsDBNull(5))
                        tr.CheckOut1 = reader.GetString(5);
                    if (!reader.IsDBNull(6))
                        tr.CheckIn2 = reader.GetString(6);
                    if (!reader.IsDBNull(7))
                        tr.CheckOut2 = reader.GetString(7);
                    if (!reader.IsDBNull(8))
                        tr.CheckIn3 = reader.GetString(8);
                    if (!reader.IsDBNull(9))
                        tr.CheckOut3 = reader.GetString(9);
                    if (!reader.IsDBNull(10))
                        tr.Total = reader.GetDecimal(10);
                    la.Add(tr);
                }
                cn.Close();
            }
            return la;
        }
    }
}
