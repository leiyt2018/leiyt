using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
namespace coreOfJLUCheckIn
{
    public class JluCheckIn
    {


        static string server = "https://vpns.jlu.edu.cn";
        static string referer = "https://vpns.jlu.edu.cn/login";
        static string contentType = "application/x-www-form-urlencoded";
        public static int checkIn(string room, string username, string passwd)
        {
            string date = DateTime.Now.ToShortDateString().ToString();
            string[] dateSplit = date.Split('/');
            string today = dateSplit[2];
            string studentNumber = "";
            string department = "";
            string cls = "";
            string[] JluVpnCookie = new string[4];
            string jluVpnCookie = "";
            string header = "";
            string studentName = "";

            //开始打卡  by leiyt
            try
            {
                //获取vpn登录页，并保存cookie   wengine_vpn_ticke=
                string html = GetHtml("https://vpns.jlu.edu.cn/login", out jluVpnCookie);
                JluVpnCookie[0] = jluVpnCookie.Split(';')[0];

                //发送登录请求
                string url1 = "https://vpns.jlu.edu.cn/do-login?local_login=true";
                string postData = "auth_type=local&username=" + username + "&sms_code=&password=" + passwd;
                html = GetHtml(url1, postData, JluVpnCookie, out header);

                //获取“健康状况申报”页面，同时记录下pid
                string htmlWithPid = GetHtml("https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5f" +
                               "f40902b7e625c6b468ca88d1b203b/jlu_portal/index?wrdrecordvisit=rec" +
                               "ord", JluVpnCookie, out header);

                //发送数据包获取Jsession 与 rout
                string timeStamp = GetTimeStamp(false);
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff4090" +
                          "2b7e625c6b468ca88d1b203b/infoplus/login?retUrl=https%3A%2F%2Fehall.jlu" +
                          ".edu.cn%2Finfoplus%2Foauth2%2Fauthorize%3Fx_redirected%3Dtrue%26scope%" +
                          "3Dprofile%2Bprofile_edit%2Bapp%2Btask%2Bprocess%2Bsubmit%2Bprocess_edi" +
                          "t%2Bsys_triple%2Btriple%2Bsys_profile%2Btriple%2Bsys_triple_edit%2Bsys" +
                          "_app%2Bstats%2Bsys_stats%26response_type%3Dcode%26redirect_uri%3Dhttps" +
                          "%253A%252F%252Fehall.jlu.edu.cn%252Fjlu_portal%252Fwall%252Fendpoint%2" +
                          "53FretUrl%253Dhttps%25253A%25252F%25252Fehall.jlu.edu.cn%25252Fjlu_por" +
                          "tal%25252Findex%26client_id%3D679e3d8a-a8b9-424e-859a-7e25ac760a74&cod" +
                          "e=c12ecc4038cf096570222ff003aa165f&state=93690d";
                GetHtml("https://vpns.jlu.edu.cn/wengine-vpn/cookie?method=get&host=ehall.jlu.edu" +
                        ".cn&scheme=https&path=/sso/login&vpn_timestamp=" + timeStamp, JluVpnCookie, out header);

                //通过“统一身份认证”
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff4090" +
                    "2b7e625c6b468ca88d1b203b/sso/login?x_started=true&redirect_uri=https%3A%2F%2" +
                    "Fehall.jlu.edu.cn%2Fsso%2Foauth2%2Fauthorize%3Fscope%3Dopenid%26response_typ" +
                    "e%3Dcode%26redirect_uri%3Dhttps%253A%252F%252Fehall.jlu.edu.cn%252Finfoplus%" +
                    "252Flogin%253FretUrl%253Dhttps%25253A%25252F%25252Fehall.jlu.edu.cn%25252Fin" +
                    "foplus%25252Foauth2%25252Fauthorize%25253Fx_redirected%25253Dtrue%252526scop" +
                    "e%25253Dprofile%25252Bprofile_edit%25252Bapp%25252Btask%25252Bprocess%25252B" +
                    "submit%25252Bprocess_edit%25252Bsys_triple%25252Btriple%25252Bsys_profile%25" +
                    "252Btriple%25252Bsys_triple_edit%25252Bsys_app%25252Bstats%25252Bsys_stats%2" +
                    "52526response_type%25253Dcode%252526redirect_uri%25253Dhttps%2525253A%252525" +
                    "2F%2525252Fehall.jlu.edu.cn%2525252Fjlu_portal%2525252Fwall%2525252Fendpoint" +
                    "%2525253FretUrl%2525253Dhttps%252525253A%252525252F%252525252Fehall.jlu.edu." +
                    "cn%252525252Fjlu_portal%252525252Findex%252526client_id%25253D679e3d8a-a8b9-" +
                    "424e-859a-7e25ac760a74%26state%3D586e7e%26client_id%3DbwDBpMCWbid5RFcljQRP";
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/sso/login";
                postData = "username=" + username + "&password=" + passwd + "&pid=" + GetPid(htmlWithPid) + "&source=";
                string htmlWithId = GetHtml(url1, postData, JluVpnCookie, out header); //login checkin

                //请求登入“本科生每日健康打卡”
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/jlu_portal/index";
                string checkInId = (GetId(htmlWithId, "guide?id=", 10, '"'));
                html = GetHtml("https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/jlu_portal/"
                                + "guide?id=" + checkInId, JluVpnCookie, out header);

                //启动办理流程1
                contentType = "application/x-www-form-urlencoded; charset=UTF-8";
                postData = "id=" + checkInId;
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/jlu_portal/saveServ" +
                       "iceCenterCount?vpn-12-o2-ehall.jlu.edu.cn";
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/jlu_portal/" + "guide?id="
                          + checkInId;
                html = GetHtml(url1, postData, JluVpnCookie, out header);

                //启动办理流程2（获取ctfToken)
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/form/BKSMRDK/start";
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/jlu_portal/guide?id=2EEF0F5C-F89A-4B8A-88CD-856BF9828F31"; ;
                string ctfToken = "";
                string htmlWithToken = GetHtml(url1, JluVpnCookie, out header);
                ctfToken = GetId(htmlWithToken, "Token\" content=\"", 16, '\"');


                //启动办理流程3
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/form/BKSMRDK/start";
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/interface/start?vpn-12-o2-ehall.jlu.edu.cn";
                postData = "idc=BKSMRDK&release=&csrfToken=" + ctfToken + "&formData=%7B%22_VAR_URL%22%3A%22https%3A%2F%2Fehall.jlu.e" +
                           "du.cn%2Finfoplus%2Ffo" + "rm%2FBKSMRDK%2Fstart%22%2C%22_VAR_URL_Attr%22%3A%22%7B%7D%22%7D";
                string htmlWithStepId = GetHtml(url1, postData, JluVpnCookie, out header);

                string StepId = GetId(htmlWithStepId, "form/", 5, '/');




                //启动办理流4(获取StepId)
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/form/" + StepId + "/render";
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/form/BKSMRDK/start";
                html = GetHtml(url1, JluVpnCookie, out header);



                //启动办理流程5 
                referer = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/form/" + StepId + "/render";
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/interface/render?vpn-12-o2-ehall.jlu.edu.cn";
                postData = "stepId=" + StepId + "&instanceId=&admin=false&rand=9.23598681158818&width=1536&lang=zh&csrfToken=" + ctfToken;
                html = GetHtml(url1, postData, JluVpnCookie, out header);//rand
                string filedSQrq = "";
                filedSQrq = GetId(html, "assignTime\":", 12, ',');
                string flowStep = StepId;
                string entryId = GetId(html, "entryId\":", 9, ',');
                studentNumber = GetId(html, "_VAR_ACTION_ACCOUNT\":\"", 22, '"'); //_VAR_ACTION_ACCOUNT":"21181329",
                department = GetId(html, "_VAR_EXECUTE_INDEP_ORGANIZE_Name\":\"", 35, '"');//_VAR_EXECUTE_INDEP_ORGANIZE_Name":"
                cls = GetId(html, "fieldSQbj_Name\":\"", 17, '"');//fieldSQbj_Name":"
                string apartment = GetId(html, "fieldSQgyl_Name\":\"", 18, '"');//fieldSQgyl_Name":"
                string IpAddress = GetId(html, "_VAR_ADDR\":\"", 12, '"');
                string grade = GetId(html, "fieldSQnj\":\"", 12, '"');
                studentName = GetId(html, "_VAR_OWNER_REALNAME\":\"", 22, '"');


                //启动办理流程5
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/interface/instance/f55993a3-8672-4ed8-ae79" +
                    "-fa6e7bb83f11/progress?vpn-12-o2-ehall.jlu.edu.cn";
                postData = "stepId=" + StepId + "&includingTop=true&csrfToken=" + ctfToken;//stepId token
                html = GetHtml(url1, postData, JluVpnCookie, out header);

                //启动办理流程6
                postData = "{\"name\":\"fieldSQqsh\",\"type\":\"text\",\"value\":\"" + room + "\"}";
                url1 = "https://vpns.jlu.edu.cn/wengine-vpn/input";
                html = GetHtml(url1, postData, JluVpnCookie, out header);

                //确认办理流程1

                string EntryNumber = entryId;

                timeStamp = GetTimeStamp(true);
                postData = "stepId=" + StepId + "&actionId=1&formData=%7B%22_VAR_EXECUTE_INDEP_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%" +
               "AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_ACTION_ACCOUNT%22%3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE" +
               "S_Codes%22%3A%22bks_100%22%2C%22_VAR_ACTION_REALNAME%22%3A%22" + HttpUtility.UrlEncode(studentName) + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZES_Names" +
               "%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_OWNER_ACCOUNT%22%" +
               "3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_ORGANIZES_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF" +
               "%E5%AD%A6%E9%99%A2%22%2C%22_VAR_STEP_CODE%22%3A%22XSTX%22%2C%22_VAR_ACTION_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_OWNER_USERCODES%2" +
               "2%3A%22" + studentNumber + "%22%2C%22_VAR_EXECUTE_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_EXECUTE_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_NO" +
               "W_DAY%22%3A%22" + today + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_OWNER_REALNAME%22%3A%22" + HttpUtility.UrlEncode(studentName) +
               "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A" +
               "6%E9%99%A2%22%2C%22_VAR_NOW%22%3A%22" + GetTimeStamp(true) + "%22%2C%22_VAR_ACTION_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%A" +
               "D%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_EXECUTE_ORGANIZES_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%9" +
               "1%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_OWNER_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_ADDR%22%3A" +
               "%22" + IpAddress + "%22%2C%22_VAR_URL_Attr%22%3A%22%7B%7D%22%2C%22_VAR_ENTRY_NUMBER%22%3A%22" + EntryNumber + "%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZE" +
               "S_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_STEP_NUMBE" +
               "R%22%3A%22" + flowStep + "%22%2C%22_VAR_POSITIONS%22%3A%22bks_100%3A10002%3A" + studentNumber + "%22%2C%22_VAR_OWNER_ORGANIZES_Names%22%3A%22%E8%AE%A1%" +
               "E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_URL%22%3A%22https%3A%2F%2Fehall.jlu." +
               "edu.cn%2Finfoplus%2Fform%2F" + flowStep + "%2Frender%22%2C%22_VAR_EXECUTE_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD" +
               "%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_RELEASE%2" +
               "2%3A%22true%22%2C%22_VAR_EXECUTE_POSITIONS%22%3A%22bks_100%3A10002%3A" + studentNumber + "%22%2C%22_VAR_NOW_MONTH%22%3A%2212%22%2C%22_VAR_ACTIO" +
               "N_USERCODES%22%3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZE%22%3A%22bks_1" +
               "00%22%2C%22_VAR_NOW_YEAR%22%3A%222020%22%2C%22fieldXY2%22%3A%22%22%2C%22fieldWY%22%3A%22wan%22%2C%22fieldXY1%22%3A%22%22%2C%22fiel" +
               "dSQrq%22%3A" + filedSQrq + "%2C%22fieldSQxm%22%3A%22" + studentNumber + "%22%2C%22fieldSQxm_Name%22%3A%22" + HttpUtility.UrlEncode(studentName) + "%22%2C%22fieldXH%2" +
               "2%3A%22" + studentNumber + "%22%2C%22fieldSQxy%22%3A%22bks_100%22%2C%22fieldSQxy_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%" +
               "B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22fieldSQnj%22%3A%22" + grade + "%22%2C%22fieldSQnj_Name%22%3A%222018%22%2C%22fieldSQnj_Att" +
               "r%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22bks_100%5C%22%7D%22%2C%22fieldSQbj%22%3A%22882%22%2C%22fieldSQbj_Name%22%3A%22" + cls + "%22%2" +
               "C%22fieldSQbj_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22”+grade+”%5C%22%7D%22%2C%22fieldSQxq%22%3A%221%22%2C%22fieldSQxq_Name%22%3A%2" +
               "2%E4%B8%AD%E5%BF%83%E6%A0%A1%E5%8C%BA%22%2C%22fieldSQgyl%22%3A%221%22%2C%22fieldSQgyl_Name%22%3A%22%E5%8C%97%E8%8B%911%E5%85%AC%E5" +
               "%AF%93%22%2C%22fieldSQgyl_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%221%5C%22%7D%22%2C%22fieldSQqsh%22%3A%22" + room + "%22%2C%22fieldHidd" +
               "en%22%3A%22%22%2C%22fieldSheng%22%3A%22%22%2C%22fieldSheng_Name%22%3A%22%22%2C%22fieldShi%22%3A%22%22%2C%22fieldShi_Name%22%3A%22%" +
               "22%2C%22fieldShi_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22%5C%22%7D%22%2C%22fieldQu%22%3A%22%22%2C%22fieldQu_Name%22%3A%22%22%2" +
                "C%22fieldQu_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22%5C%22%7D%22%2C%22fieldQums%22%3A%22%22%2C%22fieldZtw%22%3A%221%22%2C%22fi" +
                "eldZtwyc%22%3A%22%22%2C%22fieldZhongtw%22%3A%22%22%2C%22fieldZhongtwyc%22%3A%22%22%2C%22fieldWantw%22%3A%22%22%2C%22fieldWantwyc%2" +
                "2%3A%22%22%2C%22fieldHide%22%3A%22%22%2C%22fieldXY3%22%3A%22%E6%99%9A%E7%AD%BE%E5%88%B0%22%2C%22_VAR_ENTRY_NAME%22%3A%22%E6%9C%AC%" +
                "E7%A7%91%E7%94%9F%E6%AF%8F%E6%97%A5%E5%81%A5%E5%BA%B7%E6%89%93%E5%8D%A1%22%2C%22_VAR_ENTRY_TAGS%22%3A%22%E5%AD%A6%E7%94%9F%E5%B7%A" +
                "5%E4%BD%9C%E9%83%A8%22%7D&timestamp=" + timeStamp + "&rand=803.3575902747123&boundFields=fieldXH%2CfieldZtw%2CfieldHidden%2CfieldSQqsh%2C" +
                "fieldSQbj%2CfieldSQgyl%2CfieldQums%2CfieldQu%2CfieldSQxm%2CfieldWantw%2CfieldSQxy%2CfieldWY%2CfieldXY1%2CfieldZtwyc%2CfieldXY2%2Cf" +
                "ieldXY3%2CfieldZhongtw%2CfieldSQxq%2CfieldShi%2CfieldWantwyc%2CfieldSQnj%2CfieldSheng%2CfieldZhongtwyc%2CfieldHide%2CfieldSQrq&csr" +
                "fToken=" + ctfToken;


                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/interface/listNextStepsUsers?vpn-12-o2-ehall.jlu.edu.cn";
                html = GetHtml(url1, postData, JluVpnCookie, out header);


                //确认办理流程2

                postData = "actionId=1&formData=%7B%22_VAR_EXECUTE_INDEP_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%" +
               "AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_ACTION_ACCOUNT%22%3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE" +
               "S_Codes%22%3A%22bks_100%22%2C%22_VAR_ACTION_REALNAME%22%3A%22" + HttpUtility.UrlEncode(studentName) + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZES_Names" +
               "%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_OWNER_ACCOUNT%22%" +
               "3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_ORGANIZES_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF" +
               "%E5%AD%A6%E9%99%A2%22%2C%22_VAR_STEP_CODE%22%3A%22XSTX%22%2C%22_VAR_ACTION_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_OWNER_USERCODES%2" +
               "2%3A%22" + studentNumber + "%22%2C%22_VAR_EXECUTE_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_EXECUTE_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_NO" +
               "W_DAY%22%3A%22" + today + "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE%22%3A%22bks_100%22%2C%22_VAR_OWNER_REALNAME%22%3A%22" + HttpUtility.UrlEncode(studentName) +
               "%22%2C%22_VAR_ACTION_INDEP_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A" +
               "6%E9%99%A2%22%2C%22_VAR_NOW%22%3A%22" + GetTimeStamp(true) + "%22%2C%22_VAR_ACTION_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%A" +
               "D%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_EXECUTE_ORGANIZES_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%9" +
               "1%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_OWNER_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_ADDR%22%3A" +
               "%22" + IpAddress + "%22%2C%22_VAR_URL_Attr%22%3A%22%7B%7D%22%2C%22_VAR_ENTRY_NUMBER%22%3A%22" + EntryNumber + "%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZE" +
               "S_Names%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_STEP_NUMBE" +
               "R%22%3A%22" + flowStep + "%22%2C%22_VAR_POSITIONS%22%3A%22bks_100%3A10002%3A" + studentNumber + "%22%2C%22_VAR_OWNER_ORGANIZES_Names%22%3A%22%E8%AE%A1%" +
               "E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_URL%22%3A%22https%3A%2F%2Fehall.jlu." +
               "edu.cn%2Finfoplus%2Fform%2F" + flowStep + "%2Frender%22%2C%22_VAR_EXECUTE_ORGANIZE_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD" +
               "%A6%E4%B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_RELEASE%2" +
               "2%3A%22true%22%2C%22_VAR_EXECUTE_POSITIONS%22%3A%22bks_100%3A10002%3A" + studentNumber + "%22%2C%22_VAR_NOW_MONTH%22%3A%2212%22%2C%22_VAR_ACTIO" +
               "N_USERCODES%22%3A%22" + studentNumber + "%22%2C%22_VAR_ACTION_ORGANIZES_Codes%22%3A%22bks_100%22%2C%22_VAR_EXECUTE_INDEP_ORGANIZE%22%3A%22bks_1" +
               "00%22%2C%22_VAR_NOW_YEAR%22%3A%222020%22%2C%22fieldXY2%22%3A%22%22%2C%22fieldWY%22%3A%22wan%22%2C%22fieldXY1%22%3A%22%22%2C%22fiel" +
               "dSQrq%22%3A" + filedSQrq + "%2C%22fieldSQxm%22%3A%22" + studentNumber + "%22%2C%22fieldSQxm_Name%22%3A%22" + HttpUtility.UrlEncode(studentName) + "%22%2C%22fieldXH%2" +
               "2%3A%22" + studentNumber + "%22%2C%22fieldSQxy%22%3A%22bks_100%22%2C%22fieldSQxy_Name%22%3A%22%E8%AE%A1%E7%AE%97%E6%9C%BA%E7%A7%91%E5%AD%A6%E4%" +
               "B8%8E%E6%8A%80%E6%9C%AF%E5%AD%A6%E9%99%A2%22%2C%22fieldSQnj%22%3A%22" + grade + "%22%2C%22fieldSQnj_Name%22%3A%222018%22%2C%22fieldSQnj_Att" +
               "r%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22bks_100%5C%22%7D%22%2C%22fieldSQbj%22%3A%22882%22%2C%22fieldSQbj_Name%22%3A%22" + cls + "%22%2" +
               "C%22fieldSQbj_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22”+grade+”%5C%22%7D%22%2C%22fieldSQxq%22%3A%221%22%2C%22fieldSQxq_Name%22%3A%2" +
               "2%E4%B8%AD%E5%BF%83%E6%A0%A1%E5%8C%BA%22%2C%22fieldSQgyl%22%3A%221%22%2C%22fieldSQgyl_Name%22%3A%22%E5%8C%97%E8%8B%911%E5%85%AC%E5" +
               "%AF%93%22%2C%22fieldSQgyl_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%221%5C%22%7D%22%2C%22fieldSQqsh%22%3A%22" + room + "%22%2C%22fieldHidd" +
               "en%22%3A%22%22%2C%22fieldSheng%22%3A%22%22%2C%22fieldSheng_Name%22%3A%22%22%2C%22fieldShi%22%3A%22%22%2C%22fieldShi_Name%22%3A%22%" +
               "22%2C%22fieldShi_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22%5C%22%7D%22%2C%22fieldQu%22%3A%22%22%2C%22fieldQu_Name%22%3A%22%22%2" +
                "C%22fieldQu_Attr%22%3A%22%7B%5C%22_parent%5C%22%3A%5C%22%5C%22%7D%22%2C%22fieldQums%22%3A%22%22%2C%22fieldZtw%22%3A%221%22%2C%22fi" +
                "eldZtwyc%22%3A%22%22%2C%22fieldZhongtw%22%3A%22%22%2C%22fieldZhongtwyc%22%3A%22%22%2C%22fieldWantw%22%3A%22%22%2C%22fieldWantwyc%2" +
                "2%3A%22%22%2C%22fieldHide%22%3A%22%22%2C%22fieldXY3%22%3A%22%E6%99%9A%E7%AD%BE%E5%88%B0%22%2C%22_VAR_ENTRY_NAME%22%3A%22%E6%9C%AC%" +
                "E7%A7%91%E7%94%9F%E6%AF%8F%E6%97%A5%E5%81%A5%E5%BA%B7%E6%89%93%E5%8D%A1%22%2C%22_VAR_ENTRY_TAGS%22%3A%22%E5%AD%A6%E7%94%9F%E5%B7%A" +
                "5%E4%BD%9C%E9%83%A8%22%7D&nextUsers=%7B%7D&" + "&stepId=" + StepId + "&timestamp=" + timeStamp + "&rand=803.3575902747123&boundFields=fieldXH%2CfieldZtw%2CfieldHidden%2CfieldSQqsh%2C" +
                "fieldSQbj%2CfieldSQgyl%2CfieldQums%2CfieldQu%2CfieldSQxm%2CfieldWantw%2CfieldSQxy%2CfieldWY%2CfieldXY1%2CfieldZtwyc%2CfieldXY2%2Cf" +
                "ieldXY3%2CfieldZhongtw%2CfieldSQxq%2CfieldShi%2CfieldWantwyc%2CfieldSQnj%2CfieldSheng%2CfieldZhongtwyc%2CfieldHide%2CfieldSQrq&csr" +
                 "fToken=" + ctfToken;
                url1 = "https://vpns.jlu.edu.cn/https/77726476706e69737468656265737421f5ff40902b7e625c6b468ca88d1b203b/infoplus/interface/doAction?vpn-12-o2-ehall.jlu.edu.cn";
                html = GetHtml(url1, postData, JluVpnCookie, out header);
                if (html.Contains("error"))
                {
                    return 1;
                }
                else
                {
                    return 0;

                }
            }
            catch
            {
                return 1;
            }



        }
        public static string GetTimeStamp(bool bflag)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return ret;
        }
        static private string GetId(string html, string idty, int substringStart, char end_substring)
        {
            /* string str = html.Substring(html.IndexOf("id:'"));
             str = str.Substring(5);
             return str.Substring(0, str.IndexOf("'"));*/
            string str = html.Substring(html.IndexOf(idty));
            str = str.Substring(substringStart);
            return str.Substring(0, str.IndexOf(end_substring));

        }
        static private string GetPid(string html)
        {
            string str = html.Substring(html.IndexOf("name=\"pid\" value=\""));
            str = str.Substring(18);
            return str.Substring(0, str.IndexOf("\""));
        }

