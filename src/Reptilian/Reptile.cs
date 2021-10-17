using System;

namespace Reptilian
{
    public class Reptile
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Breed { get; set; }
    }
}