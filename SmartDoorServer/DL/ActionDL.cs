﻿using SmartDoorServer.DL;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using SmartDoorServer.Entities;
using Action = SmartDoorServer.Entities.Action;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;



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
        public string detectFaces()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = "recognize_faces_image.py --encodings encodings.pickle --image examples/ example_01.png";
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    return result;
                }
            }
        }
        public List<Action> GetActionsByDates(DateTime fromDate, DateTime toDate)
        {
            List<Action> la=new List<Action>();
            SqlDataReader reader;
            using (SqlConnection cn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand("p_get_attandance_by_dates", cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@from_date", fromDate);
                cmd.Parameters.AddWithValue("@to_date", toDate);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Action a = new Action();
                    if(!reader.IsDBNull(2))
                        a.EmployeeId =reader.GetInt32(2);
                    if (!reader.IsDBNull(0))
                        a.Date =reader.GetDateTime(0);
                    if (!reader.IsDBNull(4))
                        a.StatusId =reader.GetInt32(4);
                    if (!reader.IsDBNull(5))
                        a.ActionTypeId =reader.GetInt32(5);
                    if (!reader.IsDBNull(6))
                        a.EnteringTypeId =reader.GetInt32(6);
                    la.Add(a);                   
                }
                cn.Close();
            }
            return la;
        }
    }
}
