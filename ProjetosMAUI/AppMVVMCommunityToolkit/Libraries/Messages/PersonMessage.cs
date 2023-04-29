using AppMVVMCommunityToolkit.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMVVMCommunityToolkit.Libraries.Messages
{
    public class PersonMessage : ValueChangedMessage<Person>
    {
        public PersonMessage(Person person) : base(person)
        {
            
        }
    }
}