        /*返回一个html页面*/
        public static string GetHtml(string URL)
        {
            WebRequest wrt;
            wrt = WebRequest.Create(URL);
            wrt.Credentials = CredentialCache.DefaultCredentials;
            WebResponse wrp;
            wrp = wrt.GetResponse();
            return new StreamReader(wrp.GetResponseStream(), Encoding.Default).ReadToEnd();
        }
        public static string GetHtml(string URL, out string cookie)
        {
            WebRequest wrt;
            wrt = WebRequest.Create(URL);
            wrt.Credentials = CredentialCache.DefaultCredentials;
            WebResponse wrp;

            wrp = wrt.GetResponse();

            string html = new StreamReader(wrp.GetResponseStream(), Encoding.Default).ReadToEnd();
            cookie = wrp.Headers.Get("Set-Cookie");
            // Console.WriteLine(cookie);
            return html;
        }
        public static string GetHtml(string URL, string postData, string[] cookie, out string header)
        {
            return GetHtml(server, URL, postData, cookie, out header);
        }
        public static string GetHtml(string server, string URL, string postData, string[] cookie, out string header)
        {
            byte[] byteRequest = Encoding.Default.GetBytes(postData);
            return GetHtml(server, URL, byteRequest, cookie, out header);
        }
        public static string GetHtml(string server, string URL, byte[] byteRequest, string[] cookie, out string header)
        {
            string html = GetHtmlByBytes(server, URL, byteRequest, cookie, out header);
            return html;
        }
        public static string GetHtmlByBytes(string server, string URL, byte[] byteRequest, string[] cookie, out string header)
        {
            HttpWebRequest httpWebRequest;
            HttpWebResponse webResponse;
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
            CookieContainer co = new CookieContainer();
            string getString = " ";
            foreach (string subCookie in cookie)
            {
                if (subCookie != null)
                {
                    co.SetCookies(new Uri(server), subCookie);
                }
            }
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.CookieContainer = co;
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Accept =
                "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            httpWebRequest.Referer = referer;
            httpWebRequest.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.60";
            httpWebRequest.Method = "Post";
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream;
            stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            stream.Close();
            httpWebRequest.AllowAutoRedirect = false;
            //Console.WriteLine(httpWebRequest.Headers.ToString());
            //webResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            WebResponse res;
            try
            {
                res = httpWebRequest.GetResponse();
            }
            catch (WebException e)
            {
                //if (e.Message.Contains("203"))
                res = e.Response;
            }
            webResponse = (HttpWebResponse)res;

            if (webResponse.StatusCode == HttpStatusCode.Found)
            {
                string strUrl = "";
                strUrl = webResponse.Headers[HttpResponseHeader.Location];
                if (!strUrl.Contains("vpns.jlu.edu.cn"))
                {
                    strUrl = "https://vpns.jlu.edu.cn" + strUrl;
                };
                getString = GetHtml(strUrl, cookie, out header);
            }
            else
            {

                header = webResponse.Headers.ToString();
                Stream responseStream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                getString = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
            }



            return getString;
        }


