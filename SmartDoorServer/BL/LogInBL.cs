using DL;
using Entities;
using SmartDoorServer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LogInBL : ILogInBL
    {
        ILogInDL _logInDL;
        public LogInBL(ILogInDL logInDL)
        {
            _logInDL = logInDL;
        }

        public async Task<LogInResponse> GetUser(string userName, string password)
        {
            try
            {
                return await _logInDL.GetUser(userName, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
