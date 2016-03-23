using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminator
{
    class SystemMessage
    {

        public static bool firstScript = true;

        static public DataTable SelectRecord(string FileName, bool backupTable = false)
        {
            FileName = ValidateFilename(FileName);
            string sql = "SELECT MsgId, MessageDesc FROM systemmessage WHERE FILENAME = '" + FileName + "'";
            if (backupTable)
                sql = "SELECT MsgId, MessageDesc FROM systemmessage1 WHERE FILENAME = '" + FileName + "'";
            SqlConnection conn = InitSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            da.Dispose();
            conn.Close();
            return dt;
        }

        static public string GetMessageCount(string FileName)
        {
            FileName = ValidateFilename(FileName);
            string sql = "SELECT COUNT(*) FROM systemmessage WHERE FILENAME = '" + FileName + "'"; ;
            SqlConnection conn = InitSqlConnection();
            SqlCommand command = new SqlCommand(sql, conn);
            return command.ExecuteScalar().ToString();
        }

        static public void InsertRecord(string FileName, string MsgId, string Message)
        {
            FileName = ValidateFilename(FileName);
            string sql = "INSERT INTO SystemMessage (MsgId, MessageDesc, MessageText, FileName, CreatedBy) " +
                "VALUES ('" + MsgId + "', '" + Message + "', '" + Message + "', '" + FileName + "', 'Terminator')";
            ExecuteSql(sql);
        }

        static public void DeleteRecord(string FileName, string MsgId, bool backup = false)
        {
            FileName = ValidateFilename(FileName);
            string sql = "DELETE FROM SystemMessage WHERE FileName = '" + FileName + "' AND MsgId = '" + MsgId + "'";

            if (backup)
                sql = "DELETE FROM SystemMessage1 WHERE FileName = '" + FileName + "' AND MsgId = '" + MsgId + "'";
            ExecuteSql(sql);
        }

        static public void ModifyRecord(string FileName, string MsgId, string Message)
        {
            DeleteRecord(FileName, MsgId);
            InsertRecord(FileName, MsgId, Message);
        }

        static public SqlConnection InitSqlConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "AZDEV1";
            builder["User Id"] = "wwdba";
            builder["Password"] = "sysadmin";
            builder["initial catalog"] = "azzier";
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return conn;
        }

        static void ExecuteSql(string sql)
        {
            SqlConnection conn = InitSqlConnection();
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            RecordDatabaseScripts(sql);
        }

        static void RecordDatabaseScripts(string sql)
        {
            if (!Directory.Exists("database"))
                Directory.CreateDirectory("database");
            if (firstScript)
            {
                File.AppendAllText("database\\scripts.txt", Environment.NewLine + "#" + DateTime.Now.ToString() + Environment.NewLine);
                firstScript = false;
            }
            File.AppendAllText("database\\scripts.txt", sql + Environment.NewLine);
        }

        public static string ValidateFilename(string fileName)
        {
            if (fileName.EndsWith(".cs"))
                fileName = fileName.Remove(fileName.Length - 3);
            return fileName;
        }

        public static List<string> getProblemFiles()
        {
            return new List<string>()
            {
                "Admin/Addmember.aspx".ToLower(),
"Admin/AdminChgStatus.aspx".ToLower(),
"Admin/AutoNum.aspx".ToLower(),
"Admin/Divdefault.aspx".ToLower(),
"Admin/Division.aspx".ToLower(),
"Admin/eula.aspx".ToLower(),
"Admin/Exchrate.aspx".ToLower(),
"Admin/FieldLabel.aspx".ToLower(),
"Admin/Optsel.aspx".ToLower(),
"Admin/screenexport.aspx".ToLower(),
"Admin/screenimport.aspx".ToLower(),
"Admin/ScreenSetup.aspx".ToLower(),
"Admin/statuslist.aspx".ToLower(),
"Admin/TextLabel.aspx".ToLower(),
"Admin/userrightsmain.aspx".ToLower(),
"Codes/admindivlist.aspx".ToLower(),
"Codes/admindivmain.aspx".ToLower(),
"Codes/approvalist.aspx".ToLower(),
"Codes/approvalmain.aspx".ToLower(),
"Codes/codemain.aspx".ToLower(),
"Codes/compremarklist.aspx".ToLower(),
"Codes/districtlist.aspx".ToLower(),
"Codes/divtaxmain.aspx".ToLower(),
"Codes/emailnotifylist.aspx".ToLower(),
"Codes/fieldlist.aspx".ToLower(),
"Codes/inventorystoreroom.aspx".ToLower(),
"Codes/ItemInvlist.aspx".ToLower(),
"Codes/labtypelist.aspx".ToLower(),
"Codes/linkslist.aspx".ToLower(),
"Codes/manufacturerlist.aspx".ToLower(),
"Codes/map.aspx".ToLower(),
"Codes/positionlist.aspx".ToLower(),
"Codes/reqlist.aspx".ToLower(),
"Codes/routelist.aspx".ToLower(),
"Codes/shiptolist.aspx".ToLower(),
"Codes/specframe.aspx".ToLower(),
"Codes/tablelist.aspx".ToLower(),
"Codes/tasklibrary.aspx".ToLower(),
"Codes/tasklist.aspx".ToLower(),
"Codes/termlist.aspx".ToLower(),
"Codes/UploadLogo.aspx".ToLower(),
"Codes/wolist.aspx".ToLower(),
"Codes/wotypemain.aspx".ToLower(),
"emailnotify/emailnotifymain.aspx".ToLower(),
"emailnotify/recipient.aspx".ToLower(),
"emailnotify/sendemail.aspx".ToLower(),
"Equipment/equipmentspecs.aspx".ToLower(),
"Equipment/measuremententry.aspx".ToLower(),
"Equipment/meterentry.aspx".ToLower(),
"Equipment/partdetail.aspx".ToLower(),
"Equipment/pdmwolist.aspx".ToLower(),
"Interface/infmain.aspx".ToLower(),
"Interface/infmap.aspx".ToLower(),
"inventory/alternatepart.aspx".ToLower(),
"inventory/alternatepartmain.aspx".ToLower(),
"inventory/checkrequesteditem.aspx".ToLower(),
"inventory/editissue.aspx".ToLower(),
"inventory/invissue.aspx".ToLower(),
"inventory/invlot.aspx".ToLower(),
"inventory/invlotlist.aspx".ToLower(),
"inventory/invspecs.aspx".ToLower(),
"inventory/invvendor.aspx".ToLower(),
"inventory/issuebatchlist.aspx".ToLower(),
"inventory/issuereserve.aspx".ToLower(),
"inventory/openpo.aspx".ToLower(),
"inventory/return.aspx".ToLower(),
"inventory/returndetail.aspx".ToLower(),
"inventory/serializedeqplist.aspx".ToLower(),
"inventory/stagingissue.aspx".ToLower(),
"inventory/storemain.aspx".ToLower(),
"inventory/transfer.aspx".ToLower(),
"inventory/whereused.aspx".ToLower(),
"Location/locationmodify.aspx".ToLower(),
"PdM/pdmhistory.aspx".ToLower(),
"PdM/pdmwolist.aspx".ToLower(),
"PM/nestedpm.aspx".ToLower(),
"Proc/procaccounts.aspx".ToLower(),
"Proc/Procheader.ascx".ToLower(),
"Project/projecthistory.aspx".ToLower(),
"Project/projectmain.aspx".ToLower(),
"Project/projectphase.aspx".ToLower(),
"Project/projectstatus.aspx".ToLower(),
"Project/wolist.aspx".ToLower(),
"Purchase/addrequesttopo.aspx".ToLower(),
"Purchase/changevendor.aspx".ToLower(),
"Purchase/generatepo.aspx".ToLower(),
"Purchase/generatepolist.aspx".ToLower(),
"Purchase/invoicemain.aspx".ToLower(),
"Purchase/newpoitem.aspx".ToLower(),
"Purchase/newposervice.aspx".ToLower(),
"Purchase/poaccounts.aspx".ToLower(),
"Purchase/pohistory.aspx".ToLower(),
"Purchase/poinvoices.aspx".ToLower(),
"Purchase/polinedetail.aspx".ToLower(),
"Purchase/polineservice.aspx".ToLower(),
"Purchase/pomain.aspx".ToLower(),
"Purchase/popanel.aspx".ToLower(),
"Purchase/postatus.aspx".ToLower(),
"querybuilder/querydetail.aspx".ToLower(),
"querybuilder/querymain.aspx".ToLower(),
"Receiving/newequipment.aspx".ToLower(),
"Receiving/receiveline.aspx".ToLower(),
"Receiving/returnfromlist.aspx".ToLower(),
"Receiving/returnvendor.aspx".ToLower(),
"Receiving/serialized.aspx".ToLower(),
"reportbuilder/aliaslist.aspx".ToLower(),
"reportbuilder/chartelement.aspx".ToLower(),
"reportbuilder/formatstring.aspx".ToLower(),
"reportbuilder/linkedreport.aspx".ToLower(),
"reportbuilder/rptdetail.aspx".ToLower(),
"reportbuilder/rptmain.aspx".ToLower(),
"Requisition/keyrequest.aspx".ToLower(),
"requisition/reqaccounts.aspx".ToLower(),
"Requisition/reqhistory.aspx".ToLower(),
"Requisition/reqitem.aspx".ToLower(),
"Requisition/reqmain.aspx".ToLower(),
"Requisition/reqpanel.aspx".ToLower(),
"Requisition/reqservice.aspx".ToLower(),
"Requisition/reqstatus.aspx".ToLower(),
"Route/detailorder.aspx".ToLower(),
"Route/readings.aspx".ToLower(),
"Route/routeheader.ascx".ToLower(),
"Route/routemain.aspx".ToLower(),
"scheduler/labourScheduler.aspx".ToLower(),
"scheduler/mainScheduler.aspx".ToLower(),
"scheduler/mySchedule.aspx".ToLower(),
"StoreRoom/multipleissue.aspx".ToLower(),
"StoreRoom/srmain.aspx".ToLower(),
"Timecards/tcmain.aspx".ToLower(),
"Timecards/tcpanel.aspx".ToLower(),
"Util/LinkDocdiv.aspx".ToLower(),
"Util/LinkDocFrame.aspx".ToLower(),
"Util/LinkDocMain.aspx".ToLower(),
"Util/specificationsframe.aspx".ToLower(),
"Util/UserQueryMain.aspx".ToLower(),
"vendor/vendorcontacts.aspx".ToLower(),
"vendor/vendoritem.aspx".ToLower(),
"vendor/vendorsrvc.aspx".ToLower(),
"vendor/vendortree.aspx".ToLower(),
"workorder/ActService.aspx".ToLower(),
"workorder/assignwr.aspx".ToLower(),
"workorder/cancelworelatewr.aspx".ToLower(),
"workorder/relatewr.aspx".ToLower(),
"workorder/woaccounts.aspx".ToLower(),
"workorder/wrlist.aspx".ToLower(),
"workorder/wrrelation.aspx".ToLower(),
"workrequest/relatewo.aspx".ToLower(),
"workrequest/wrheader.ascx".ToLower(),
"workrequest/wrhistory.aspx".ToLower(),
"workrequest/wrmain.aspx".ToLower()
            };
        }
    }

}
