
using System;

public class FindOrCreateTimesheet
{
    public string id { get; set; }
    public long parmHeaderRecId { get; set; }
    public int parmHrsPerWeek { get; set; }
    public int parmNormBillable { get; set; }
    public DateTime parmPeriodFrom { get; set; }
    public DateTime parmPeriodTo { get; set; }
    public string parmStatus { get; set; }
    public int parmStatusEnum { get; set; }
    public string parmTimesheetLE { get; set; }
    public object[] tsLineDetailList { get; set; }
    public DateTime parmTimesheetModifiedTime { get; set; }
    public string parmTimesheetNbr { get; set; }
    public int parmTotalChargeableHours { get; set; }
    public int parmTotalNonChargeableHours { get; set; }
    public string parmWorkerName { get; set; }
    public string parmWorkerPosition { get; set; }
    public object[] customFields { get; set; }
    public bool isAssignedToCurrentUserForApproval { get; set; }
    public string submitterName { get; set; }
    public string lastWorkflowHeaderComment { get; set; }
    public string lastApprovalActionInfo { get; set; }
    public object[] messages { get; set; }
}
