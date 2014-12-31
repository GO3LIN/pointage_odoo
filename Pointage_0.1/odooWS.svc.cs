using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CookComputing.XmlRpc;

namespace Pointage_0._1
{
    [XmlRpcUrl("http://localhost:8069/xmlrpc/common")]
    public interface IOpenErpLogin : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]
        int login(string dbName, string dbUser, string dbPwd);
    }
    [ServiceContract(Namespace = "")]
    public class odooWS
    {
        public string OdooDb = "test";
        DCDataContext dc = new DCDataContext();

        [OperationContract]
        public string pointer(string email, string pwd)
        {
            //Login to openerp
            try
            {
                IOpenErpLogin rpcClientLogin = XmlRpcProxyGen.Create<IOpenErpLogin>(); //add  XmlRpcProxyGen.CS File from src folder if required,
                int userid = rpcClientLogin.login(OdooDb, email, pwd);

                return pointer2(userid, email);



            }
            catch (Exception)
            {
                pointerLog(email);
                return "Une erreur s'est produite, veuillez réessayer plus tard !";
            }

        }

        public string pointer2(int user_id, string login)
        {
            DateTime today = DateTime.UtcNow;
            pointage p;
            // On verifie si un utilisateur n'a pas pointé aujourd'hui
            p = dc.pointages.SingleOrDefault(x => x.userid.Equals(user_id) && x.date_pointage.Value.Date == today.Date);
            if (p == null)
            {
                // On pointe aujourd'hui
                p = new pointage();
                p.userid = user_id;
                p.date_pointage = today;
                dc.pointages.InsertOnSubmit(p);
                dc.SubmitChanges();

                // On vérifie s'il n'y a pas des logs à ajouter
                var q =
                    from a in dc.GetTable<pointage_log>()
                    where a.email.Equals(login) && a.date_log.Value.Date != DateTime.UtcNow.Date
                    select a;

                foreach (pointage_log p_log in q)
                {
                    pointage point = new pointage();
                    point.userid = user_id;
                    point.date_pointage = p_log.date_log;
                    dc.pointages.InsertOnSubmit(point);
                    dc.SubmitChanges();
                }




                return "Success";
            }
            return "Vous avez déjà pointé aujourd'hui !";

        }

        public void pointerLog(string email)
        {
            pointage_log p_log;
            p_log = dc.pointage_logs.SingleOrDefault(x => x.email.Equals(email) && x.date_log.Value.Date == DateTime.UtcNow.Date);
            if (p_log == null)
            {
                p_log = new pointage_log();
                p_log.email = email;
                p_log.date_log = DateTime.UtcNow;
                dc.pointage_logs.InsertOnSubmit(p_log);
                dc.SubmitChanges();
            }


        }

        // Add more operations here and mark them with [OperationContract]
    }
}
