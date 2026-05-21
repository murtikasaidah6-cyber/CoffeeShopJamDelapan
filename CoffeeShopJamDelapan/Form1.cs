using CoffeeShopJamDelapan.Views.Forms;

namespace CoffeeShopJamDelapan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide(); 
        }
    }
}
