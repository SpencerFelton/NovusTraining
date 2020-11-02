using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeAreaForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            label1.Text = "me";
        }




        private void Form1_Load(object sender, EventArgs e) {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            switch (comboBox1.SelectedIndex) {
                case 0:
                    textBox1.Visible = true;
                    label4.Visible = true;
                    label4.Text = "Width";

                    textBox2.Visible = true;
                    label5.Visible = true;
                    label5.Text = "Height";

                    button1.Visible = true;
                    button1.Text = "Calculate Area and Perimeter";

                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;

                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;

                    break;
                case 1:
                    textBox1.Visible = true;
                    label4.Visible = true;
                    label4.Text = "Radius";

                    button1.Visible = true;
                    button1.Text = "Calculate Area and Perimeter";

                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;

                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;

                    break;
                case 2:
                    textBox1.Visible = true;
                    label4.Visible = true;
                    label4.Text = "SideA";

                    textBox2.Visible = true;
                    label5.Visible = true;
                    label5.Text = "SideB";

                    textBox3.Visible = true;
                    label6.Visible = true;
                    label6.Text = "SideC";

                    button1.Visible = true;
                    button1.Text = "Calculate Area and Perimeter";

                    label9.Visible = false;

                    break;
                case 3:
                    textBox1.Visible = true;
                    label4.Visible = true;
                    label4.Text = "x^2 term";

                    textBox2.Visible = true;
                    label5.Visible = true;
                    label5.Text = "x term";

                    textBox3.Visible = true;
                    label6.Visible = true;
                    label6.Text = "constant";

                    button1.Visible = true;
                    button1.Text = "Calculate Roots";

                    textBox4.Visible = false;
                    textBox5.Visible = false;

                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;

                    break;
                default:
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            List<String> validTextBoxes = new List<string>();
            int count = 0;
            validTextBoxes.Add(textBox1.Text);
            validTextBoxes.Add(textBox2.Text);
            validTextBoxes.Add(textBox3.Text);
            validTextBoxes.Add(textBox4.Text);
            validTextBoxes.Add(textBox5.Text);
            foreach(String answer in validTextBoxes) {
                if(answer != "") {
                    count++;
                }
            }

            switch (count) {
                case 1:
                    //circle
                    Circle circle = new Circle();
                    double radius = double.Parse(textBox1.Text);
                    circle.radius = radius;
                    double area = circle.Area();
                    double perimeter = circle.Perimeter();
                    label9.Visible = true;
                    label9.Text = $"The area of the circle is {area} and the perimeter is {perimeter}";
                    break;
                case 2:
                    //square
                    Rectangle rect = new Rectangle();
                    double width = double.Parse(textBox1.Text);
                    double height = double.Parse(textBox2.Text);
                    rect.width = width;
                    rect.height = height;
                    double rectArea = rect.Area();
                    double rectPeri = rect.Perimeter();
                    label9.Visible = true;
                    label9.Text = $"The area of the rectangle is {rectArea} and the perimeter is {rectPeri}";
                    break;
                case 3:
                    if (comboBox1.SelectedIndex == 3) {
                        // quadratic
                        Quadratic quad = new Quadratic();
                        double xSquared = double.Parse(textBox1.Text);
                        double xTerm = double.Parse(textBox2.Text);
                        double constant = double.Parse(textBox3.Text);

                        quad.squaredTerm = xSquared;
                        quad.xTerm = xTerm;
                        quad.constant = constant;

                        string[] roots = quad.findRoots();

                        label9.Visible = true;
                        label9.Text = $"The roots of the equation {xSquared}^2 x + {xTerm} x + {constant} are: {roots[0]} and {roots[1]}";
                        break;
                    }
                    else {
                        //triangle
                        Triangle tri = new Triangle();
                        double sideA = double.Parse(textBox1.Text);
                        double sideB = double.Parse(textBox2.Text);
                        double sideC = double.Parse(textBox3.Text);
                        tri.sideA = sideA;
                        tri.sideB = sideB;
                        tri.sideC = sideC;
                        double triArea = tri.Area();
                        double triPeri = tri.Perimeter();
                        label9.Visible = true;
                        if(triArea <= 0) {
                            label9.Text = $"Not a valid triangle";
                            break;
                        }
                        else {
                            label9.Text = $"The area of the triangle is {triArea} and the perimeter is {triPeri}";
                            break;
                        }
                    }                    
                default:
                    break;
            }
            
        }
    }
}
