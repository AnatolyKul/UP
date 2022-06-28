using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work : Page
    {

        public List<Advanced_training__courses_employee> ADV { get; set; }
        public List<Education_Employee> E_E { get; set; }

        Dictionary<long, Employee> pairs = new Dictionary<long, Employee>();
        Dictionary<string, Position> pair = new Dictionary<string, Position>();
        KindergartenEntities connection = new KindergartenEntities();
        public Work()
        {
            InitializeComponent();
            LoadPos();
            LoadCat();
            LoadEmployee();
            LoadCat_3();
            LoadEmployee_3();
            LoadEmloyee_Course();
            LoadTypeCourse();
            LoadPlaceCourse();
            LoadFormCourse();
            LoadEmloyee_Course_Compl();
            LoadEmloyee_Educ();
            LoadDocEduc();
            LoadTypeEduc();
            LoadEmloyee_Educ_Compl();
            DataContext = this;
            Employee_List.DisplayMemberPath = "Full_name";
            List_Employee.DisplayMemberPath = "Full_name";
            //Employee_Course_LB.DisplayMemberPath = "Full_name";
            Select_Course_LB.DisplayMemberPath = "Full_name";
            Employee_Course_LB_Compl.DisplayMemberPath = "Full_name";
            Select_Educ_LB.DisplayMemberPath = "Full_name";
            Employee_Educ_LB_Compl.DisplayMemberPath = "Full_name";

        }


        private void LoadPos()
        {
            var pos = connection.Position.ToList();
            foreach (var p in pos)
            {
                Position_CB.Items.Add(p.Name);
            }
        }


        private void LoadCat()
        {
            var cat = connection.Qualification_category.ToList();
            foreach (var c in cat)
            {
                Category_CB.Items.Add(c.Name);

            }
        }


        private void LoadEmployee()
        {
            Employee_List.Items.Clear();
            var em = connection.Employee.ToList();
            foreach (var e in em)
            {

                Employee_List.Items.Add(e);
            }
        }

        private void LoadCat_3()
        {
            var cat_3 = connection.Qualification_category.ToList();
            foreach (var c_3 in cat_3)
            {
                Category_CB_3.Items.Add(c_3.Name);

            }
        }

        private void LoadEmployee_3()
        {
            List_Employee.Items.Clear();
            var em_3 = connection.Employee.ToList();
            foreach (var e_3 in em_3)
            {

                List_Employee.Items.Add(e_3);
            }
        }

        private void Exit_Btn_4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Exit_Btn_5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Exit_Btn_6_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Exit_Btn_7_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Exit_Btn_8_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Exit_Btn_9_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Employee();

            if (FIO_TB.Text.Length == 0)
            {
                MessageBox.Show("Введите Ф.И.О.");
                return;
            }

            if (Position_CB.Text.Length == 0)
            {
                MessageBox.Show("Выберите должность");
                return;
            }

            if (Category_CB.Text.Length == 0)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }

            if (Category_CB.Text == "-")
            {
                emp.Full_name = FIO_TB.Text;
                emp.Date_of_birth = Birthday_DP.SelectedDate.Value;
                emp.Position = Position_CB.Text;
                emp.Qualification_category = Category_CB.Text;
                connection.Employee.Add(emp);
                connection.SaveChanges();
                MessageBox.Show("Данные успешно добавлены");
                LoadEmployee();
                LoadEmployee_3();
                LoadEmloyee_Course();
                LoadEmloyee_Course_Compl();
                LoadEmloyee_Educ();
                LoadEmloyee_Educ_Compl();
            }

            else
            {

                emp.Full_name = FIO_TB.Text;
                emp.Date_of_birth = Birthday_DP.SelectedDate.Value;
                emp.Position = Position_CB.Text;
                emp.Qualification_category = Category_CB.Text;
                emp.Date_of_category_establishment = Date_Beg_Cat_DP.SelectedDate.Value;
                emp.Date_of_category_confirmation = Date_End_Cat_DP.SelectedDate.Value;

                connection.Employee.Add(emp);
                connection.SaveChanges();
                MessageBox.Show("Данные успешно добавлены");
                LoadEmployee();
                LoadEmployee_3();
                LoadEmloyee_Course();
                LoadEmloyee_Course_Compl();
                LoadEmloyee_Educ();
                LoadEmloyee_Educ_Compl();
            }

        }

        private void Look_Btn_Click(object sender, RoutedEventArgs e)
        {

            var Empl = Employee_List.SelectedItem as Employee;

            if (Employee_List.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника!");
            }
            else
            {
                if (Empl != null)
                {

                    //var poss = Empl.Position1;

                    Position_CB_2.Text = Empl.Position;
                    Category_CB_2.Text = Empl.Qualification_category;
                    Date_Beg_Cat_DP_2.SelectedDate = Empl.Date_of_category_establishment;
                    Date_End_Cat_DP_2.SelectedDate = Empl.Date_of_category_confirmation;
                    Birthday_DP_2.SelectedDate = Empl.Date_of_birth;



                }
            }
        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            var Emppp = List_Employee.SelectedItem as Employee;
            if (List_Employee.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            if (Category_CB_3.Text.Length == 0)
            {
                MessageBox.Show("Выберите категорию!");
                return;
            }


            else
            {
                if (Emppp != null)
                {

                    var emem = connection.Employee.Where(o => o.Number_employee == Emppp.Number_employee).FirstOrDefault();
                    if (emem != null)
                    {

                        if (Category_CB_3.Text == "-")
                        {
                            emem.Qualification_category = Category_CB_3.Text;
                            Category_CB_3.Text = "";
                            emem.Date_of_category_establishment = null;
                            emem.Date_of_category_confirmation = null;
                            MessageBox.Show("Изменения сохранены");
                        }

                        else
                        {

                            emem.Qualification_category = Category_CB_3.Text;
                            emem.Date_of_category_establishment = Date_Beg_Cat_DP_3.SelectedDate;
                            emem.Date_of_category_confirmation = Date_End_Cat_DP_3.SelectedDate;

                            Category_CB_3.Text = "";
                            MessageBox.Show("Изменения сохранены");
                        }
                    }



                }
            }
            connection.SaveChanges();
        }

        private void LoadEmloyee_Course()
        {
            Employee_Course_LB.Items.Clear();
            var emp_course = connection.Employee.ToList();
            foreach (var e_course in emp_course)
            {
                Employee_Course_LB.Items.Add(e_course.Full_name);
                pairs[e_course.Number_employee] = e_course;

            }
        }

        private void LoadTypeCourse()
        {
            var type_course = connection.Type_course.ToList();
            foreach (var t_course in type_course)
            {
                Type_course.Items.Add(t_course.Name);

            }
        }

        private void LoadPlaceCourse()
        {
            var place_course = connection.Location.ToList();
            foreach (var p_course in place_course)
            {
                Place_course.Items.Add(p_course.Name);

            }
        }

        private void LoadFormCourse()
        {
            var form_course = connection.Form.ToList();
            foreach (var f_course in form_course)
            {
                Form_course.Items.Add(f_course.Name);

            }
        }

        private void Add_Btn_Course_Click(object sender, RoutedEventArgs e)
        {

            if (Employee_Course_LB.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            else
            {
                Dictionary<long, int> currentOrderList = new Dictionary<long, int>();
                foreach (var Employee in Select_Course_LB.Items)
                {
                    var emp_C = Employee as Employee;
                    if (currentOrderList.ContainsKey(emp_C.Number_employee))
                    {
                        currentOrderList[emp_C.Number_employee]++;
                    }
                    else
                    {
                        currentOrderList.Add(emp_C.Number_employee, 1);
                    }
                }

                foreach (var Employee in currentOrderList)
                {
                    var emp_C = Employee.Value;
                    Advanced_training__courses_employee advanced = new Advanced_training__courses_employee();
                    advanced.Number_employee = Employee.Key;
                    //advanced.Number_course = advanced.Number_course;
                    advanced.Name_course = Name_course.Text;
                    advanced.Type_course = Type_course.Text;
                    advanced.Location = Place_course.Text;
                    advanced.Number_document = Number_doc.Text;
                    advanced.Document_course = "Удостоверение";
                    advanced.Registration_number_of_the_document = Reg_number_doc.Text;
                    advanced.Date_ending_course = Date_end_course.SelectedDate;
                    advanced.Form = Form_course.Text;
                    advanced.Quantity_of_hours = Count_hours_course.Text;
                    connection.Advanced_training__courses_employee.Add(advanced);
                }

                int result = connection.SaveChanges();
                if (result > 0)
                {
                    Select_Course_LB.Items.Clear();

                    MessageBox.Show("Данные добавлены");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }
        }

        private void Select_Btn_Course_Click(object sender, RoutedEventArgs e)
        {
            string eeem;
            var EmpList = connection.Employee.ToList();
            if (Employee_Course_LB.SelectedIndex != -1)
            {
                eeem = Employee_Course_LB.SelectedItem.ToString();

                foreach (var Dishes_Amount in EmpList)
                {
                    if (eeem == Dishes_Amount.Full_name)
                    {

                        Select_Course_LB.Items.Add(Dishes_Amount);

                    }
                }
            }
            else
            {
                MessageBox.Show("Сотрудник не выбран!");
            }
        }

        private void Del_Btn_Course_Click(object sender, RoutedEventArgs e)
        {
            var EmpppList = connection.Employee.ToList();
            if (Select_Course_LB.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника");
            }

            else
            {
                var emmmmmppp = (Employee)Select_Course_LB.SelectedItem;
                this.Select_Course_LB.Items.RemoveAt(this.Select_Course_LB.SelectedIndex);
            }
        }



        private void LoadEmloyee_Course_Compl()
        {
            Employee_Course_LB_Compl.Items.Clear();
            var emp_course_compl = connection.Employee.ToList();
            foreach (var e_course_c in emp_course_compl)
            {
                Employee_Course_LB_Compl.Items.Add(e_course_c);
                //pairs[e_course_c.Number_employee] = e_course_c;

            }
        }

        private void Select_Btn_Course_Compl_Click(object sender, RoutedEventArgs e)
        {
            //string eeem;
            //var EmpList = connection.Advanced_training__courses_employee.ToList();
            //if (Employee_Course_LB_Compl.SelectedIndex != -1)
            //{
            //    eeem = Employee_Course_LB_Compl.SelectedItem.ToString();

            //    foreach (var Dishes_Amount in EmpList)
            //    {
            //        if (eeem == Dishes_Amount.Number_employee.ToString())
            //        {

            //            Select_Course_LB.Items.Add(Dishes_Amount);

            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Сотрудник не выбран!");
            //}
        }


        private void LoadEmloyee_Educ_Compl()
        {
            Employee_Educ_LB_Compl.Items.Clear();
            var emp_educ_compl = connection.Employee.ToList();
            foreach (var e_educ_c in emp_educ_compl)
            {
                Employee_Educ_LB_Compl.Items.Add(e_educ_c);
                //pairs[e_course_c.Number_employee] = e_course_c;

            }
        }

        private void Employee_Course_LB_Compl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var epp = Employee_Course_LB_Compl.SelectedItem as Employee;
            ADV = connection.Advanced_training__courses_employee.Where(s => s.Number_employee == epp.Number_employee).ToList();
            Select_Course_LB_Compl.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }

        private void Employee_Educ_LB_Compl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var emp_educ = Employee_Educ_LB_Compl.SelectedItem as Employee;
            E_E = connection.Education_Employee.Where(s => s.Number_employee == emp_educ.Number_employee).ToList();
            Select_Educ_LB_Compl.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }

        private void LoadEmloyee_Educ()
        {
            Employee_Educ_LB.Items.Clear();
            var emp_educ = connection.Employee.ToList();
            foreach (var e_educ in emp_educ)
            {
                Employee_Educ_LB.Items.Add(e_educ.Full_name);
                pairs[e_educ.Number_employee] = e_educ;

            }
        }

        private void LoadDocEduc()
        {
            var doc_educ = connection.Document_ending_educational_organization.ToList();
            foreach (var d_educ in doc_educ)
            {
                Document_ed.Items.Add(d_educ.Name);

            }
        }
       
        private void LoadTypeEduc()
        {
            var type_educ = connection.Educational.ToList();
            foreach (var t_educ in type_educ)
            {
                Type_educ.Items.Add(t_educ.Name);

            }
        }

        private void Select_Btn_Educ_Click(object sender, RoutedEventArgs e)
        {
            string eeem;
            var EmpList = connection.Employee.ToList();
            if (Employee_Educ_LB.SelectedIndex != -1)
            {
                eeem = Employee_Educ_LB.SelectedItem.ToString();

                foreach (var Dishes_Amount in EmpList)
                {
                    if (eeem == Dishes_Amount.Full_name)
                    {

                        Select_Educ_LB.Items.Add(Dishes_Amount);

                    }
                }
            }
            else
            {
                MessageBox.Show("Сотрудник не выбран!");
            }
        }

        private void Del_Btn_Educ_Click(object sender, RoutedEventArgs e)
        {
            var EmpppList = connection.Employee.ToList();
            if (Select_Educ_LB.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника");
            }

            else
            {
                var emmmmmppp = (Employee)Select_Educ_LB.SelectedItem;
                this.Select_Educ_LB.Items.RemoveAt(this.Select_Educ_LB.SelectedIndex);
            }
        }

        private void Add_Btn_Educ_Click(object sender, RoutedEventArgs e)
        {
            if (Employee_Educ_LB.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            else
            {
                Dictionary<long, int> currentOrderList_3 = new Dictionary<long, int>();
                foreach (var Employee in Select_Educ_LB.Items)
                {
                    var emp_C = Employee as Employee;
                    if (currentOrderList_3.ContainsKey(emp_C.Number_employee))
                    {
                        currentOrderList_3[emp_C.Number_employee]++;
                    }
                    else
                    {
                        currentOrderList_3.Add(emp_C.Number_employee, 1);
                    }
                }

                foreach (var Employee in currentOrderList_3)
                {
                    var emp_C = Employee.Value;
                    Education_Employee education = new Education_Employee();
                    education.Number_employee = Employee.Key;
                    //advanced.Number_course = advanced.Number_course;
                    education.Name_educational_organization = Name_org.Text;
                    education.Document_ending_educational_organization = Document_ed.Text;
                    education.Number_Document = Number_doc_educ.Text;
                    education.Date_ending_educational_organization = Date_end_educ.SelectedDate;
                    education.Educational = Type_educ.Text;
                    education.Specialization = Spez_educ.Text;
                    education.Qualification = Qul_educ.Text;
                    connection.Education_Employee.Add(education);
                }

                int result = connection.SaveChanges();
                if (result > 0)
                {
                    Select_Educ_LB.Items.Clear();

                    MessageBox.Show("Данные добавлены");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }

            }
        }

       
    }
    
}
