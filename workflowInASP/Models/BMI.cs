using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace workflowInASP.Models
{
    public class BMI
    {
        public Double Height { get; set; }
        public Double Weight { get; set; }
        public Double BMIValue{ 
            get
            {
                if (Height > 0) 
                { 
                    return Weight / (Height * Height); 
                }
                else
                    return 0;
            
            }  
        }
        public string Recommendation { get; set; }
    }
}