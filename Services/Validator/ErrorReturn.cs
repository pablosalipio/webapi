using System.Collections.Generic;

namespace webapi.Services.Validator
{
    public class ErrorReturn
    {
        public string title { get; set; }
        public int status { get; set; }
        public IList<EmployeeError> errors { get; set; }
    }
}
