using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReserveRoom.CustomControls
{
    internal class NumberTextBox : TextBox
    {
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(
           nameof(Number), typeof(int?),
            typeof(NumberTextBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNumberChangedHandler)
        );

        private static void OnNumberChangedHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numberTextBox = (NumberTextBox)d;
            numberTextBox.Text = e.NewValue?.ToString();
        }

        public int? Number
        {
            get => (int?)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }
        public NumberTextBox()
        {
            this.PreviewTextInput += NumberTextBox_PreviewTextInput;
            this.TextChanged += NumberTextBox_TextChanged;
        }

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Text.IsNotNullOrWhiteSpace())
            {
                this.Number = null;
            } else if (int.TryParse(this.Text, out int number))
            {
                this.Number = number;
            }
        }

        private void NumberTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+$");
        }
    }
}
