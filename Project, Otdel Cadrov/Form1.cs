using Microsoft.EntityFrameworkCore;

namespace Project__Otdel_Cadrov
{
    public partial class Form1 : Form
    {
        private Context? context;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context = new Context();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Employees.Load();

            bindingSource1.DataSource = context.Employees.Local.ToBindingList();
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using var addForm = new AddEmployeeForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                context.Employees.Add(addForm.NewEmployee);
                context.SaveChanges();
                bindingSource1.ResetBindings(false);
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования.");
                return;
            }

            var selectedEmployee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;
            using var editForm = new EditEmployeeForm(selectedEmployee);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                context.SaveChanges();
                dataGridView1.Refresh();
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
                return;
            }

            var selectedEmployee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;
            var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {selectedEmployee.Name}?",
                                         "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                context.Employees.Remove(selectedEmployee);
                context.SaveChanges();
                bindingSource1.Remove(selectedEmployee);
                dataGridView1.Refresh();
            }
        }
    }
}
