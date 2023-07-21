using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.EntityLayer.Concrete
{
    public class FormSubmit
    {
        public int FormSubmitID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
