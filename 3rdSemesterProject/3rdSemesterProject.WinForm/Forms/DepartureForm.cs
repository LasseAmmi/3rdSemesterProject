using _3rdSemesterProject.WinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3rdSemesterProject.WinForm.Controllers;


namespace _3rdSemesterProject.WinForm.Forms;

public partial class DepartureForm : Form
{
    private DepartureController _depCtrl;

    public DepartureForm()
    {
        InitializeComponent();
        _depCtrl = new DepartureController();
        dtpDepTime.Format = DateTimePickerFormat.Custom;
        SetDataSources();
        lstDepartures.SelectedIndex = 0;
        UpdateControlsForSelected();
    }

    private void SetDataSources()
    {
        lstDepartures.DataSource = DepartureController.GetAllDepartures();
        cmbBoat.DataSource = DepartureController.GetAllBoats();
        cmbRoute.DataSource = DepartureController.GetAllRoutes();

    }

    private void UpdateControlsForSelected()
    {
        _depCtrl.Departure = lstDepartures.SelectedItem as Departure;
        if (_depCtrl.Departure != null)
        {
            dtpDepTime.Value = _depCtrl.Departure.DepartureTime;
            txtPrice.Text = _depCtrl.Departure.Price.ToString();
            chkAllInclusive.Checked = _depCtrl.Departure.AllInclusive;
            txtAvailableSeats.Text = _depCtrl.Departure.AvailableSeats.ToString();
            cmbBoat.SelectedItem = _depCtrl.Departure.DepartureBoat;
            cmbRoute.SelectedItem = _depCtrl.Departure.DepartureRoute;
            txtDescription.Text = _depCtrl.Departure.Description;
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
        updatedDep.DepartureID = _depCtrl.Departure.DepartureID;

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
