using Xamarin.Forms;

namespace WearMe.Triggers
{
    public class EntryAndButtonTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var priceEntry = sender as Entry;
            var priceFlag = int.TryParse(priceEntry.Text, out int price);
            priceEntry.TextColor = ((!priceFlag)) || price == 0 ? Color.Red : Color.Default;
        }

    }

    public class PhoneLengthTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            var phoneEntry = sender as Entry;
            var phoneLength = phoneEntry.Text.Length;
            phoneEntry.TextColor = phoneLength < 9 ? Color.Red : Color.Default;
        }
    }

    public class ButtonStartTrigger : TriggerAction<Button>
    {
        protected override void Invoke(Button btn)
        {
            btn.BackgroundColor = Color.DarkOrange;
            btn.Text = "Zaczynamy!!!";
        }
    }

    public class ButtonFormTrigger : TriggerAction<Button>
    {
        protected override void Invoke(Button btn)
        {
            btn.BackgroundColor = Color.DarkOrange;
        }
    }
}
