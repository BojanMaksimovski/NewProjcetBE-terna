using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Timesheet
/// </summary>
public class Timesheet
{
    public Timesheet()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public int Timesheet_id { get; set; }
    public long Employee_id { get; set; }
    public string Employee_Name { get; set; }
    public string TimeshetPeriod { get; set; }
    public string WorkWeek { get; set; }
    public string Approval_status { get; set; }
    public decimal TimeSheetTotal { get; set; }
    public List<Timesheet_Lines> Timesheet_Lines_List { get; set; }//= new List<Timesheet_Lines>();// 

}