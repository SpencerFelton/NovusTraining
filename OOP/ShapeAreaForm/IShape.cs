using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaForm {
    interface IShape {
        double Area();
        double Perimeter();
        void displayDetails();
    }
}
