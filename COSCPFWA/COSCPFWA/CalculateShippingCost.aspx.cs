using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COSCPFWA
{
    public partial class CalculateShippingCost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CalculateCost(object sender, EventArgs e)
        {
            decimal basePrice = 10.00m;

            //Weight & Dimension User inputs
            decimal weight = decimal.TryParse(TextBox9.Text, out weight) ? weight : 0;
            decimal length = decimal.TryParse(TextBox10.Text, out length) ? length : 0;
            decimal width = decimal.TryParse(TextBox11.Text, out width) ? width : 0;
            decimal height = decimal.TryParse(TextBox12.Text, out height) ? height : 0;

            //Calculations
            decimal weightFee = (weight * 0.2m);
            decimal dimensionFee = (length + width + height) * 0.50m;

            string addressFrom = addressFromCost.Text;
            string addressTo = addressToCost.Text;

            decimal distanceFee = 0;
            if (!string.IsNullOrEmpty(addressFrom) && !string.IsNullOrEmpty(addressTo))
            {
                // Calculate delivery
            }

            decimal totalCost = basePrice + weightFee + dimensionFee;

            // Update labels in the cost table
            BasePrice.Text = $"${basePrice:0.00}";
            WeightFee.Text = $"${weightFee:0.00}";
            DimensionFee.Text = $"${dimensionFee:0.00}";
            DistanceFee.Text = $"${distanceFee:0.00}";
            TotalCost.Text = $"${totalCost:0.00}";

        }
    }
}