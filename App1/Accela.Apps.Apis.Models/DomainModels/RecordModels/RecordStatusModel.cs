using System;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    [DataContract]
    public class RecordStatusModel : IdentifierBase, IEquatable<RecordStatusModel>
    {
        public bool Equals(RecordStatusModel other)
        {
            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the status' id are equal. 
            return Identifier.Equals(other.Identifier);
        }

        public override int GetHashCode()
        {
            //Get hash code for the Display field if it is not null. 
            int hashStatusDisplay = Display == null ? 0 : Display.GetHashCode();

            //Get hash code for the Id field. 
            int hashStatusId = Identifier.GetHashCode();

            //Calculate the hash code for the product. 
            return hashStatusDisplay ^ hashStatusId;
        }
    }
}
