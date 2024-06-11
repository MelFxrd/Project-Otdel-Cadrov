using System;
using System.Linq;
using System.Windows.Forms;

namespace Project__Otdel_Cadrov
{
    public partial class AddEmployeeForm : Form
    {
        public Employee NewEmployee { get; private set; }

        public AddEmployeeForm() => InitializeComponent();

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
                MessageBox.Show("Поля Дата рождения, Телефон, Год и Паспорт должны содержать только цифры.");
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
                MessageBox.Show("Поля Имя, Департамент, Институт, Место и Должность должны содержать только буквы.");
                return;
            }

            NewEmployee = new Employee
            {
                Name = txtName.Text,
                Department = txtDepartment.Text,
                Institute = txtInstitute.Text,
                Birth = birth,
                Place = txtPlace.Text,
                Address = txtAddress.Text,
                Phone = phone,
                Education = txtEducation.Text,
                Year = year,
                Passport = passport,
                Post = txtPost.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}