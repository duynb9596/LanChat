using ChatApp_Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp_Server.Controller
{
	class ServerController
	{
		LanChatDBEntities db = new LanChatDBEntities();
		
		public bool CheckLogin(string username, string password)
		{
			tblUser user = db.tblUsers.Where(i => i.Username == username && i.Password == password).FirstOrDefault();
			if (user != null)
				return true;
			return false;
		}
	}
}
