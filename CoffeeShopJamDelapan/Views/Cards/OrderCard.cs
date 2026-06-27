using CoffeeShopJamDelapan.Models;
using CoffeeShopJamDelapan.Views.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShopJamDelapan.Views.Cards
{
    public partial class OrderCard : UserControl
    {  
       private readonly PaymentPanel _paymentPanel;
        private readonly Prescription _recipe;
    
        public OrderCard(Prescription recipe, PaymentPanel paymentPanel, TransactionDetails transactionDetails)// coonstructor
        {
            InitializeComponent();
            _recipe = recipe;
            _paymentPanel = paymentPanel;
           
            if (!string.IsNullOrWhiteSpace(recipe.ImagePath)
                && System.IO.File.Exists(recipe.ImagePath))
            {
                pictureBoxItem.Image = Image.FromFile(recipe.ImagePath);
            }

            labelItemName.Text = recipe.Name;
            labelItemCode.Text = recipe.Code;
            labelItemPrice.Text = $"IDR {transactionDetails.Price:0.00}";
            labelItemQty.Text = $"Qty: {transactionDetails.Quantity}";
            labelItemSubtotal.Text = $"Subtotal: IDR {transactionDetails.Total:0.00}";
            labelItemCategory.Text = recipe.Type;

        }
    }
}
 