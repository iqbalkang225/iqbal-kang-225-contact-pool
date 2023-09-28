﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        [StringLength(40)]
        public string? PersonName { get; set; }

        [StringLength(40)]
        public string? Email {  get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? CountryId { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public bool ReceiveNewsletter {  get; set; }

        public string? TIN { get; set; }

        [ForeignKey("CountryID")]
        public virtual Country? Country { get; set; }
    }
}
