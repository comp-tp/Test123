using System;

// TODO:
// Seems like that this belongs to the Inspector App PRIVATED API.
// Maybe it will be removed later.

namespace Accela.Apps.Apis.Models.DomainModels
{
    public interface IEntity
    {
        string PartitionKey
        {
            get;
            set;
        }

        string RowKey
        {
            get;
            set;
        }

        DateTime Timestamp
        {
            get;
            set;
        }
    }

    public interface IEntityScope
    {
        String ProductName
        {
            get;
            set;
        }

        String Agency
        {
            get;
            set;
        }

        String EntityType
        {
            get;
            set;
        }

        Guid UserId
        {
            get;
            set;
        }

        String Namespace
        {
            get;
            set;
        }
    }

    public class EntityScope : IEntityScope
    {
        public EntityScope()
        { }

        public virtual string Agency
        {
            get;
            set;
        }

        string _productName;
        public virtual string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        public virtual string EntityType
        {
            get;
            set;
        }

        Guid _userId;
        public virtual Guid UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public virtual string Namespace
        {
            get;
            set;
        }
    }

    public interface IMobileEntity : IEntityScope
    {
        String ObjectId
        {
            get;
            set;
        }

        String ObjectData
        {
            get;
            set;
        }

        DateTime ExpiresAfter
        {
            get;
            set;
        }

        DateTime Timestamp
        {
            get;
            set;
        }
    }

    public class MobileEntity : EntityScope,IMobileEntity
    {
        public MobileEntity()
        { }

        public MobileEntity(IEntityScope scope)
        {
            base.Agency = scope.Agency;
            base.ProductName = scope.ProductName;
            base.EntityType = scope.EntityType;
            base.UserId = scope.UserId;
            base.Namespace = scope.Namespace;
        }

        public String ObjectId
        {
            get;
            set;
        }

        public String ObjectData
        {
            get;
            set;
        }

        public DateTime ExpiresAfter
        {
            get;
            set;
        }

        public DateTime Timestamp
        {
            get;
            set;
        }
    }
}
