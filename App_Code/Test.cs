using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TimesheetSettingsForCurrentUser
{
    public string id { get; set; }
    public Tstimesheetsettingslist[] tsTimesheetSettingsList { get; set; }
}

public class Tstimesheetsettingslist
{
    public string id { get; set; }
    public string defaultLegalEntity { get; set; }
    public string legalEntity { get; set; }
    public string legalEntityName { get; set; }
    public int enableIntercompanyTimesheet { get; set; }
    public int useFavorites { get; set; }
    public int requireStartStopTime { get; set; }
    public int isCurrentUserAnApprover { get; set; }
    public int dayWeekStarts { get; set; }
    public int hideActivity { get; set; }
    public int hideCategory { get; set; }
    public int hideExtComments { get; set; }
    public int hideIntComments { get; set; }
    public int hideLineProperty { get; set; }
    public string periodId { get; set; }
    public object periodList { get; set; }
    public Resource[] resources { get; set; }
    public object[] customFields { get; set; }
    public string userLanguage { get; set; }
    public string preferredLocale { get; set; }
    public int visibilityCustomer { get; set; }
    public int visibilityCategory { get; set; }
    public int visibilityActivity { get; set; }
    public int visibilityLineProperty { get; set; }
    public int visibilityInternalComment { get; set; }
    public int visibilityExternalComment { get; set; }
    public int visibilitySalesTaxGroup { get; set; }
    public int visibilityItemSalesTaxGroup { get; set; }
}

public class Resource
{
    public string id { get; set; }
    public string legalEntity { get; set; }
    public long resourceRecId { get; set; }
    public string workerName { get; set; }
    public string personnelNumber { get; set; }
    public bool isCurrentUser { get; set; }
    public string periodId { get; set; }
    public Periodlist[] periodList { get; set; }
    public string defaultHourCategory { get; set; }
    public string defaultHourCategoryName { get; set; }
    public int requireStartStopTime { get; set; }
}

public class Periodlist
{
    public string id { get; set; }
    public int BillableHours { get; set; }
    public int NonBillableHours { get; set; }
    public int NormBillable { get; set; }
    public DateTime periodFrom { get; set; }
    public DateTime periodTo { get; set; }
    public int TotalHours { get; set; }
    public string UserId { get; set; }
}
