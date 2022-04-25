using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.DoNotChange
{
    internal interface IUserController
    {
        bool AddTaskForUser(int userId, string description, IResponseModel model);
        string GetMessageForModel(int userId, string description);
    }
}
