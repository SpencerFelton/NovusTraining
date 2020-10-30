using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingBatArray_2 {
    class Program {
        static void Main(string[] args) {
        }

        public static int centeredAverage(int[] nums) {
            int smallest = nums.Min();
            int largest = nums.Max();
            int sum = 0;
            bool skippedMax = false;
            bool skippedMin = false;

            for(int i = 0; i < nums.Length; i++) {
                if(nums[i] == smallest) {
                    if (skippedMin == false) {
                        skippedMin = true;
                    }
                    else {
                        sum += nums[i];
                    }
                }
                else if(nums[i] == largest) {
                    if (skippedMax == false) {
                        skippedMax = true;
                    }
                    else {
                        sum += nums[i];
                    }
                }
                else {
                    sum += nums[i];
                }
            }
            return sum / (nums.Length - 2);
        }

        
    }
}
