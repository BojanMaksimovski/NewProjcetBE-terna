using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetTimeSheet(long employee_id, string client_id, string client_secret)//
    {
        var values = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "Host", "login.windows.net" },
                { "grant_type" , "client_credentials" },
                { "resource" , "00000015-0000-0000-c000-000000000000" },
                { "client_id" , client_id },
                { "client_secret" , client_secret }
            };
        string url = "https://login.windows.net/adacta-group.com/oauth2/token";
        HttpClient revokeToken = new HttpClient();
        var content = new FormUrlEncodedContent(values);
        var response = revokeToken.PostAsync(url, content).Result;

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;

            TokenResponse TokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
            

            System.DateTime ExpireDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            ExpireDate = ExpireDate.AddSeconds(Convert.ToDouble(TokenResponse.expires_on)).ToLocalTime();

            if (ExpireDate < DateTime.Now)
            {
                return "Token Expired";

            } else
            {

                string connString = @"Data Source=localhost;Initial Catalog=Demodb;User ID=carma;Password=carma123";
                string query = "select a.Timesheet_id,b.Employee_id,  b.Employee,convert(varchar, a.Work_week_start, 103) + '-' + convert(varchar, a.Work_week_end, 103) as Work_week,convert(varchar, a.Timesheet_period_start, 103) + '-' + convert(varchar, a.Timesheet_period_end, 103) as Timesheet_period,a.Approval_status , (select isnull(sum(isnull(Hours_Per_Day, 0)),0) from Timesheet_Lines c where a.Timesheet_id = c.Timesheet_id) as TimeSheetTotal from Timesheet a";
                query += " join Employee b on a.Employee_id = b.Employee_id";
                query += " where a.Employee_id = " + employee_id;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();

                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
                if (dataTable.Rows.Count > 0)
                {
                    Timesheet TimeSheetObject = new Timesheet();
                    TimeSheetObject.Timesheet_id = dataTable.Rows[0].Field<int>("Timesheet_id");
                    TimeSheetObject.Employee_id = dataTable.Rows[0].Field<long>("Employee_id");
                    TimeSheetObject.Employee_Name = dataTable.Rows[0].Field<string>("Employee");
                    TimeSheetObject.WorkWeek = dataTable.Rows[0].Field<string>("Work_Week");
                    TimeSheetObject.TimeshetPeriod = dataTable.Rows[0].Field<string>("Timesheet_period");
                    TimeSheetObject.Approval_status = dataTable.Rows[0].Field<string>("Approval_status");
                    TimeSheetObject.TimeSheetTotal = dataTable.Rows[0].Field<decimal>("TimeSheetTotal");
                    TimeSheetObject.Timesheet_Lines_List = new List<Timesheet_Lines>();



                    query = "select a.Timesheet_Lines_id, a.Timesheet_id, a.Legal,a.Customer_account,b.Customer_name,a.Project_id,c.Project_name,a.Activity_number,d.Activity_name,e.Category,a.EntryDate,a.Hours_Per_Day from Timesheet_Lines a";
                    query += " left join Customer b on a.Customer_account = b.Customer_account";
                    query += " left join Project c on c.Project_id = a.Project_id";
                    query += " left join Activity d on d.Activity_number = a.Activity_number";
                    query += " left join Category e on e.Category_id = a.Category_id";
                    query += " where a.Timesheet_id = " + TimeSheetObject.Timesheet_id;
                    conn = new SqlConnection(connString);
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    da = new SqlDataAdapter(cmd);
                    DataTable dataTableTimeshetLines = new DataTable();

                    da.Fill(dataTableTimeshetLines);
                    conn.Close();
                    da.Dispose();

                    if (dataTableTimeshetLines.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataTableTimeshetLines.Rows)
                        {
                            Timesheet_Lines Timesheet_LinesObject = new Timesheet_Lines();
                            Timesheet_LinesObject.Timesheet_Lines_id = dr.Field<int>("Timesheet_Lines_id");
                            Timesheet_LinesObject.Timesheet_id = dr.Field<int>("Timesheet_id");
                            Timesheet_LinesObject.Legal = dr.Field<string>("Legal");
                            Timesheet_LinesObject.Customer_account = dr.Field<string>("Customer_account");
                            Timesheet_LinesObject.Customer_name = dr.Field<string>("Customer_name");
                            Timesheet_LinesObject.Project_name = dr.Field<string>("Project_name");
                            Timesheet_LinesObject.Activity_number = dr.Field<string>("Activity_number");
                            Timesheet_LinesObject.Activity_name = dr.Field<string>("Activity_name");
                            Timesheet_LinesObject.Category = dr.Field<string>("Category");
                            Timesheet_LinesObject.EntryDate = dr.Field<DateTime>("EntryDate");
                            Timesheet_LinesObject.Hours_Per_Day = dr.Field<decimal>("Hours_Per_Day");
                            TimeSheetObject.Timesheet_Lines_List.Add(Timesheet_LinesObject);
                        }
                    }

                    
                    string JsonStr = JsonConvert.SerializeObject(TimeSheetObject);
                    return JsonStr;
                }
                return "";
            }
        }

        return "Authorization failed";

    }

}
