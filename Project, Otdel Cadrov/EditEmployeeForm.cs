using System;
using System.Linq;
using System.Windows.Forms;

namespace Project__Otdel_Cadrov
{
    public partial class EditEmployeeForm : Form
    {
        public Employee EmployeeToEdit { get; private set; }

        public EditEmployeeForm(Employee employee)
        {
            InitializeComponent();
            EmployeeToEdit = employee;

            txtName.Text = EmployeeToEdit.Name;
            txtDepartment.Text = EmployeeToEdit.Department;
            txtInstitute.Text = EmployeeToEdit.Institute;
            txtBirth.Text = EmployeeToEdit.Birth.ToString();
            txtPlace.Text = EmployeeToEdit.Place;
            txtAddress.Text = EmployeeToEdit.Address;
            txtPhone.Text = EmployeeToEdit.Phone.ToString();
            txtEducation.Text = EmployeeToEdit.Education;
            txtYear.Text = EmployeeToEdit.Year.ToString();
            txtPassport.Text = EmployeeToEdit.Passport.ToString();
            txtPost.Text = EmployeeToEdit.Post;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var textBoxes = new[] { txtName, txtDepartment, txtInstitute, txtBirth, txtPlace, txtAddress, txtPhone, txtEducation, txtYear, txtPassport, txtPost };
            if (textBoxes.Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            if (!int.TryParse(txtBirth.Text, out int birth) ||
                !int.TryParse(txtPhone.Text, out int phone) ||
                !int.TryParse(txtYear.Text, out int year) ||
                !int.TryParse(txtPassport.Text, out int passport))
            {
                MessageBox.Show("Поля Год рождения, Телефон, Год и Паспорт должны содержать только цифры.");
                return;
            }

            if (birth < 1935)
            {
                MessageBox.Show("Год рождения должен быть не ранее 1935 года.");
                return;
            }

            if (year < 1935)
            {
                MessageBox.Show("Год вступление должен быть не ранее 1935 года.");
                return;
            }

            if (!new[] { txtName, txtDepartment, txtInstitute, txtPlace, txtPost }.All(tb => tb.Text.All(char.IsLetter)))
            {
                MessageBox.Show("Поля Имя, Департамент, Институт, Город и Должность должны содержать только буквы.");
                return;
            }

            EmployeeToEdit.Name = txtName.Text;
            EmployeeToEdit.Department = txtDepartment.Text;
            EmployeeToEdit.Institute = txtInstitute.Text;
            EmployeeToEdit.Birth = birth;
            EmployeeToEdit.Place = txtPlace.Text;
            EmployeeToEdit.Address = txtAddress.Text;
            EmployeeToEdit.Phone = phone;
            EmployeeToEdit.Education = txtEducation.Text;
            EmployeeToEdit.Year = year;
            EmployeeToEdit.Passport = passport;
            EmployeeToEdit.Post = txtPost.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}