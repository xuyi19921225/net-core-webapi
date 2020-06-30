using System;
using System.Collections.Generic;
using System.Text;

namespace BestPracticeWeb.WebApi.Model
{
   public class OperateBaseModel
    {
        public DateTime CreateAt { get; set; }

        public string CreateBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
}
