using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3rdSemesterProject.WinForm;

public partial class DepartureForm : Form
{
    private Departure _dep;

    public DepartureForm()
    {
        InitializeComponent();
        dtpDepTime.Format = DateTimePickerFormat.Custom;
        SetDataSources();
        lstDepartures.SelectedIndex = 0;
        UpdateControlsForSelected();
    }

    private void SetDataSources()
    {
        lstDepartures.DataSource = Departure.GetAllDepartures();
        cmbBoat.DataSource = Boat.GetAllBoats();
        cmbRoute.DataSource = Route.GetAllRoutes();

    }

    private void UpdateControlsForSelected()
    {
        _dep = lstDepartures.SelectedItem as Departure;
        if (_dep != null)
        {
            dtpDepTime.Value = _dep.DepartureTime;
            txtPrice.Text = _dep.Price.ToString();
            chkAllInclusive.Checked = _dep.AllInclusive;
            txtAvailableSeats.Text = _dep.AvailableSeats.ToString();
            cmbBoat.SelectedItem = _dep.DepartureBoat;
            cmbRoute.SelectedItem = _dep.DepartureRoute;
            txtDescription.Text = _dep.Description;
        }
    }

    private void lstDepartures_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateControlsForSelected();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        //Implement API call to update database
        //Check first if data is changed
        Departure updatedDep = new Departure();
        decimal temp;
        if(!Decimal.TryParse(txtPrice.Text, out temp))
        {
            showPriceError();
            return;
        }
        updatedDep.DepartureTime = dtpDepTime.Value;
        updatedDep.Price = temp;
        updatedDep.AllInclusive = chkAllInclusive.Checked;
        updatedDep.DepartureBoat = cmbBoat.SelectedItem as Boat;
        updatedDep.DepartureRoute = cmbRoute.SelectedItem as Route;
        updatedDep.Description = txtDescription.Text;
        updatedDep.DepartureID = _dep.DepartureID;

        //Call update method here with updateDep
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        //Call delete method with _dep.DepartureID
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        Departure createDep = new Departure();
        decimal temp;
        if (!Decimal.TryParse(txtPrice.Text, out temp))
        {
            showPriceError();
            return;
        }
        createDep.DepartureTime = dtpDepTime.Value;
        createDep.Price = temp;
        createDep.AllInclusive = chkAllInclusive.Checked;
        createDep.DepartureBoat = cmbBoat.SelectedItem as Boat;
        createDep.DepartureRoute = cmbRoute.SelectedItem as Route;
        createDep.Description = txtDescription.Text;

        //Call create method with createDep
    }

    private void showPriceError()
    {
        MessageBox.Show("Entered price is not a valid decimal number", "Price error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
