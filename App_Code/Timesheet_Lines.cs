using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Timesheet_Lines
/// </summary>
public class Timesheet_Lines
{
    public Timesheet_Lines()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Timesheet_Lines_id { get; set; }
    public int Timesheet_id { get; set; }
    public string Legal { get; set; }
    public string Customer_account { get; set; }
    public string Customer_name { get; set; }
    public string Project_name { get; set; }
    public string Activity_number { get; set; }
    public string Activity_name { get; set; }
    public string Category { get; set; }
    public DateTime EntryDate { get; set; }
    public decimal Hours_Per_Day { get; set; }

}