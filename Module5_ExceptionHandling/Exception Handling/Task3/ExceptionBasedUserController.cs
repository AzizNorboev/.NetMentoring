using System;
using System.Collections.Generic;
using System.Text;
using Task3.DoNotChange;

namespace Task3
{
    public class ExceptionBasedUserController : IUserController
    {
        private readonly UserTaskService _taskService;

        public ExceptionBasedUserController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            string message = GetMessageForModel(userId, description);
            if (message != null)
            {
                model.AddAttribute("action_result", message);
                return false;
            }

            return true;
        }

        public string GetMessageForModel(int userId, string description)
        {
            try
            {
                var task = new UserTask(description);
                int result = _taskService.AddTaskForUser(userId, task);
                if (result == -1)
                    throw new ArgumentOutOfRangeException("", "Invalid userId");

                if (result == -2)
                    throw new ArgumentNullException("User not found");

                if (result == -3)
                    throw new ArgumentNullException("The task already exists");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            return null;
        }
    }
}
