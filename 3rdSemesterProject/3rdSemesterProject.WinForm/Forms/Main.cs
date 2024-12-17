namespace _3rdSemesterProject.WinForm.Forms;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private void btnDepartures_Click(object sender, EventArgs e)
    {
        DepartureForm depForm = new DepartureForm();
        depForm.Show();
        Hide();

        depForm.FormClosed += DepForm_FormClosed;
    }

    private void DepForm_FormClosed(object? sender, FormClosedEventArgs e)
    {
        this.Show();
    }
}
