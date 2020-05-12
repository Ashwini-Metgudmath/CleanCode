using System.Collections.Generic;
using System.Text;

namespace CleanCode.PoorOrderingOfClassMembers
{
    internal interface IEncoderApi
    {
        IEnumerable<Encoder> GetAvailableEncoders(object contextId);
        void ListMobileEncoders(object contextId);
        object GetEncoder(object authId);
        object Complete(List<Job> jobs);
    }
}