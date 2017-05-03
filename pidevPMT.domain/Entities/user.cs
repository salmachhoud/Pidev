using pidevPMT.domain.Entities;
using System;
using System.Collections.Generic;

namespace pidevPMT.data.Models
{
    public partial class user
    {
        public long Id { get; set; }
        public string ActivationToken { get; set; }
        public string PasswordAnswer { get; set; }
        public string PasswordQuestion { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<meeting> meetingUser { get; set; }
    }
}
