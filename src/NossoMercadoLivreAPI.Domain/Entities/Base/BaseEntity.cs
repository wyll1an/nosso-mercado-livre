using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NossoMercadoLivreAPI.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
