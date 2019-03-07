using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Hotel
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        const int TAXPERCENT = 13;

        EditText totalAmount, numberOfNightsReserved;
        RadioButton suiteRoomBtn, doubleRoomBtn, singleRoomBtn;
        CheckBox transportBox, spaBox, toursitGuideBox;
        Button submitBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            totalAmount = (EditText)FindViewById(Resource.Id.totalET);
            numberOfNightsReserved = (EditText)FindViewById(Resource.Id.nightsET);
            suiteRoomBtn = (RadioButton)FindViewById(Resource.Id.suiteRoomRadioGroup);
            doubleRoomBtn = (RadioButton)FindViewById(Resource.Id.doubleRoomRadioGroup);
            singleRoomBtn = (RadioButton)FindViewById(Resource.Id.singleRoomRadioGroup);
            transportBox = (CheckBox)FindViewById(Resource.Id.transportCheckBox);
            spaBox = (CheckBox)FindViewById(Resource.Id.spaCheckBox);
            toursitGuideBox = (CheckBox)FindViewById(Resource.Id.guideCheckBox);
            submitBtn = (Button)FindViewById(Resource.Id.okBtn);

            double nightsReserved, totalBill =0.0;

            submitBtn.Click += delegate
            {

                

                if (!(suiteRoomBtn.Checked || doubleRoomBtn.Checked || singleRoomBtn.Checked))
                    Toast.MakeText(this, "Please Specify a Room type", ToastLength.Long).Show();
               

                else
                {
                    nightsReserved = double.Parse(numberOfNightsReserved.Text);
                    if (suiteRoomBtn.Checked)
                        totalBill = 1400 * nightsReserved;

                    else if (doubleRoomBtn.Checked)
                        totalBill = 900 * nightsReserved;

                    else if (singleRoomBtn.Checked)
                        totalBill = 600 * nightsReserved;

                    for (int i = 0; i < nightsReserved; i++)
                    {
                        if (spaBox.Checked)
                            totalBill += (700);
                        if (transportBox.Checked)
                            totalBill += 1000;
                        if (toursitGuideBox.Checked)
                            totalBill += 2000;
                    }
                    totalBill += totalBill * 0.13;

                    totalAmount.Text = totalBill.ToString();
                }
            };


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