        // 跟踪302临时跳转，接收Cookies并传递给下一次请求。
        public static string GetHtml(string strUrl, string[] strCookies, out string header)
        {
            try
            {
                HttpWebRequest req;
                HttpWebResponse res = GetHttpWebResponseNoRedirect(strUrl, strCookies, out req);
                while (res.StatusCode == HttpStatusCode.Found)
                {

                    strUrl = res.Headers[HttpResponseHeader.Location];
                    if (!strUrl.Contains("vpns.jlu.edu.cn"))
                    {
                        strUrl = "https://vpns.jlu.edu.cn" + strUrl;
                    };

                    if (res.Headers[HttpResponseHeader.SetCookie] != null)
                        strCookies[1] = res.Headers[HttpResponseHeader.SetCookie];
                    res.Close();
                    req.Abort();
                    res = GetHttpWebResponseNoRedirect(strUrl, strCookies, out req);
                }
                header = res.Headers.ToString();
                Stream responseStream = res.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                res.Close();
                req.Abort();
                return html;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                header = "";
                return "";

            }
        }

        // 执行HTTP GET请求，返回Response对象和Request对象。调用者负责关闭他们：Response.Close()，Request.Abort()。
        public static HttpWebResponse GetHttpWebResponseNoRedirect(string strUrl, string[] strCookies, out HttpWebRequest request)
        {
            HttpWebRequest req = null;
            try
            {
                req = HttpWebRequest.Create(strUrl) as HttpWebRequest;
                req.Credentials = CredentialCache.DefaultCredentials;
                /*if (!string.IsNullOrEmpty(strCookies))
                    req.Headers[HttpRequestHeader.Cookie] = strCookies;*/
                CookieContainer co = new CookieContainer();
                foreach (var sub_cookie in strCookies)
                {
                    if (sub_cookie != null)
                        co.SetCookies(new Uri(server), sub_cookie);
                }
                req.CookieContainer = co;
                req.ContentType = "application/x-www-form-urlencoded";
                req.ServicePoint.ConnectionLimit = 4;
                if (!string.IsNullOrEmpty(referer))
                    req.Referer = referer;
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"; ;
                req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.60"; ;
                req.Method = "GET";
                req.Timeout = 15000;
                req.AllowAutoRedirect = false;
                WebResponse res;
                try
                {
                    res = req.GetResponse();
                }
                catch (WebException e)
                {
                    //if (e.Message.Contains("302"))
                    res = e.Response;
                }
                request = req;// Liigo: 如果此处调用req.Abort()关闭请求，则返回的Response对象的数据流是不可读的（"流不可读"）。
                return (HttpWebResponse)res;
            }
            catch
            {
                if (req != null) req.Abort();
                request = null;
                return null;
            }
        }



    }
}
