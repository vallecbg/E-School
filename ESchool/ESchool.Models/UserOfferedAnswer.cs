using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Models
{
    public class UserOfferedAnswer
    {
        public string UserAnswerId { get; set; }
        public UserAnswer UserAnswer { get; set; }

        public string OfferedAnswerId { get; set; }
        public OfferedAnswer OfferedAnswer { get; set; }
    }
}
