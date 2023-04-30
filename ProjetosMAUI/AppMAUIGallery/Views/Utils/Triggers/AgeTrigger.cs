using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Utils.Triggers
{
    public class AgeTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            int result;
            bool isNumber = int.TryParse(sender.Text, out result);

            if (isNumber)
            {
                if(result >= 18)
                {
                    sender.TextColor = Colors.Green;
                }
                else
                {
                    sender.TextColor = Colors.Red;
                }
            }
            else
            {
                sender.TextColor = Colors.Purple;
            }

        }
    }
}
