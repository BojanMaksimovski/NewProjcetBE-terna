
using System;

public class TimesheetDetailsByNumber
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
    public Tslinedetaillist[] tsLineDetailList { get; set; }
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
    public object messages { get; set; }
}

public class Tslinedetaillist
{
    public string id { get; set; }
    public string parmActivityName { get; set; }
    public int parmApprovalStatusEnum { get; set; }
    public string parmCategoryName { get; set; }
    public int parmCostPrice { get; set; }
    public int parmDefaultDimension { get; set; }
    public string parmCurrencyCode { get; set; }
    public bool parmEditLines { get; set; }
    public DateTime parmEntryDate { get; set; }
    public string parmExtComment { get; set; }
    public int parmHrsPerDay { get; set; }
    public string parmIntComment { get; set; }
    public string parmLegalEntity { get; set; }
    public string parmLinePropertyId { get; set; }
    public DateTime parmPeriodFrom { get; set; }
    public DateTime parmPeriodTo { get; set; }
    public string parmProjActivityNumber { get; set; }
    public string parmProjCategoryId { get; set; }
    public string parmProjectDataAreaId { get; set; }
    public string parmProjId { get; set; }
    public string parmProjName { get; set; }
    public int parmSalesPrice { get; set; }
    public long parmResource { get; set; }
    public DateTime parmTimesheetLineModifiedTime { get; set; }
    public long parmTimesheetLineRecId { get; set; }
    public int parmTimesheetLineRecVersion { get; set; }
    public string parmTimesheetNumber { get; set; }
    public int parmTimesheetTransRecVersion { get; set; }
    public long parmTimesheetTransRecId { get; set; }
    public int parmToBeInvoiced { get; set; }
    public string projectCustName { get; set; }
    public string projectCustAccount { get; set; }
    public DateTime timeFrom { get; set; }
    public DateTime timeTo { get; set; }
    public string taxGroup { get; set; }
    public string taxItemGroup { get; set; }
    public object[] customFields { get; set; }
    public bool isAssignedToCurrentUserForApproval { get; set; }
}
