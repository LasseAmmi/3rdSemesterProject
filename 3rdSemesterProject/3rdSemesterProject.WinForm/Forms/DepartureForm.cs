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
    }

    private void SetDataSources()
    {
        lstDepartures.DataSource = _depCtrl.GetAllDepartures();
        cmbBoat.DataSource = _depCtrl.GetAllBoats();
        cmbRoute.DataSource = _depCtrl.GetAllRoutes();
        lstDepartures.SelectedIndex = 0;
        UpdateControlsForSelected();

    }

    private void UpdateControlsForSelected()
    {
        _depCtrl.Departure = lstDepartures.SelectedItem as Departure;
        if (_depCtrl.Departure != null)
        {
            dtpDepTime.Value = _depCtrl.Departure.Time;
            txtPrice.Text = _depCtrl.Departure.Price.ToString();
            txtAvailableSeats.Text = _depCtrl.Departure.AvailableSeats.ToString();
            foreach (var item in cmbBoat.Items)
            {
                Boat tmpBoat = item as Boat;
                if(tmpBoat.BoatID == _depCtrl.Departure.BoatID)
                {
                    cmbBoat.SelectedItem = item;
                    break;
                }
            }
            foreach (var item in cmbRoute.Items)
            {
                Route tmpRoute = item as Route;
                if (tmpRoute.RouteID == _depCtrl.Departure.RouteID)
                {
                    cmbRoute.SelectedItem = item;
                    break;
                }
            }
            txtDescription.Text = _depCtrl.Departure.Description;
            txtDepName.Text = _depCtrl.Departure.DepartureName;
        }
    }

    private void lstDepartures_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateControlsForSelected();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        //Check first if data is changed
        Departure updatedDep = new Departure();
        decimal temp;
        if(!Decimal.TryParse(txtPrice.Text, out temp))
        {
            ShowPriceError();
            return;
        }
        Boat? newBoat = cmbBoat.SelectedItem as Boat;
        Route? newRoute = cmbRoute.SelectedItem as Route;
        if (newBoat == null || newRoute == null)
        {
            ShowBoatOrRouteError();
            return;
        }
        updatedDep.Time = dtpDepTime.Value;
        updatedDep.Price = temp;
        updatedDep.BoatID = newBoat.BoatID;
        updatedDep.RouteID = newRoute.RouteID;
        updatedDep.Description = txtDescription.Text;
        updatedDep.DepartureName = txtDepName.Text;
        updatedDep.DepartureID = _depCtrl.Departure.DepartureID;

        if (!updatedDep.Equals(_depCtrl.Departure))
        {
            _depCtrl.UpdateDeparture(updatedDep);
        }

        //Refreshes Data from DB after change in departures
        SetDataSources();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        _depCtrl.DeleteDeparture(_depCtrl.Departure.DepartureID);

        //Refreshes Data from DB after change in departures
        SetDataSources();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        Departure createDep = new Departure();
        decimal temp;
        if (!Decimal.TryParse(txtPrice.Text, out temp))
        {
            ShowPriceError();
            return;
        }
        Boat? newBoat = cmbBoat.SelectedItem as Boat;
        Route? newRoute = cmbRoute.SelectedItem as Route;
        if (newBoat == null || newRoute == null)
        {
            ShowBoatOrRouteError();
            return;
        }
        createDep.Time = dtpDepTime.Value;
        createDep.Price = temp;
        createDep.DepartureName = txtDepName.Text;
        createDep.BoatID = newBoat.BoatID;
        createDep.RouteID = newRoute.RouteID;
        createDep.Description = txtDescription.Text;

        _depCtrl.CreateDeparture(createDep);

        //Refreshes Data from DB after change in departures
        SetDataSources();
    }

    private void ShowPriceError()
    {
        MessageBox.Show("Entered price is not a valid decimal number", "Price error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void ShowBoatOrRouteError()
    {
        MessageBox.Show("Can't create or update departure without valid boat and route", "Create/update error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
